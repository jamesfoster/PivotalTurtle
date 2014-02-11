namespace PivotalTurtle
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Threading.Tasks;
	using Newtonsoft.Json.Linq;

	public class PivotalTrackerClient : IPivotalTrackerClient
	{
		public IWebClientProvider WebClientProvider { get; set; }

		public PivotalTrackerClient(IWebClientProvider webClientProvider)
		{
			WebClientProvider = webClientProvider;
		}

		public bool IsAuthenticated { get { return Token != null; } }

		public string Token { get; set; }

		public async Task Authenticate(string token)
		{
			var jToken = await MakeRequest("https://www.pivotaltracker.com/services/v5/me", token);

			if (jToken == null)
				return;

			dynamic json = jToken;

			Token = json.api_token;
		}

		public async Task<List<Project>> GetProjects()
		{
			var jToken = await MakeRequest("https://www.pivotaltracker.com/services/v5/me", Token);

			if (jToken == null)
				return new List<Project>();

			dynamic json = jToken;

			var projects = new List<Project>();
			foreach (var project in json.projects)
			{
				projects.Add(new Project
					{
						Id = project.project_id,
						Name = project.project_name
					});
			}

			return projects;
		}

		public async Task<List<Story>> GetAssignedStories()
		{
			var jToken = await MakeRequest("https://www.pivotaltracker.com/services/v5/my/work", Token);

			if (jToken == null)
				return new List<Story>();

			dynamic json = jToken;

			var stories = ParseStories(json);

			return stories;
		}

		public async Task<IEnumerable<Story>> GetStoriesForProject(long projectId)
		{
			var filter = "filter=state:started,unstarted,unscheduled";
			var jToken = await MakeRequest(string.Format("https://www.pivotaltracker.com/services/v5/projects/{0}/stories?{1}", projectId, filter), Token);

			if (jToken == null)
				return new List<Story>();

			dynamic json = jToken;

			var stories = ParseStories(json);

			return stories;
		}

		private List<Story> ParseStories(dynamic json)
		{
			var stories = new List<Story>();
			foreach (var story in json)
			{
				StoryState state = ParseState(story.current_state.ToString());
				stories.Add(new Story
					{
						Id = story.id,
						Name = story.name,
						ProjectId = story.project_id,
						State = state
					});
			}
			return stories;
		}

		private StoryState ParseState(string currentState)
		{
			var values = Enum.GetValues(typeof(StoryState));

			var state = values
				.Cast<StoryState?>()
				.FirstOrDefault(x => x != null && x.Value.ToString().ToLowerInvariant() == currentState);

			return state == null ? StoryState.Unscheduled : state.Value;
		}

		private async Task<JToken> MakeRequest(string url, string token)
		{
			using (var webClient = WebClientProvider.GetClient())
			{
				var headers = new Dictionary<string, string>();
				AddTokenAuthHeader(headers, token);
				var response = await webClient.GetStringAsync(url, headers);

				JToken jToken;
				if (!TryParseJson(response, out jToken))
					return null;

				return jToken;
			}
		}

		private void AddTokenAuthHeader(Dictionary<string, string> headers, string token)
		{
			headers["X-TrackerToken"] = token;
		}

		private static bool TryParseJson(string response, out JToken jToken)
		{
			try
			{
				var json = JToken.Parse(response);
				jToken = json;
				return true;
			}
			catch
			{
				jToken = null;
				return false;
			}
		}
	}
}
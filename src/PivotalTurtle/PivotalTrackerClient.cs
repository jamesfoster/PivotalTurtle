namespace PivotalTurtle
{
	using System;
	using System.Collections.Generic;
	using System.Text;
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
			using (var webClient = WebClientProvider.GetClient())
			{
				var headers = new Dictionary<string, string>();
				AddTokenAuthHeader(headers, token);

				var response = await webClient.GetStringAsync("https://www.pivotaltracker.com/services/v5/me", headers);

				JToken jToken;
				if (!TryParseJson(response, out jToken))
					return;

				dynamic json = jToken;

				Token = json.api_token;
			}
		}

		public async Task<List<Project>> GetProjects()
		{
			using (var webClient = WebClientProvider.GetClient())
			{
				var headers = new Dictionary<string, string>();
				AddTokenAuthHeader(headers, Token);
				var response = await webClient.GetStringAsync("https://www.pivotaltracker.com/services/v5/me", headers);

				JToken jToken;
				if (!TryParseJson(response, out jToken))
					return new List<Project>();

				dynamic json = jToken;

				var projects = new List<Project>();
				foreach (var project in json.projects)
				{
					projects.Add(new Project
						{
							Name = project.project_name
						});
				}

				return projects;
			}
		}

		public async Task<List<Story>> GetAssignedStories()
		{
			using (var webClient = WebClientProvider.GetClient())
			{
				var headers = new Dictionary<string, string>();
				AddTokenAuthHeader(headers, Token);
				var response = await webClient.GetStringAsync("https://www.pivotaltracker.com/services/v5/my/work", headers);

				JToken jToken;
				if (!TryParseJson(response, out jToken))
					return new List<Story>();

				dynamic json = jToken;

				var stories = new List<Story>();
				foreach (var story in json)
				{
					stories.Add(new Story
					{
						Id = story.id,
						Name = story.name
					});
				}

				return stories;
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
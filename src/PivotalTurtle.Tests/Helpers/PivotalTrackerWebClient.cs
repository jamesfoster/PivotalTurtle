namespace PivotalTurtle.Tests.Helpers
{
	using System.Collections.Generic;
	using System.Linq;
	using System.Threading.Tasks;

	public class PivotalTrackerWebClient : IWebClient
	{
		public PivotalTrackerWebClientProvider Provider { get; set; }

		public PivotalTrackerWebClient(PivotalTrackerWebClientProvider provider)
		{
			Provider = provider;
		}

		public void Dispose()
		{
		}

		public Task<string> GetStringAsync(string url, Dictionary<string, string> headers)
		{
			string result = null;

			if (!Authenticate(headers))
			{
				result = UnauthorizedResult();
			}
			else
			{
				switch (url)
				{
					case "https://www.pivotaltracker.com/services/v5/me":
						result = GetUserResult();
						break;

					case "https://www.pivotaltracker.com/services/v5/my/work":
						result = GetStoriesResult();
						break;
				}
			}

			return Task.FromResult(result);
		}

		private string UnauthorizedResult()
		{
			return null;
		}

		private string GetUserResult()
		{
			var projectsString = string.Join(",", Provider.Projects.Select(GetProjectString));

			return @"{
   ""time_zone"":
   {
       ""offset"": ""-08:00"",
       ""olson_name"": ""America/Los_Angeles"",
       ""kind"": ""time_zone""
   },
   ""has_google_identity"": false,
   ""projects"":
   [" + projectsString + @"],
   ""id"": 101,
   ""api_token"": """ + Provider.Token + @""",
   ""initials"": ""DV"",
   ""email"": ""vader@deathstar.mil"",
   ""username"": ""vader"",
   ""name"": ""Darth Vader"",
   ""kind"": ""me""
}";

		}

		private static string GetProjectString(Project project)
		{
			return @"{
           ""project_color"": ""8100ea"",
           ""id"": 108,
           ""project_id"": " + project.Id + @",
           ""project_name"": """ + project.Name + @""",
           ""role"": ""owner"",
           ""last_viewed_at"": ""2014-02-04T12:00:00Z"",
           ""kind"": ""membership_summary""
       }";
		}

		private string GetStoriesResult()
		{
			var storiesString = string.Join(",", Provider.Stories.Select(GetStoryString));

			return string.Format("[{0}]", storiesString);
		}

		private string GetStoryString(Story story)
		{
			return
@"{
       ""owner_ids"":
       [
           101,
           105
       ],
       ""description"": ""She is proving to be resistant to our mind probes"",
       ""requested_by_id"": 101,
       ""id"": " + story.Id + @",
       ""estimate"": 2,
       ""story_type"": ""feature"",
       ""project_id"": " + story.ProjectId + @",
       ""owned_by_id"": 101,
       ""updated_at"": ""2014-02-04T12:00:00Z"",
       ""created_at"": ""2014-02-04T12:00:00Z"",
       ""current_state"": """ + story.State.ToString().ToLowerInvariant() + @""",
       ""url"": ""http://localhost/story/show/556"",
       ""name"": """ + story.Name + @""",
       ""labels"":
       [
           {
               ""id"": 2008,
               ""project_id"": ""98"",
               ""updated_at"": ""2014-02-04T12:00:00Z"",
               ""created_at"": ""2014-02-04T12:00:00Z"",
               ""name"": ""plans"",
               ""kind"": ""label""
           },
           {
               ""id"": 2007,
               ""project_id"": ""98"",
               ""updated_at"": ""2014-02-04T12:00:00Z"",
               ""created_at"": ""2014-02-04T12:00:00Z"",
               ""name"": ""rebel bases"",
               ""kind"": ""label""
           }
       ],
       ""kind"": ""story""
   }";
		}

		private bool Authenticate(Dictionary<string, string> headers)
		{
			if (!headers.ContainsKey("X-TrackerToken"))
				return false;

			return headers["X-TrackerToken"] == Provider.Token;
		}
	}
}
namespace PivotalTurtle.Tests.Helpers
{
	using System.Collections.Generic;

	public class PivotalTrackerWebClientProvider : IWebClientProvider
	{
		public string Token { get; set; }
		public List<Project> Projects { get; set; }
		public List<Story> MyStories { get; set; }
		public List<Story> ProjectStories { get; set; }
		public long SelectedProjectId { get; set; }

		public PivotalTrackerWebClientProvider()
		{
			Projects = new List<Project>();
			MyStories = new List<Story>();
			ProjectStories = new List<Story>();
		}

		public IWebClient GetClient()
		{
			return new PivotalTrackerWebClient(this);
		}
	}
}
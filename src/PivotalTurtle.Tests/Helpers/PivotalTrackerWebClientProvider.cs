namespace PivotalTurtle.Tests.Helpers
{
	using System.Collections.Generic;

	public class PivotalTrackerWebClientProvider : IWebClientProvider
	{
		public string Token { get; set; }
		public List<Project> Projects { get; set; }
		public List<Story> Stories { get; set; }

		public PivotalTrackerWebClientProvider()
		{
			Projects = new List<Project>();
			Stories = new List<Story>();
		}

		public IWebClient GetClient()
		{
			return new PivotalTrackerWebClient(this);
		}
	}
}
namespace PivotalTurtle
{
	using System.Collections.Generic;
	using System.Threading.Tasks;

	public interface IPivotalTrackerClient
	{
		bool IsAuthenticated { get; }
		string Token { get; set; }
		Task Authenticate(string token);
		Task<List<Project>> GetProjects();
		Task<List<Story>> GetAssignedStories();
		Task<IEnumerable<Story>> GetStoriesForProject(long projectId);
	}
}
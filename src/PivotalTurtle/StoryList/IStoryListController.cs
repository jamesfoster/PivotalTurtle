namespace PivotalTurtle.StoryList
{
	using System.Collections.Generic;
	using System.Threading.Tasks;

	public interface IStoryListController : IViewController<IStoryListView>
	{
		Task<Story> SelectStory(Settings settings);
		Task<IEnumerable<Story>> GetStoriesForProject(Project project);
	}
}
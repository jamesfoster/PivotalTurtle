namespace PivotalTurtle.StoryList
{
	using System.Threading.Tasks;

	public interface IStoryListController : IViewController<IStoryListView>
	{
		Task<Story> SelectStory();
	}
}
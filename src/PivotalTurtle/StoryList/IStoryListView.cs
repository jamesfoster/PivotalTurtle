namespace PivotalTurtle.StoryList
{
	using System.Collections.Generic;

	public interface IStoryListView : IView
	{
		List<Project> Projects { get; set; }
		List<Story> Stories { get; set; }
		List<Story> SelectedStories { get; set; }
		IStoryListController Controller { get; set; }
		Project SelectedProject { get; set; }
	}
}
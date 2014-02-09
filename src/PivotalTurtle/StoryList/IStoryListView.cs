namespace PivotalTurtle.StoryList
{
	using System.Collections.Generic;

	public interface IStoryListView : IView
	{
		IEnumerable<Project> Projects { get; set; }
		IEnumerable<Story> Stories { get; set; }
		List<Story> SelectedStories { get; set; }
	}
}
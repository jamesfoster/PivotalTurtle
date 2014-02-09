namespace PivotalTurtle.StoryList
{
	using System.Collections.Generic;
	using System.Threading.Tasks;
	using System.Windows.Forms;

	public class StoryListView : IStoryListView
	{
		public Task Show()
		{
			var window = new StoryListWindow();

			window.SetProjects(Projects);
			window.SetStories(Stories);

			if (window.ShowDialog() != DialogResult.OK)
			{
				return Task.Delay(0);
			}

			SelectedStories = window.SelectedStories;

			return Task.Delay(0);
		}

		public List<Story> SelectedStories { get; set; }

		public IEnumerable<Project> Projects { get; set; }
		public IEnumerable<Story> Stories { get; set; }
	}
}
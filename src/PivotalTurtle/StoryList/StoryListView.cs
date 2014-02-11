namespace PivotalTurtle.StoryList
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Threading.Tasks;
	using System.Windows.Forms;

	public class StoryListView : IStoryListView
	{
		private Project selectedProject;
		private StoryListWindow window;

		public StoryListView()
		{
			SelectedStories = new List<Story>();
		}

		public Task Show()
		{
			try
			{
				window = new StoryListWindow(this);

				window.RefreshDisplay();

				if (window.ShowDialog() == DialogResult.OK)
				{
					return Task.Delay(0);
				}

				SelectedStories = new List<Story>();

				return Task.Delay(0);
			}
			finally
			{
				window = null;
			}
		}

		public Project SelectedProject
		{
			get { return selectedProject; }
			set
			{
				selectedProject = value;
				UpdateStories(value);
			}
		}

		private async void UpdateStories(Project project)
		{
			var stories = await Controller.GetStoriesForProject(project);
			Stories = stories.ToList();
			window.RefreshDisplay();
		}

		public List<Story> SelectedStories { get; set; }
		public IStoryListController Controller { get; set; }
		public List<Project> Projects { get; set; }
		public List<Story> Stories { get; set; }
	}
}
namespace PivotalTurtle.StoryList
{
	using System;
	using System.Collections.Generic;
	using System.Globalization;
	using System.Windows.Forms;

	public partial class StoryListWindow : Form
	{
		private readonly List<Project> projects;
		private readonly List<Story> stories;
		private readonly List<Story> selectedStories;

		public List<Story> SelectedStories { get { return selectedStories; }}

		public StoryListWindow()
		{
			InitializeComponent();

			projects = new List<Project>();
			stories = new List<Story>();
			selectedStories = new List<Story>();
		}

		public void SetProjects(IEnumerable<Project> newProjects)
		{
			projects.Clear();
			foreach (var project in newProjects)
			{
				projects.Add(project);
			}
		}

		public void SetStories(IEnumerable<Story> newStories)
		{
			stories.Clear();
			foreach (var story in newStories)
			{
				stories.Add(story);
			}

			DisplayStories();
		}

		private void DisplayStories()
		{
			storiesListView.BeginUpdate();
			try
			{
				storiesListView.Items.Clear();
				foreach (var story in stories)
				{
					var item = new ListViewItem
						{
							Text = "",
							Tag = story
						};
					item.SubItems.Add(story.Id.ToString(CultureInfo.InvariantCulture));
					item.SubItems.Add(story.Name);
					item.SubItems.Add(story.State.ToString());
					item.SubItems.Add(ProjectName(story.ProjectId));

					storiesListView.Items.Add(item);
				}
			}
			finally
			{
				storiesListView.EndUpdate();
			}
		}

		private string ProjectName(long projectId)
		{
			var project = projects.Find(p => p.Id == projectId);

			return project != null ? project.Name : "unknown";
		}

		private void storiesListView_ItemChecked(object sender, ItemCheckedEventArgs e)
		{
			if (e.Item.Checked)
				selectedStories.Add((Story) e.Item.Tag);
			else
				selectedStories.Remove((Story) e.Item.Tag);
		}
	}
}

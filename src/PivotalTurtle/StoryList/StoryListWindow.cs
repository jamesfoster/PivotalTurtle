namespace PivotalTurtle.StoryList
{
	using System.Globalization;
	using System.Windows.Forms;

	public partial class StoryListWindow : Form
	{
		private readonly StoryListView viewModel;

		public StoryListWindow(StoryListView viewModel)
		{
			this.viewModel = viewModel;
			InitializeComponent();
		}

		public void RefreshDisplay()
		{
			RefreshProjects();
			RefreshStories();
		}

		private void RefreshProjects()
		{
			projectDropDown.BeginUpdate();
			try
			{
				projectDropDown.Items.Clear();
				foreach (var project in viewModel.Projects)
				{
					projectDropDown.Items.Add(project);
				}
			}
			finally
			{
				projectDropDown.EndUpdate();
			}
		}

		private void RefreshStories()
		{
			storiesListView.BeginUpdate();
			try
			{
				storiesListView.Items.Clear();
				foreach (var story in viewModel.Stories)
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
			var project = viewModel.Projects.Find(p => p.Id == projectId);

			return project != null ? project.Name : "unknown";
		}

		private void storiesListView_ItemChecked(object sender, ItemCheckedEventArgs e)
		{
			if (e.Item.Checked)
				viewModel.SelectedStories.Add((Story) e.Item.Tag);
			else
				viewModel.SelectedStories.Remove((Story) e.Item.Tag);
		}

		private void projectDropDown_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			viewModel.SelectedProject = (Project) projectDropDown.SelectedItem;
		}
	}
}

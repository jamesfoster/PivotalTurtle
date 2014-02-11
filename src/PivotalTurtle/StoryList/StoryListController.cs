namespace PivotalTurtle.StoryList
{
	using System.Collections.Generic;
	using System.Linq;
	using System.Threading.Tasks;
	using PivotalTurtle.Services;

	public class StoryListController : IStoryListController
	{
		public IStoryListView View { get; private set; }
		public IPivotalTrackerClient Client { get; set; }
		public IMessageBoxService MessageBoxService { get; set; }

		public StoryListController(IStoryListView storyListView, IPivotalTrackerClient client, IMessageBoxService messageBoxService)
		{
			View = storyListView;
			Client = client;
			MessageBoxService = messageBoxService;
		}

		public async Task<Story> SelectStory(Settings settings)
		{
			var projects = await Client.GetProjects();

			if (!projects.Any())
			{
				await MessageBoxService.ShowMessage("You are not assigned to any projects in PivotalTracker.");
				return null;
			}

			var stories = await Client.GetAssignedStories();

			View.Projects = projects;
			View.Stories = stories;
			View.Controller = this;

			await View.Show();

			return View.SelectedStories.FirstOrDefault();
		}

		public async Task<IEnumerable<Story>> GetStoriesForProject(Project project)
		{
			return await Client.GetStoriesForProject(project.Id);
		}
	}
}
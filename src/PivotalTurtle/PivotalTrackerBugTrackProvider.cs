namespace PivotalTurtle
{
	using System.Collections.Generic;
	using System.Threading.Tasks;
	using PivotalTurtle.Auth;
	using PivotalTurtle.Services;
	using PivotalTurtle.StoryList;

	public class PivotalTrackerBugTrackProvider : IBugTrackProvider
	{
		public IAuthController AuthController { get; set; }
		public IStoryListController StoryListController { get; set; }
		public IGitConfig GitConfig { get; set; }
		public IMessageBoxService MessageBoxService { get; set; }

		public async Task<CommitDetails> GetNewCommitMessage(CommitDetails details)
		{
			var settings = LoadSettings();

			var authenticated = await AuthController.LogIn(settings);

			if (!authenticated)
			{
				await MessageBoxService.ShowMessage("Failed to authenticate. Please check your API key.");
				return details;
			}

			SaveSettings(settings);

			var story = await StoryListController.SelectStory(settings);

			if (story == null)
			{
				return details;
			}

			return new CommitDetails
				{
					Message = string.Format("[#{0}] {1}", story.Id, details.Message)
				};
		}

		private void SaveSettings(Settings settings)
		{
			var config = new Dictionary<string, string>
				{
					{"pivotal-tracker.token", settings.Token}
				};

			GitConfig.SaveGlobal(config);
		}

		private Settings LoadSettings()
		{
			var config = GitConfig.Load();

			return new Settings(config);
		}
	}
}
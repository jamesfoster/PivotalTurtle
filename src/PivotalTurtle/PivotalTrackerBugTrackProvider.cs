namespace PivotalTurtle
{
	using System.Threading.Tasks;
	using PivotalTurtle.Auth;
	using PivotalTurtle.StoryList;

	public class PivotalTrackerBugTrackProvider : IBugTrackProvider
	{
		public IAuthController AuthController { get; set; }
		public IStoryListController StoryListController { get; set; }
		public IGitConfig GitConfig { get; set; }

		public async Task<CommitDetails> GetNewCommitMessage(CommitDetails details)
		{
			var settings = LoadSettings();

			await AuthController.LogIn(settings);

			var story = await StoryListController.SelectStory(settings);

			if (story == null)
			{
				return null;
			}

			return new CommitDetails
				{
					Message = string.Format("[#{0}] {1}", story.Id, details.Message)
				};
		}

		private Settings LoadSettings()
		{
			var config = GitConfig.Execute();

			return new Settings(config);
		}
	}
}
namespace PivotalTurtle
{
	using System.Globalization;
	using System.Threading.Tasks;
	using PivotalTurtle.Auth;
	using PivotalTurtle.StoryList;

	public class PivotalTrackerBugTrackProvider : IBugTrackProvider
	{
		public IAuthController AuthController { get; set; }
		public IStoryListController StoryListController { get; set; }

		public async Task<CommitDetails> GetNewCommitMessage(CommitDetails details)
		{
			await AuthController.LogIn();

			var story = await StoryListController.SelectStory();

			if (story == null)
			{
				return null;
			}

			return new CommitDetails
				{
					Message = string.Format("[#{0}] {1}", story.Id, details.Message)
				};
		}
	}
}
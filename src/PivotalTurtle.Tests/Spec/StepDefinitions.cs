namespace PivotalTurtle.Tests.Spec
{
	using System.Collections.Generic;
	using System.Globalization;
	using System.Linq;
	using System.Threading.Tasks;
	using DeepEqual.Syntax;
	using Moq;
	using PivotalTurtle.Auth;
	using PivotalTurtle.Services;
	using PivotalTurtle.StoryList;
	using PivotalTurtle.Tests.Helpers;
	using Ploeh.AutoFixture;
	using Ploeh.AutoFixture.AutoMoq;
	using Shouldly;
	using TechTalk.SpecFlow;

	[Binding]
	public class StepDefinitions
	{
		private Fixture fixture;
		private PivotalTrackerBugTrackProvider provider;

		private Mock<ILogInView> logInView;
		private TaskCompletionSource<object> loginViewShowTcs;
		private Mock<IStoryListView> storyListView;
		private TaskCompletionSource<object> storyListViewShowTcs;

		private PivotalTrackerWebClientProvider webClientProvider;
		private IPivotalTrackerClient pivotalTrackerClient;
		private Mock<IMessageBoxService> messageBoxService;
		private CommitDetails originalCommitDetails;
		private Task<CommitDetails> selectStoriesTask;

		private List<Project> projects;
		private List<Story> stories;

		[BeforeScenario]
		public void SetUp()
		{
			fixture = new Fixture();
			fixture.Customize(new AutoMoqCustomization());

			logInView = new Mock<ILogInView>();
			loginViewShowTcs = new TaskCompletionSource<object>();
			logInView.Setup(x => x.Show()).Returns(loginViewShowTcs.Task);
			logInView.SetupAllProperties();

			storyListView = new Mock<IStoryListView>();
			storyListViewShowTcs = new TaskCompletionSource<object>();
			storyListView.Setup(x => x.Show()).Returns(storyListViewShowTcs.Task);
			storyListView.SetupAllProperties();

			messageBoxService = new Mock<IMessageBoxService>();
			messageBoxService.Setup(x => x.ShowMessage(It.IsAny<string>()))
				.Returns(Task.FromResult<object>(null));

			webClientProvider = new PivotalTrackerWebClientProvider();
			pivotalTrackerClient = new PivotalTrackerClient(webClientProvider);

			provider = new PivotalTrackerBugTrackProvider
				{
					AuthController = new AuthController(logInView.Object, pivotalTrackerClient),
					StoryListController = new StoryListController(storyListView.Object, pivotalTrackerClient, messageBoxService.Object)
				};
		}

		[AfterScenario]
		public void TearDown()
		{
			loginViewShowTcs.TrySetResult(null);
			storyListViewShowTcs.TrySetResult(null);
			selectStoriesTask.IsCompleted.ShouldBe(true);
		}

		[Given(@"I am not logged in")]
		public void GivenIAmNotLoggedIn()
		{
			pivotalTrackerClient.Token = null;
		}

		[Given(@"I am logged in")]
		public void GivenIAmLoggedIn()
		{
			var token = fixture.Create<string>();

			webClientProvider.Token = token;

			pivotalTrackerClient.Token = token;
		}

		[When(@"I press the Select Stories button")]
		public void WhenIPressTheSelectStoriesButton()
		{
			originalCommitDetails = fixture.Create<CommitDetails>();

			selectStoriesTask = provider.GetNewCommitMessage(originalCommitDetails);
		}

		[Then(@"I should be asked to log in")]
		public void ThenIShouldBeAskedForAUsernamePassword()
		{
			logInView.Verify(x => x.Show(), Times.Once());
		}

		[Then(@"I should not be asked to log in")]
		public void ThenIShouldNotBeAskedForAUsernamePassword()
		{
			logInView.Verify(x => x.Show(), Times.Never());
		}

		[When(@"I enter valid credentials")]
		public void WhenIEnterValidCredentials()
		{
			var token = fixture.Create<string>();

			webClientProvider.Token = token;

			logInView.SetupGet(x => x.Token).Returns(token);
		}

		[When(@"I enter invalid credentials")]
		public void WhenIEnterInvalidCredentials()
		{
			var token = fixture.Create<string>();

			webClientProvider.Token = token;

			logInView.SetupGet(x => x.Token).Returns("wrong token");
		}

		[When(@"I click the Log in button")]
		public void WhenIClickTheLogInButton()
		{
			loginViewShowTcs.SetResult(null);
		}

		[Then(@"I should be logged in")]
		public void ThenIShouldBeLoggedIn()
		{
			pivotalTrackerClient.IsAuthenticated.ShouldBe(true);
		}


		[Then(@"I should not be logged in")]
		public void ThenIShouldNotBeLoggedIn()
		{
			pivotalTrackerClient.IsAuthenticated.ShouldBe(false);
		}

		[Given(@"I am assigned to at least one project in PivotalTracker")]
		public void GivenIAmAssignedToAtLeastOneProjectInPivotalTracker()
		{
			projects = fixture.CreateMany<Project>().ToList();

			webClientProvider.Projects = projects;
		}

		[Given(@"I am assigned to at least one story in PivotalTracker")]
		public void GivenIAmAssignedToAtLeastOneStoryInPivotalTracker()
		{
			stories = fixture.CreateMany<Story>().ToList();

			webClientProvider.Stories = stories;
		}


		[Given(@"I am not assigned to any projects in PivotalTracker")]
		public void GivenIAmNotAssignedToAnyProjectsInPivotalTracker()
		{
			webClientProvider.Projects = new List<Project>();
		}

		[Then(@"I should see a list of projects")]
		public void ThenIShouldSeeAListOfProjects()
		{
			storyListView.Verify(x => x.Show(), Times.Once());
			storyListView.Object.Projects.ShouldDeepEqual(projects);
		}

		[Then(@"I should not see a list of projects")]
		public void ThenIShouldNotSeeAListOfProjects()
		{
			storyListView.Verify(x => x.Show(), Times.Never());
			storyListView.Object.Projects.ShouldBeEmpty();
		}

		[Then(@"I should see a message to create a project on PivotalTracker")]
		public void ThenIShouldSeeAMessageToCreateAProjectOnPivotalTracker()
		{
			messageBoxService.Verify(x => x.ShowMessage("You are not assigned to any projects in PivotalTracker."));
		}

		[Then(@"I should see my list of stories")]
		public void ThenIShouldSeeMyListOfStories()
		{
			storyListView.Verify(x => x.Show(), Times.Once());
			storyListView.Object.Stories.ShouldDeepEqual(stories);
		}

		[When(@"I select a story")]
		public void WhenISelectAStory()
		{
			storyListView.Object.SelectedStories = new List<Story>
				{
					stories[0]
				};
		}

		[When(@"I click the OK button")]
		public void WhenIClickTheOkButton()
		{
			storyListViewShowTcs.SetResult(null);
		}

		[Then(@"the new commit message should contain the story id")]
		public void ThenTheNewCommitMessageShouldContainTheStoryId()
		{
			var commitDetails = selectStoriesTask.Result;

			var expectedMessage = string.Format("[#{0}] {1}", stories[0].Id, originalCommitDetails.Message);

			commitDetails.Message.ShouldBe(expectedMessage);
		}
	}
}

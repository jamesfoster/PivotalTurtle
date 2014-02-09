namespace PivotalTurtle.Tests
{
	using System;
	using System.Threading.Tasks;
	using DeepEqual.Syntax;
	using Moq;
	using Ploeh.AutoFixture;
	using Ploeh.AutoFixture.AutoMoq;
	using Shouldly;
	using Xunit;

	public class PluginTests
	{
		private Plugin plugin;
		private Fixture fixture;

		public PluginTests()
		{
			plugin = new Plugin();
			fixture = new Fixture();
		}

		[Fact]
		public void Should_delegate_to_IBugTrackProvider()
		{
			var bugTrackProvider = new Mock<IBugTrackProvider>();
			plugin.BugTrackProvider = bugTrackProvider.Object;

			var result = fixture.Create<CommitDetails>();
			bugTrackProvider
				.Setup(x => x.GetNewCommitMessage(It.IsAny<CommitDetails>()))
				.Returns(Task.FromResult(result));

			var hParentWnd = default(IntPtr);
			var parameters = fixture.Create<string>();
			var commonUrl = fixture.Create<string>();
			var commonRoot = fixture.Create<string>();
			var pathList = fixture.Create<string[]>();
			var originalMessage = fixture.Create<string>();
			var bugId = fixture.Create<string>();
			string bugIdOut;
			string[] revPropNames;
			string[] revPropValues;

			var newMessage = plugin.GetCommitMessage2(
				hParentWnd,
				parameters,
				commonUrl,
				commonRoot,
				pathList,
				originalMessage,
				bugId,
				out bugIdOut,
				out revPropNames,
				out revPropValues);

			var exptectedCommitDetails = new CommitDetails
				{
					Message = originalMessage
				};

			bugTrackProvider.Verify(x => x.GetNewCommitMessage(It.Is<CommitDetails>(d => d.IsDeepEqual(exptectedCommitDetails))));

			newMessage.ShouldBe(result.Message);
		}

		[Fact]
		public void The_text_on_the_button_should_be_Select_Stories()
		{
			var buttonText = plugin.GetLinkText(default(IntPtr), "");

			buttonText.ShouldBe("Select Stories");
		}

		[Fact]
		public void Bypass_verification_of_parameters()
		{
			var valid = plugin.ValidateParameters(default(IntPtr), null);

			valid.ShouldBe(true);
		}


		[Fact]
		public void Does_not_have_options()
		{
			var hasOptions = plugin.HasOptions();

			hasOptions.ShouldBe(false);
		}

		[Fact]
		public void Bypass_show_options_dialog()
		{
			var parameters = fixture.Create<string>();

			var newParameters = plugin.ShowOptionsDialog(default(IntPtr), parameters);

			newParameters.ShouldBe(parameters);
		}
	}
}
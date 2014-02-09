namespace PivotalTurtle
{
	using System;
	using System.Runtime.InteropServices;
	using Interop.BugTraqProvider;
	using Microsoft.Win32;
	using PivotalTurtle.Auth;
	using PivotalTurtle.Services;
	using PivotalTurtle.StoryList;

	[ComVisible(true)]
	[Guid("2414651C-EBC1-4709-8E44-EBA1263EBAB3")]
	[ClassInterface(ClassInterfaceType.None)]
	public class Plugin : IBugTraqProvider2
	{
		public IBugTrackProvider BugTrackProvider { get; set; }

		public Plugin()
		{
			var pivotalTrackerClient = new PivotalTrackerClient(new WebClientProvider());

			BugTrackProvider = new PivotalTrackerBugTrackProvider
				{
					AuthController = new AuthController(new LogInView(), pivotalTrackerClient),
					StoryListController = new StoryListController(new StoryListView(), pivotalTrackerClient, new MessageBoxService()),
					GitConfig = new GitConfig(),
					MessageBoxService = new MessageBoxService()
				};
		}

		public string GetCommitMessage(IntPtr hParentWnd, string parameters, string commonRoot, string[] pathList, string originalMessage)
		{
			string bugIdOut;
			string[] revPropNames;
			string[] revPropValues;
			return GetCommitMessage2(hParentWnd, parameters, "", commonRoot, pathList, originalMessage, "", out bugIdOut, out revPropNames, out revPropValues);
		}

		public string GetCommitMessage2(IntPtr hParentWnd, string parameters, string commonUrl, string commonRoot, string[] pathList, string originalMessage, string bugId, out string bugIdOut, out string[] revPropNames, out string[] revPropValues)
		{
			var commitDetails = new CommitDetails
				{
					Message = originalMessage
				};

			var newCommitDetails = BugTrackProvider.GetNewCommitMessage(commitDetails).Result;

			bugIdOut = null;
			revPropNames = new string[0];
			revPropValues = new string[0];
			return newCommitDetails.Message;
		}

		public string CheckCommit(IntPtr hParentWnd, string parameters, string commonUrl, string commonRoot, string[] pathList, string commitMessage)
		{
			return null;
		}

		public string OnCommitFinished(IntPtr hParentWnd, string commonRoot, string[] pathList, string logMessage, int revision)
		{
			return null;
		}

		public bool HasOptions()
		{
			return false;
		}

		public string ShowOptionsDialog(IntPtr hParentWnd, string parameters)
		{
			return parameters;
		}

		public bool ValidateParameters(IntPtr hParentWnd, string parameters)
		{
			return true;
		}

		public string GetLinkText(IntPtr hParentWnd, string parameters)
		{
			return "Select Stories";
		}

		#region Com registration

		[ComRegisterFunction]
		public static void Register(Type t)
		{
			var subkey = GetCategorySubkey(t.GUID);
			Registry.ClassesRoot.CreateSubKey(subkey);

			var clsidKey = GetClassSubkey(t.GUID);
			var key = Registry.ClassesRoot.OpenSubKey(clsidKey, true);
			key.SetValue("", "PivotalTurtle");
		}

		[ComUnregisterFunction]
		public static void Unegister(Type t)
		{
			var subkey = GetCategorySubkey(t.GUID);
			Registry.ClassesRoot.DeleteSubKey(subkey, false);
		}

		private static string GetCategorySubkey(Guid guid)
		{
			const string categoryGuid = "3494FA92-B139-4730-9591-01135D5E7831";

			var clsid = GetClassSubkey(guid);
			var subkey = string.Format("{0}\\Implemented Categories\\{{{1}}}", clsid, categoryGuid);
			return subkey;
		}

		private static string GetClassSubkey(Guid guid)
		{
			var clsid = string.Format("CLSID\\{0}", guid.ToString("B"));
			return clsid;
		}

		#endregion Com registration
	}
}

namespace PivotalTurtle
{
	using System;
	using System.Collections.Generic;
	using System.Diagnostics;

	public class GitConfig : IGitConfig
	{
		public Dictionary<string, string> Load()
		{
			try
			{
				var info = new ProcessStartInfo("git", "config --list")
					{
						RedirectStandardOutput = true,
						UseShellExecute = false,
						CreateNoWindow = true
					};

				var process = Process.Start(info);

				var output = process.StandardOutput.ReadToEnd();

				return ParseConfig(output);
			}
			catch (Exception e)
			{
				throw new ApplicationException("Unable to load settings from git config", e);
			}
		}

		private Dictionary<string, string> ParseConfig(string output)
		{
			var config = new Dictionary<string, string>();

			var lines = output.Split('\n');

			foreach (var line in lines)
			{
				if(!line.Contains("="))
					continue;

				var parts = line.Split(new[] {'='}, 2);
				config[parts[0]] = parts[1];
			}

			return config;
		}
	}
}
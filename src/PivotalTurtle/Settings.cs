namespace PivotalTurtle
{
	using System.Collections.Generic;

	public class Settings
	{
		private readonly Dictionary<string, string> config;

		public Settings(Dictionary<string, string> config)
		{
			this.config = config;
		}

		public string Token
		{
			get
			{
				if (config.ContainsKey("pivotal-tracker.token"))
					return config["pivotal-tracker.token"];

				return null;
			}
		}
	}
}
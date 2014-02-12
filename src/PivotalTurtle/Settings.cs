namespace PivotalTurtle
{
	using System;
	using System.Collections.Generic;

	public class Settings
	{
		public Settings(Dictionary<string, string> config)
		{
			TryGet(config, "pivotal-tracker.token", x => Token = x);
		}

		void TryGet(IDictionary<string, string> config, string key, Action<string> func)
		{
			string value;
			if (config.TryGetValue(key, out value))
				func(value);
		}

		public string Token { get; set; }
	}
}
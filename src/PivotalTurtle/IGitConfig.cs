namespace PivotalTurtle
{
	using System.Collections.Generic;

	public interface IGitConfig
	{
		Dictionary<string, string> Load();
		void SaveGlobal(Dictionary<string, string> settings);
	}
}
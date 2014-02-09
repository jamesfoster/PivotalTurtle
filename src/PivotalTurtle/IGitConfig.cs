namespace PivotalTurtle
{
	using System.Collections.Generic;

	public interface IGitConfig
	{
		Dictionary<string, string> Execute();
	}
}
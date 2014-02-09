namespace PivotalTurtle
{
	using System;
	using System.Collections.Generic;
	using System.Threading.Tasks;

	public interface IWebClient : IDisposable
	{
		Task<string> GetStringAsync(string url, Dictionary<string, string> headers);
	}
}
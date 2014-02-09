namespace PivotalTurtle
{
	using System;
	using System.Collections.Generic;
	using System.Net;
	using System.Threading.Tasks;

	internal class WebClientWrapper : IWebClient
	{
		private WebClient inner;

		public WebClientWrapper(WebClient webClient)
		{
			inner = webClient;
		}

		public void Dispose()
		{
			inner.Dispose();
		}

		public Task<string> GetStringAsync(string url, Dictionary<string, string> headers)
		{
			foreach (var header in headers)
			{
				inner.Headers.Add(header.Key, header.Value);
			}

			try
			{
				var response = inner.DownloadString(url);

				return Task.FromResult(response);
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				return Task.FromResult("");
			}
		}
	}
}
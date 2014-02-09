namespace PivotalTurtle
{
	using System.Net;

	class WebClientProvider : IWebClientProvider
	{
		public IWebClient GetClient()
		{
			return new WebClientWrapper(new WebClient());
		}
	}
}
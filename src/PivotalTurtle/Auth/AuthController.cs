namespace PivotalTurtle.Auth
{
	using System.Threading.Tasks;

	public class AuthController : IAuthController
	{
		public ILogInView View { get; set; }
		public IPivotalTrackerClient Client { get; set; }

		public AuthController(ILogInView view, IPivotalTrackerClient pivotalTrackerClient)
		{
			View = view;
			Client = pivotalTrackerClient;
		}

		public async Task<bool> LogIn(Settings settings)
		{
			if (!Client.IsAuthenticated && settings.Token != null)
			{
				await Client.Authenticate(settings.Token);
			}

			if (!Client.IsAuthenticated)
			{
				await View.Show();

				await Client.Authenticate(View.Token);

				if (Client.IsAuthenticated)
				{
					settings.Token = Client.Token;
				}
			}

			return Client.IsAuthenticated;
		}
	}
}
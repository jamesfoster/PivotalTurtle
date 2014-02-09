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

		public string AuthToken { get; set; }

		public async Task<bool> LogIn()
		{
			if (!Client.IsAuthenticated)
			{
				await View.Show();

				await Client.Authenticate(View.Token);
			}

			return Client.IsAuthenticated;
		}
	}
}
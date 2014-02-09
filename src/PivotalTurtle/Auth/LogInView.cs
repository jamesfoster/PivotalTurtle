namespace PivotalTurtle.Auth
{
	using System.Threading.Tasks;
	using System.Windows.Forms;

	public class LogInView : ILogInView
	{
		public Task Show()
		{
			var window = new LogInWindow();
			if (window.ShowDialog() != DialogResult.OK)
			{
				return Task.Delay(0);
			}

			Token = window.Token;

			return Task.Delay(0);
		}

		public string Token { get; set; }
	}
}
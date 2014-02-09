namespace PivotalTurtle.Auth
{
	using System.Windows.Forms;

	public partial class LogInWindow : Form
	{
		public LogInWindow()
		{
			InitializeComponent();
		}

		public string Token { get; set; }

		private void login_Click(object sender, System.EventArgs e)
		{
			Token = token.Text;
		}
	}
}

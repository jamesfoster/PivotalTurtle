namespace PivotalTurtle.Services
{
	using System.Threading.Tasks;
	using System.Windows.Forms;

	public class MessageBoxService : IMessageBoxService
	{
		public Task ShowMessage(string message)
		{
			MessageBox.Show(message);
			return Task.Delay(0);
		}
	}
}
namespace PivotalTurtle.Services
{
	using System.Threading.Tasks;

	public interface IMessageBoxService
	{
		Task ShowMessage(string message);
	}
}
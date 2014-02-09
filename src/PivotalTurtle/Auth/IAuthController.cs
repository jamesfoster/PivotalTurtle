namespace PivotalTurtle.Auth
{
	using System.Threading.Tasks;

	public interface IAuthController : IViewController<ILogInView>
	{
		Task<bool> LogIn(Settings settings);
	}
}
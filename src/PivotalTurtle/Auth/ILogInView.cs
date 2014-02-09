namespace PivotalTurtle.Auth
{
	public interface ILogInView : IView
	{
		string Token { get; set; }
	}
}
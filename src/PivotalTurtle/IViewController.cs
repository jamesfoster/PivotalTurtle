namespace PivotalTurtle
{
	public interface IViewController<out TView>
		where TView : IView
	{
		TView View { get; }
	}
}
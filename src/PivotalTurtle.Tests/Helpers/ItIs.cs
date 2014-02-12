namespace PivotalTurtle.Tests.Helpers
{
	using DeepEqual.Syntax;
	using Moq;

	public static class ItIs
	{
		public static T DeepEqualTo<T>(T expected)
		{
			return Match<T>.Create(x =>
			{
				x.ShouldDeepEqual(expected);
				return true;
			}, () => DeepEqualTo(expected));
		}
	}
}
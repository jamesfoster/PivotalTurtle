namespace PivotalTurtle.Tests.Helpers
{
	using System.Collections;
	using Xunit.Sdk;

	public static class ShouldExtensions
	{
		public static void ShouldBeNullOrEmpty(this IEnumerable source)
		{
			if (source == null) return;

			foreach (var x in source)
			{
				throw new AssertException("Expected null or empty list. Found at least one item");
			}
		}
	}
}
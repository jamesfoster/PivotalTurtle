namespace PivotalTurtle
{
	public class Story
	{
		public long Id { get; set; }
		public string Name { get; set; }
		public long ProjectId { get; set; }
		public StoryState State { get; set; }
	}
}
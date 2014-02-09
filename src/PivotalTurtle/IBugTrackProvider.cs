namespace PivotalTurtle
{
	using System.Threading.Tasks;

	public interface IBugTrackProvider
	{
		Task<CommitDetails> GetNewCommitMessage(CommitDetails details);
	}
}
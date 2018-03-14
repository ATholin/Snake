namespace Snake
{
	public class Score
	{
		public Score(int score)
		{
			this.score = score;
		}

		public int score { get; private set; }

		public void UpdateScore(int s)
		{
			score += s;
		}
	}
}
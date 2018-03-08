using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
	public class Score
	{
		public Score(int score)
		{
			CurrentScore = score;
		}

		int CurrentScore;

		public int score { get { return CurrentScore; } }

		public void UpdateScore(int s)
		{
			CurrentScore = score;
		}
	}
}

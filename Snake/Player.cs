using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
	public class Player
	{
		public Player(Keys up, Keys down, Keys left, Keys right, Snake snake)
		{
			Up = up;
			Down = down;
			Left = left;
			Right = right;
			Snake = snake;
			direction = Direction.Right;
		}

		Snake Snake;
		Score score = new Score(0);
		public int points { get { return score.score; } }

		public void SetPoints(int points)
		{
			score.UpdateScore(points);
		}

		public Keys Up;
		public Keys Down;
		public Keys Left;
		public Keys Right;
		Direction direction;

		public void MoveSnake()
		{
			Snake.MoveSnake(direction);
		}

		public void ChangeDir(Direction dir)
		{
			if (!IsOppositeDir(dir) && Snake.HasMoved)
			{
				direction = dir;
				Snake.HasMoved = false;
			}
		}

		bool IsOppositeDir(Direction newdir)
		{
			if (direction == Direction.Up && newdir == Direction.Down)
			{
				return true;
			}

			if (direction == Direction.Down && newdir == Direction.Up)
			{
				return true;
			}

			if (direction == Direction.Left && newdir == Direction.Right)
			{
				return true;
			}

			if (direction == Direction.Right && newdir == Direction.Left)
			{
				return true;
			}
			return false;
		}
	}
}

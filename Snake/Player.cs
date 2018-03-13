using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Snake
{
	public class Player: IComparable
	{
		public Player(Keys up, Keys down, Keys left, Keys right, Snake snake)
		{
			Up = up;
			Down = down;
			Left = left;
			Right = right;
			Snake = snake;
			direction = Direction.Down;
		}

		//TODO: SNAKE DIR BUFFER

		Snake Snake;
		public int Counter { get { return Snake.counter; } set { Snake.counter = value; } }
		public int Score { get { return Snake.points; } }
		public Color Color { get { return Snake.SnakeColor; } }

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
			if (!IsOppositeDir(dir))
			{
				direction = dir;
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

		public int CompareTo(object obj)
		{
			if (obj == null) return 1;

			Player otherTemperature = obj as Player;
			if (otherTemperature != null)
				return this.Score.CompareTo(otherTemperature.Score);
			else
				throw new ArgumentException("Object is not a Player");
		}
	}
}

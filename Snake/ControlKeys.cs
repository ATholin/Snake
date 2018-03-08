using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
	public class ControlKeys
	{
		public ControlKeys(Keys up, Keys down, Keys left, Keys right, Snake snake)
		{
			Up = up;
			Down = down;
			Left = left;
			Right = right;
			Snake = snake;
<<<<<<< HEAD
=======
			direction = Direction.Right;
>>>>>>> 371065194639246aedc29c9d08d31bc1eccd41d3
		}

		Snake Snake;

		public Keys Up;
		public Keys Down;
		public Keys Left;
		public Keys Right;
<<<<<<< HEAD

		public void MoveSnake()
		{
			Snake.MoveSnake();
=======
		Direction direction;

		public void MoveSnake()
		{
			Snake.MoveSnake(direction);
>>>>>>> 371065194639246aedc29c9d08d31bc1eccd41d3
		}

		public void ChangeDir(Direction dir)
		{
<<<<<<< HEAD
			Snake.direction = dir;
=======
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
>>>>>>> 371065194639246aedc29c9d08d31bc1eccd41d3
		}
	}
}

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
		}

		Snake Snake;

		public Keys Up;
		public Keys Down;
		public Keys Left;
		public Keys Right;

		public void MoveSnake()
		{
			Snake.MoveSnake();
		}

		public void ChangeDir(Direction dir)
		{
			Snake.direction = dir;
		}
	}
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Snake.Interface;

namespace Snake
{
	public class Snake : ICollidable
	{
		public Snake(int x, int y, int size)
		{
			brush = new SolidBrush(Color.White);

			SnakeBody = new Rectangle[3];

			X = x;
			Y = y;
			SnakeSize = size;

			for (int i = 0; i < SnakeBody.Length; i++)
			{
				SnakeBody[i] = new Rectangle(X, Y, SnakeSize, SnakeSize);
				X += SnakeSize;
			}
		}

<<<<<<< HEAD
=======
		public bool HasMoved;
>>>>>>> 371065194639246aedc29c9d08d31bc1eccd41d3
		Rectangle[] SnakeBody;
		SolidBrush brush;
		public Rectangle[] Snakebody => SnakeBody;
		int X, Y, SnakeSize;

		public void Draw(Graphics g)
		{
			for (int i = 0; i < SnakeBody.Length; i++)
			{
				g.FillRectangle(brush, SnakeBody[i]);
			}
		}

		public bool Intersects(Rectangle[] enemysnek)
		{
			foreach(var snekpart in enemysnek)
			{
				if (SnakeBody[0].IntersectsWith(snekpart) && SnakeBody[0] != snekpart)
				{
					return true;
				}
			}
			return false;
		}

		public void OnCollision(object obj)
		{
			throw new NotImplementedException();
		}

		public void MoveSnake(Direction direction)
		{
			for (int i = SnakeBody.Length - 1; i > 0; i--)
			{

				SnakeBody[i] = SnakeBody[i - 1];
			}

			switch (direction)
			{
				case Direction.Up:
					SnakeBody[0].Y -= SnakeSize;
					Y -= SnakeSize;
					break;
				case Direction.Down:
					SnakeBody[0].Y += SnakeSize;
					Y += SnakeSize;
					break;
				case Direction.Left:
					SnakeBody[0].X -= SnakeSize;
					X -= SnakeSize;
					break;
				case Direction.Right:
					SnakeBody[0].X += SnakeSize;
					X += SnakeSize;
					break;
			}
		}
	}
}
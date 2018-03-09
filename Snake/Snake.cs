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
		public Snake()
		{
			brush = new SolidBrush(Color.White);

			SnakeBody = new Rectangle[20];

			X = 20;
			Y = 20;
			SnakeSize = 20;

			for (int i = 0; i < SnakeBody.Length; i++)
			{
				SnakeBody[i] = new Rectangle(X, Y, SnakeSize, SnakeSize);
				X += SnakeSize;
			}
		}

		public bool HasMoved;
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
				if (SnakeBody[0].Location.Equals(snekpart.Location) && !SnakeBody[0].Equals(snekpart))
				{
					return true;
				}
			}
			return false;
		}

		public void OnCollision(object obj)
		{
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
					break;
				case Direction.Down:
					SnakeBody[0].Y += SnakeSize;
					break;
				case Direction.Left:
					SnakeBody[0].X -= SnakeSize;
					break;
				case Direction.Right:
					SnakeBody[0].X += SnakeSize;
					break;
			}
		}
	}
}
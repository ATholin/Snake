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

			SnakeBody = new Rectangle[10];

			X = 20;
			Y = 20;
			Width = 20;
			Height = 20;

			for (int i = 0; i < SnakeBody.Length; i++)
			{
				SnakeBody[i] = new Rectangle(X, Y, Width, Height);
				X += 20;
			}
		}

		

		public bool HasMoved;
		Rectangle[] SnakeBody;
		SolidBrush brush;
		public Rectangle[] Snakebody => SnakeBody;
		int X, Y, Width, Height;

		int lastX, lastY;

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

			lastY = Y;
			lastX = X;

			switch (direction)
			{
				case Direction.Up:
					SnakeBody[0].Y -= 20;
					Y -= 20;
					break;
				case Direction.Down:
					SnakeBody[0].Y += 20;
					Y += 20;
					break;
				case Direction.Left:
					SnakeBody[0].X -= 20;
					X -= 20;
					break;
				case Direction.Right:
					SnakeBody[0].X += 20;
					X += 20;
					break;
			}
		}
	}
}
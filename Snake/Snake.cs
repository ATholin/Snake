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
			pen = new Pen(Color.White);

			SnakeBody = new Rectangle[3];

			X = 20;
			Y = 20;
			Width = 20;
			Height = 20;
			direction = Direction.Right;

			for (int i = 0; i < SnakeBody.Length; i++)
			{
				SnakeBody[i] = new Rectangle(X, Y, Width, Height);
				X += 20;
			}
		}

		ControlKeys controls;
		Rectangle[] SnakeBody;
		Pen pen;
		public Rectangle[] Snakebody => SnakeBody;
		int X, Y, Width, Height;
		public Direction direction;

		public void Draw(Graphics g)
		{
			g.TranslateTransform(200, 0);
			for (int i = 0; i < SnakeBody.Length; i++)
			{
				g.DrawRectangle(pen, SnakeBody[i]);
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

		public void MoveSnake()
		{
			for (int i = SnakeBody.Length - 1; i > 0; i--)
			{

				SnakeBody[i] = SnakeBody[i - 1];
			}
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
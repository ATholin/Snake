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
		public Snake(int x, int y, Color color)
		{
			brush = new SolidBrush(Color.White);

			SnakeBody = new Rectangle[10];

			X = x;
			Y = y;
			brush.Color = color;
			SnakeSize = 20;

			for (int i = SnakeBody.Length-1; i >= 0; i--)
			{
				SnakeBody[i] = new Rectangle(X, Y, SnakeSize, SnakeSize);
				X += SnakeSize;
			}
		}

		public bool HasMoved;
		Rectangle[] SnakeBody;
		SolidBrush brush;

		public Color SnakeColor { get { return brush.Color; } }
		public Rectangle[] Snakebody => SnakeBody;

		int X, Y, SnakeSize;

		public void Draw(Graphics g)
		{
			for (int i = 0; i < SnakeBody.Length; i++)
			{
				g.FillRectangle(brush, SnakeBody[i]);
			}
		}

		public bool Intersects(Snake enemysnek)
		{
			if (SnakeColor == enemysnek.SnakeColor)
			{
				for (int i = 1; i < Snakebody.Length; i++)
				{
					if (Snakebody[0].IntersectsWith(Snakebody[i]))
					{
						return true;
					}
				}
			}
			else
			{
				foreach (var snakepart in enemysnek.Snakebody)
				{
					if (Snakebody[0].IntersectsWith(snakepart))
					{
						enemysnek.OnCollision();
						return true;
					}
				}
			}
			return false;
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

		public void OnCollision(Snake snek)
		{
			//Check if snek.color != color
				//Add5pts
		}
	}
}
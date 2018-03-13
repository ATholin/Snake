using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Snake.Interface;

namespace Snake
{
	public abstract class Food : ICollidable
	{
		public Food(int x, int y)
		{
			X = x;
			Y = y;
		}

		public SolidBrush brush;
		public int X { get; private set; }
		public int Y { get; private set; }
		public Point Piece { get { return new Point(X, Y); } }

		public void Draw(Graphics g)
        {
			g.FillRectangle(brush, X * Settings.Size, Y * Settings.Size, Settings.Size, Settings.Size);
		}

		public bool Intersects(Snake snake)
		{
			if (snake.SnakeBody.First.Value == Piece)
			{
				OnCollision(snake);
				return true;
			}
			return false;
		}

		public abstract void OnCollision(Snake snake);
    }

}

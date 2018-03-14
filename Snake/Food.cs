using System.Drawing;
using Snake.Interface;

namespace Snake
{
	public abstract class Food : ICollidable
	{
		protected SolidBrush brush;

		protected Food(int x, int y)
		{
			X = x;
			Y = y;
		}

		public int X { get; }
		public int Y { get; }
		private Point Piece => new Point(X, Y);

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
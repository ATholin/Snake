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
		Rectangle FoodPiece;
		SolidBrush brush;
		public int X {get { return FoodPiece.X; } }
		public int Y { get { return FoodPiece.Y; } }

		public static void Init(Food f, int X, int Y, int size)
		{
			f.brush = new SolidBrush(Color.White);
			f.FoodPiece = new Rectangle(X, Y, size, size);
		}

		public void Draw(Graphics g)
        {
			g.FillRectangle(brush, FoodPiece);
		}

		public bool Intersects(Snake snake)
		{
			if (snake.Snakebody[0].IntersectsWith(this.FoodPiece))
			{
				OnCollision(snake);
				return true;
			}
			return false;
		}

		public abstract void OnCollision(Snake snake);
    }

}

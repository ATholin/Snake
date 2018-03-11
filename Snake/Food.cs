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
		public Food(Rectangle rect)
		{
			FoodPiece = rect;
			brush = new SolidBrush(Color.Yellow);
		}

		public Food(int x, int y, int size) : this(new Rectangle(x, y, size, size)) { }

		Rectangle FoodPiece;
		SolidBrush brush;
		public int X {get { return FoodPiece.X; } }
		public int Y { get { return FoodPiece.Y; } }
		public Rectangle Piece { get { return FoodPiece; } }

		/*
		public static void Init(Food f, int X, int Y, int size)
		{
			f.brush = new SolidBrush(Color.White);
			f.FoodPiece = new Rectangle(X, Y, size, size);
		}
		*/

		public void Draw(Graphics g)
        {
			g.FillRectangle(brush, FoodPiece);
		}

		public bool Intersects(Snake snake)
		{
			if (snake.SnakeHead.IntersectsWith(this.FoodPiece))
			{
				OnCollision(snake);
				return true;
			}
			return false;
		}

		public abstract void OnCollision(Snake snake);
    }

}

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

			SnakeBody = new LinkedList<Point>();

			brush.Color = color;

			for (int i = 0; i < 3; i++)
			{
				SnakeBody.AddFirst(new Point(x, y));
				y += 1;
			}
		}


		public int counter = 0;
		Score score = new Score(0);
		public int points { get { return score.score; } }

		public LinkedList<Point> SnakeBody { get; private set; }
		SolidBrush brush;

		public Color SnakeColor { get { return brush.Color; } }

		public Rectangle SnakeHeadRect { get { return new Rectangle(SnakeBody.First.Value.X, SnakeBody.First.Value.Y, Settings.Size, Settings.Size); } }

		public void Draw(Graphics g)
		{
			foreach(var snakepart in SnakeBody)
			{
				g.FillRectangle(brush, snakepart.X*Settings.Size, snakepart.Y*Settings.Size, Settings.Size, Settings.Size);
			}
		}

		public bool Intersects(Snake enemysnek)
		{
			if (SnakeColor == enemysnek.SnakeColor)
			{
				var node = SnakeBody.First.Next;

				while(node != null)
				{
					if (SnakeBody.First.Equals(node.Value))
					{
						return true;
					}
					node = node.Next;
				}
			}
			else
			{
				var node = enemysnek.SnakeBody.First;

				while (node != null)
				{
					if (SnakeBody.First.Equals(node.Value))
					{
						enemysnek.OnCollision(this);
						return true;
					}
					node = node.Next;
				}
			}
			return false;
		}

		public void MoveSnake(Direction direction)
		{
			var node = SnakeBody.Last;

			while (node != null)
			{
				if (node.Previous != null)
				{
					node.Value = node.Previous.Value;
				}
				node = node.Previous;
			}

			switch (direction)
			{
				case Direction.Up:
					SnakeBody.First.Value = new Point(SnakeBody.First.Value.X, SnakeBody.First.Value.Y - 1);
					break;
				case Direction.Down:
					SnakeBody.First.Value = new Point(SnakeBody.First.Value.X, SnakeBody.First.Value.Y + 1);
					break;
				case Direction.Left:
					SnakeBody.First.Value = new Point(SnakeBody.First.Value.X - 1, SnakeBody.First.Value.Y);
					break;
				case Direction.Right:
					SnakeBody.First.Value = new Point(SnakeBody.First.Value.X + 1, SnakeBody.First.Value.Y);
					break;
			}
		}

		public void OnCollision(Snake snake)
		{
			AddPoints(5);
		}

		public void Grow(int points) // ;)
		{
			SnakeBody.AddLast(new Point(SnakeBody.Last.Value.X, SnakeBody.Last.Value.Y));
			AddPoints(points);
		}

		public void AddPoints(int points)
		{
			score.UpdateScore(points);
		}
	}
}
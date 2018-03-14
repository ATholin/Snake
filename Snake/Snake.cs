using System.Collections.Generic;
using System.Drawing;
using Snake.Interface;

namespace Snake
{
	public class Snake : ICollidable
	{
		private readonly SolidBrush _brush;
		private readonly Score _score = new Score(0);

		public int Counter;

		public Direction LastDir;

		public Snake(int x, int y, Color color)
		{
			_brush = new SolidBrush(Color.White);

			SnakeBody = new LinkedList<Point>();

			_brush.Color = color;

			for (var i = 0; i < 3; i++)
			{
				SnakeBody.AddFirst(new Point(x, y));
				y += 1;
			}
		}

		public int Points => _score.score;

		public LinkedList<Point> SnakeBody { get; }

		public Color SnakeColor => _brush.Color;

		public Rectangle SnakeHeadRect =>
			new Rectangle(SnakeBody.First.Value.X, SnakeBody.First.Value.Y, Settings.Size, Settings.Size);

		public void Draw(Graphics g)
		{
			foreach (var snakepart in SnakeBody)
				g.FillRectangle(_brush, snakepart.X * Settings.Size, snakepart.Y * Settings.Size, Settings.Size, Settings.Size);
		}

		public bool Intersects(Snake enemysnek)
		{
			if (SnakeColor == enemysnek.SnakeColor)
			{
				var node = SnakeBody.First.Next;

				while (node != null)
				{
					if (SnakeBody.First.Value.Equals(node.Value)) return true;
					node = node.Next;
				}
			}
			else
			{
				var node = enemysnek.SnakeBody.First;

				while (node != null)
				{
					if (SnakeBody.First.Value.Equals(node.Value))
					{
						enemysnek.OnCollision(this);
						return true;
					}

					node = node.Next;
				}
			}

			return false;
		}

		public void OnCollision(Snake snake)
		{
			AddPoints(5);
		}

		public void MoveSnake(Direction direction)
		{
			var node = SnakeBody.Last;

			while (node != null)
			{
				if (node.Previous != null) node.Value = node.Previous.Value;
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

			LastDir = direction;
		}

		public void Grow(int points) // ;)
		{
			SnakeBody.AddLast(new Point(SnakeBody.Last.Value.X, SnakeBody.Last.Value.Y));
			AddPoints(points);
		}

		public void DoubleGrow(int points) // ;)
		{
			SnakeBody.AddLast(new Point(SnakeBody.Last.Value.X, SnakeBody.Last.Value.Y));
			SnakeBody.AddLast(new Point(SnakeBody.Last.Value.X, SnakeBody.Last.Value.Y));
			AddPoints(points);
		}

		public void SpeedUp()
		{
			Counter = 1000 / Settings.FPS * 10;
		}

		public void AddPoints(int points)
		{
			_score.UpdateScore(points);
		}
	}
}
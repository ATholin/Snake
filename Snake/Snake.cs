﻿using System;
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

			SnakeBody = new LinkedList<Rectangle>();

			X = x;
			Y = y;
			brush.Color = color;
			SnakeSize = 20;

			for (int i = 0; i < 10; i++)
			{
				SnakeBody.AddFirst(new Rectangle(X, Y, SnakeSize, SnakeSize));
				X += 20;
			}
		}


		Score score = new Score(0);
		public int points { get { return score.score; } }

		public bool HasMoved;
		LinkedList<Rectangle> SnakeBody;
		SolidBrush brush;

		public Color SnakeColor { get { return brush.Color; } }
		public Rectangle[] Snakebody { get
			{
				Rectangle[] badabing = new Rectangle[SnakeBody.Count];
				SnakeBody.CopyTo(badabing, 0);
				var badaboom = badabing;
				return badaboom;
			}
		}

		int X, Y, SnakeSize;

		public void Draw(Graphics g)
		{
			foreach(var snakepart in SnakeBody)
			{
				g.FillRectangle(brush, snakepart);
			}
		}

		public bool Intersects(Snake enemysnek)
		{
			if (SnakeColor == enemysnek.SnakeColor)
			{
				var node = SnakeBody.First.Next;

				while(node != null)
				{
					if (SnakeBody.First.Value.IntersectsWith(node.Value))
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
					if (SnakeBody.First.Value.IntersectsWith(node.Value))
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
					SnakeBody.First.Value = new Rectangle(SnakeBody.First.Value.X, SnakeBody.First.Value.Y - SnakeSize, SnakeSize, SnakeSize);
					Y -= SnakeSize;
					break;
				case Direction.Down:
					SnakeBody.First.Value = new Rectangle(SnakeBody.First.Value.X, SnakeBody.First.Value.Y + SnakeSize, SnakeSize, SnakeSize);
					Y += SnakeSize;
					break;
				case Direction.Left:
					SnakeBody.First.Value = new Rectangle(SnakeBody.First.Value.X - SnakeSize, SnakeBody.First.Value.Y, SnakeSize, SnakeSize);
					X -= SnakeSize;
					break;
				case Direction.Right:
					SnakeBody.First.Value = new Rectangle(SnakeBody.First.Value.X + SnakeSize, SnakeBody.First.Value.Y, SnakeSize, SnakeSize);
					X += SnakeSize;
					break;
			}
		}

		public void OnCollision(Snake snake)
		{
			AddPoints(5);
		}

		public void Grow(int points) // ;)
		{
			SnakeBody.AddLast(new Rectangle(SnakeBody.Last.Value.X, SnakeBody.Last.Value.Y, SnakeSize, SnakeSize));
			AddPoints(points);
		}

		public void AddPoints(int points)
		{
			score.UpdateScore(points);
		}
	}
}
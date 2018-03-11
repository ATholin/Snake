using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Snake.Interface;

namespace Snake
{
	class Collider
	{
		ICollidable[,] CollisionMatrix;
		int Width, Height;

		public Collider(int width, int height)
		{
			CollisionMatrix = new ICollidable[width, height];
			Width = width;
			Height = height;
			Clear();
		}

		public void Clear()
		{
			for (var x = 0; x < Width; x++)
			{
				for (var y = 0; y < Height; y++)
				{
					CollisionMatrix[x, y] = null;
				}
			}
		}

		public void Collide(Snake snek)
		{
			if (CollisionMatrix[snek.Snakebody[0].X, snek.Snakebody[0].Y] != null)
			{
				CollisionMatrix[snek.Snakebody[0].X, snek.Snakebody[0].Y].OnCollision(snek);
			}
			foreach(var s in snek.Snakebody)
			{
				CollisionMatrix[s.X, s.Y] = snek;
			}
		}

		public void Collide(Food food)
		{
			CollisionMatrix[food.X, food.Y] = food;
		}
	}
}

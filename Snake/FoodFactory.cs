using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Snake
{
	class FoodFactory
	{
		GameBoard Game;
		Random rand = new Random();
		int[,] Occupied;

		public FoodFactory(GameBoard game)
		{
			Game = game;
			Occupied = new int[Game.Width / Settings.Size, Game.Height / Settings.Size];
		}

		public void Reset()
		{
			for(int x = 0; x < Game.Width/Settings.Size; x++)
			{
				for (int y = 0; y< Game.Height/Settings.Size;y++)
				{
					Occupied[x/Settings.Size, y/Settings.Size] = 0;
				}
			}
		}

		public void Update()
		{
			Reset();

			foreach(var snake in Game.Snakes)
			{
				foreach(var snakepart in snake.SnakeBody)
				{
					Occupied[snakepart.X / Settings.Size, snakepart.Y / Settings.Size] = 1;
				}
			}

			foreach(var food in Game.Foods)
			{
				Occupied[food.X / Settings.Size, food.Y / Settings.Size] = 1;
			}
		}

		public Rectangle GetAvailableSpot()
		{
			Update();

			int randX = rand.Next(0, Game.Width / Settings.Size);
			int randY = rand.Next(0, Game.Height / Settings.Size);

			if (Occupied[randX, randY] == 0)
				return new Rectangle(randX, randY, Settings.Size, Settings.Size);

			while (Occupied[randX, randY] == 1)
			{
				randX += Settings.Size;
				if (randX > Game.Width / Settings.Size)
				{
					randX = 0;
					randY += Settings.Size;
				}
			}
			return new Rectangle(randX, randY, Settings.Size, Settings.Size);
		}
	}
}

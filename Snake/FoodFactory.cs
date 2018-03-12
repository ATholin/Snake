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
		GameBoard game;
		Random rand = new Random();
		int[,] Occupied;

		public FoodFactory(GameBoard game)
		{
			this.game = game;
			Occupied = new int[Settings.Size, Settings.Size];
		}

		public void Reset()
		{
			for(int x = 0; x < Settings.Size; x++)
			{
				for (int y = 0; y < Settings.Size; y++)
				{
					Occupied[x, y] = 0;
				}
			}
		}

		public void Update()
		{
			Reset();

			foreach(var snake in game.Snakes)
			{
				foreach(var snakepart in snake.SnakeBody)
				{
					Occupied[snakepart.X, snakepart.Y] = 1;
				}
			}

			foreach(var food in game.Foods)
			{
				Occupied[food.X, food.Y] = 1;
			}
		}

		public Point GetAvailableSpot()
		{
			Update();

			int randX = rand.Next(0, Settings.Size);
			int randY = rand.Next(0, Settings.Size);

			if (Occupied[randX, randY] == 0)
				return new Point(randX, randY);

			while (Occupied[randX, randY] == 1)
			{
				randX += 1;
				if (randX > game.Width)
				{
					randX = 0;
					randY += 1;
				}
			}
			return new Point(randX, randY);
		}

		public Food SpawnFood()
		{
			var generate = rand.Next(0, 100);

			if (generate < 20)
			{
				if (generate< 5)
				{
					//return new SpeedFood();
				}
				//return new RareFood()
			}
			var foodpoint = GetAvailableSpot();
			return new NormalFood(foodpoint.X, foodpoint.Y);
		}

		public void InitFood()
		{
			for (int i = 0; i < 5; i++)
			{
				game.Add(SpawnFood());
			}
			
		}
	}
}

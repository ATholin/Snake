using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

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
			Occupied = new int[Settings.Dimension, Settings.Dimension];
		}

		public void Reset()
		{
			for(int x = 0; x < Settings.Dimension; x++)
			{
				for (int y = 0; y < Settings.Dimension; y++)
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

			int randX = rand.Next(0, Settings.Dimension-1);
			int randY = rand.Next(0, Settings.Dimension-1);

			if (Occupied[randX, randY] == 0)
				return new Point(randX, randY);

			int x = 0;
			int y = 0;

			for (;x < Settings.Dimension; x++)
			{
				for (;y < Settings.Dimension; y++)
				{
					if (Occupied[x,y] == 1)
					{
						continue;
					}
				}
			}

			return new Point(x, y);
		}

		public Food SpawnFood()
		{
			var generate = rand.Next(0, 100);
			var foodpoint = GetAvailableSpot();

			if (generate < 20)
			{
				if (generate< 5)
				{
					return new SpeedFood(game, foodpoint.X, foodpoint.Y);
				}
				return new RareFood(foodpoint.X, foodpoint.Y);
			}
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

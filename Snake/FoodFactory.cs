using System;
using System.Drawing;

namespace Snake
{
	// Handles food spawning and board matrix for available spots
	internal class FoodFactory
	{
		private readonly GameBoard _game;
		private readonly int[,] _occupied;
		private readonly Random _random = new Random();

		public FoodFactory(GameBoard game)
		{
			_game = game;
			_occupied = new int[Settings.Dimension, Settings.Dimension];
		}

		private void Reset()
		{
			for (var x = 0; x < Settings.Dimension; x++)
			for (var y = 0; y < Settings.Dimension; y++)
				_occupied[x, y] = 0;
		}

		private void Update()
		{
			Reset();

			foreach (var snake in _game.Snakes)
			foreach (var snakepart in snake.SnakeBody)
				_occupied[snakepart.X, snakepart.Y] = 1;

			foreach (var food in _game.Foods) _occupied[food.X, food.Y] = 1;
		}

		// Pick a random spot, and iterate through the matrix until we are at the initial spot again, or we find an unoccupied spot.
		private Point GetAvailableSpot()
		{
			Update();

			var randX = _random.Next(0, Settings.Dimension);
			var randY = _random.Next(0, Settings.Dimension);
			var placeschecked = 0;

			while (_occupied[randX, randY] == 1)
			{
				//If we checked Dimension^2, then all of the spots are occupied, and the game is over.
				if (++placeschecked == Math.Pow(Settings.Dimension, 2)) return new Point(-1, -1);

				randX++;
				if (randX == Settings.Dimension)
				{
					randX = 0;
					randY++;
					if (randY == Settings.Dimension) randY = 0;
				}
			}

			return new Point(randX, randY);
		}

		// Spawns a random food.
		// 80% that it is a NormalFood
		// 15% that it is a RareFood
		// 5% that it is a SpeedFood
		public Food SpawnFood()
		{
			var generate = _random.Next(0, 100);
			var foodpoint = GetAvailableSpot();

			if (generate < 20)
			{
				if (generate < 5) return new SpeedFood(_game, foodpoint.X, foodpoint.Y);
				return new RareFood(foodpoint.X, foodpoint.Y);
			}

			return new NormalFood(foodpoint.X, foodpoint.Y);
		}

		public void InitFood()
		{
			for (var i = 0; i < Settings.MaxFood; i++) _game.Add(SpawnFood());
		}
	}
}
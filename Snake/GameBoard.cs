using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Snake
{
	// The actual game board.
	public class GameBoard : Panel
	{
		public delegate void BoardFullHandler();

		public delegate void ScoreChangedHandler();

		private readonly FoodFactory _foodFactory;
		private readonly ISet<Food> _foodToRemove = new HashSet<Food>();

		private readonly ISet<Snake> _toRemove = new HashSet<Snake>();
		public readonly ISet<Food> Foods = new HashSet<Food>();
		public readonly ISet<Snake> Snakes = new HashSet<Snake>();

		public GameBoard()
		{
			_foodFactory = new FoodFactory(this);
			_foodFactory.InitFood();

			Paint += Draw;
		}

		public Player[] Players { get; private set; }
		public event ScoreChangedHandler ScoreChanged;
		public event BoardFullHandler BoardFull;

		// Add p amount of players.
		// Tested and working for up to 3 players
		// Should support up to 16 players (not tested)
		// TODO: dynamic picking of keys.
		public void AddPlayers(int p)
		{
			Players = new Player[p];

			if (p >= 1)
			{
				var snake1 = new Snake(Settings.Dimension / (p + 1) * 1, 2, Color.Blue);
				var player = new Player(Keys.Up, Keys.Down, Keys.Left, Keys.Right, snake1);
				Players[0] = player;
				Snakes.Add(snake1);
			}

			if (p >= 2)
			{
				var snake2 = new Snake(Settings.Dimension / (p + 1) * 2, 2, Color.Red);
				var player2 = new Player(Keys.W, Keys.S, Keys.A, Keys.D, snake2);
				Players[1] = player2;
				Snakes.Add(snake2);
			}

			if (p >= 3)
			{
				var snake3 = new Snake(Settings.Dimension / (p + 1) * 3, 2, Color.Green);
				var player3 = new Player(Keys.I, Keys.K, Keys.J, Keys.L, snake3);
				Players[2] = player3;
				Snakes.Add(snake3);
			}
		}

		public void Tick()
		{
			// Move snake every other tick
			// If snake has eaten SpeedUp Food -> Move snake every tick for 10 seconds
			foreach (var p in Players)
				if (p.IsAlive)
					if (p.Counter > 0)
					{
						p.MoveSnake();
						p.Counter--;
					}
					else
					{
						p.Counter = 1;
					}

			// Check collision with walls, snakes and food.
			foreach (var snek in Snakes)
			{
				if (snek.SnakeBody.First.Value.X >= Settings.Dimension || snek.SnakeBody.First.Value.X < 0 ||
				    snek.SnakeBody.First.Value.Y >= Settings.Dimension || snek.SnakeBody.First.Value.Y < 0) _toRemove.Add(snek);


				foreach (var enemysnek in Snakes)
					if (snek.Intersects(enemysnek))
					{
						// Can not remove while enumerating, add to additional array and remove after enumerating
						_toRemove.Add(snek);
						ScoreChanged?.Invoke();
					}

				foreach (var food in Foods)
					if (food.Intersects(snek))
					{
						// Can not remove while enumerating, add to additional array and remove after enumerating
						_foodToRemove.Add(food);
						ScoreChanged?.Invoke();
					}
			}

			RemoveObjects();
		}

		private void SpawnFood()
		{
			var food = _foodFactory.SpawnFood();
			if (food.X == -1 && food.Y == -1)
				BoardFull?.Invoke();
			Add(food);
		}

		private void Draw(object sender, PaintEventArgs e)
		{
			var p = sender as Panel;
			e.Graphics.FillRectangle(new SolidBrush(Color.Black), p.DisplayRectangle);
			foreach (var s in Snakes) s.Draw(e.Graphics);
			foreach (var f in Foods) f.Draw(e.Graphics);
		}

		internal void ChangeDirection(Direction dir, int index)
		{
			Players[index].ChangeDir(dir);
		}


		public void Add(Food food)
		{
			Foods.Add(food);
		}

		// Enumerate arrays, remove them from Snakes and Foods array
		// For each food removed, spawn new food.
		private void RemoveObjects()
		{
			foreach (var s in _toRemove) Snakes.Remove(s);
			foreach (var f in _foodToRemove)
			{
				Foods.Remove(f);
				SpawnFood();
			}

			_foodToRemove.Clear();
			_toRemove.Clear();
		}
	}
}
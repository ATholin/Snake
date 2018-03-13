using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Snake.Interface;
using System.Drawing;

namespace Snake
{
    public class GameBoard : Panel
    {
		Dictionary<Keys, int> KeyIndex;

		public ISet<Snake> Snakes = new HashSet<Snake>();
		public ISet<Snake> ToRemove = new HashSet<Snake>();
		public ISet<Food> Foods = new HashSet<Food>();
		public ISet<Food> FoodToRemove = new HashSet<Food>();

		FoodFactory foodFactory;

		public Player[] Players { get; protected set; }

		public delegate void ScoreChangedHandler();
		public event ScoreChangedHandler ScoreChanged;

		public GameBoard()
		{
			foodFactory = new FoodFactory(this);
			foodFactory.InitFood();

			Paint += new PaintEventHandler(Draw);
		}

		public void AddPlayers(int p)
		{
			Players = new Player[p];
			KeyIndex = new Dictionary<Keys, int>(p);

			if (p >= 1)
			{
				var snake1 = new Snake(Settings.Dimension / (p+1) * 1, 2, Color.Blue);
				var player = new Player(Keys.Up, Keys.Down, Keys.Left, Keys.Right, snake1);
				Players[0] = player;
				Snakes.Add(snake1);
				KeyIndex.Add(Keys.Up, 0);
				KeyIndex.Add(Keys.Down, 0);
				KeyIndex.Add(Keys.Left, 0);
				KeyIndex.Add(Keys.Right, 0);
			}
			if (p >= 2)
			{
				var snake2 = new Snake(Settings.Dimension / (p+1) * 2, 2, Color.Red);
				var player2 = new Player(Keys.W, Keys.S, Keys.A, Keys.D, snake2);
				Players[1] = player2;
				Snakes.Add(snake2);
				KeyIndex.Add(Keys.W, 1);
				KeyIndex.Add(Keys.S, 1);
				KeyIndex.Add(Keys.A, 1);
				KeyIndex.Add(Keys.D, 1);
			}
			if (p >= 3)
			{
				var snake3 = new Snake(Settings.Dimension / (p+1) * 3, 2, Color.Green);
				var player3 = new Player(Keys.I, Keys.K, Keys.J, Keys.L, snake3);
				Players[2] = player3;
				Snakes.Add(snake3);
			}
		}

		public void Tick()
		{
			foreach (var p in Players)
			{
				if (p.Counter > 0)
				{
					p.MoveSnake();
					p.Counter--;
				}
				else
				{
					p.Counter = 1;
				}
				
			}

			foreach(var snek in Snakes)
			{
				if (snek.SnakeBody.First.Value.X >= Settings.Dimension || snek.SnakeBody.First.Value.X < 0 || snek.SnakeBody.First.Value.Y >= Settings.Dimension || snek.SnakeBody.First.Value.Y < 0)
				{
					ToRemove.Add(snek);
				}

				
				foreach (var enemysnek in Snakes)
				{
					if (snek.Intersects(enemysnek))
					{
						ToRemove.Add(snek);
						ScoreChanged?.Invoke();
					}
				}

				foreach (var food in Foods)
				{
					if (food.Intersects(snek))
					{
						FoodToRemove.Add(food);
						ScoreChanged.Invoke();
					}
				}
			}

			RemoveObjects();
		}

		private void SpawnFood()
		{
			Add(foodFactory.SpawnFood());

		}

		private void Draw(object sender, PaintEventArgs e)
		{
			var p = sender as Panel;
			e.Graphics.FillRectangle(new SolidBrush(Color.Black), p.DisplayRectangle);
			foreach (var s in Snakes)
			{
				s.Draw(e.Graphics);
			}
			foreach(var f in Foods)
			{
				f.Draw(e.Graphics);
			}
		}

		internal void ChangeDirection(Direction dir, int index)
		{
			Players[index].ChangeDir(dir);
		}


		public void Add(Food food)
		{
			Foods.Add(food);
		}

		public void RemoveObjects()
		{
			foreach(var s in ToRemove)
			{
				Snakes.Remove(s);
			}
			foreach(var f in FoodToRemove)
			{
				Foods.Remove(f);
				SpawnFood();

			}

			FoodToRemove.Clear();
			ToRemove.Clear();
		}
	}
}

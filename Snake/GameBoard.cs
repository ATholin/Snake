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
		Dictionary<Keys, Player> players;

		public ISet<Snake> Snakes = new HashSet<Snake>();
		public ISet<Snake> ToRemove = new HashSet<Snake>();
		public ISet<Food> Foods = new HashSet<Food>();
		public ISet<Food> FoodToRemove = new HashSet<Food>();

		FoodFactory foodFactory;

		public Player[] Players { get
			{
				Player[] p = new Player[players.Count];
				int index = 0;
				foreach(var player in players)
				{
					p[index++] = player.Value;
				}
				return p;
			}
		}

		public delegate void ScoreChangedHandler();
		public event ScoreChangedHandler ScoreChanged;

		public GameBoard(Size size, int players)
		{
			Height = 600;
			Width = 600;
			Size = size;

			foodFactory = new FoodFactory(this);
			foodFactory.InitFood();

			this.players = new Dictionary<Keys, Player>(players);

			Paint += new PaintEventHandler(Draw);
		}

		public void AddPlayers(int p)
		{

			if (p >= 1)
			{
				var snake1 = new Snake(Settings.Size / 3, 2, Color.Blue);
				var player = new Player(Keys.Up, Keys.Down, Keys.Left, Keys.Right, snake1);
				players.Add(Keys.Up, player);
				players.Add(Keys.Down, player);
				players.Add(Keys.Left, player);
				players.Add(Keys.Right, player);
				Snakes.Add(snake1);
			}
			/*
			if (p >= 2)
			{
				var snake2 = new Snake(Settings.Size / 2, 2, Color.Red);
				var player2 = new Player(Keys.W, Keys.S, Keys.A, Keys.D, snake2);
				players.Add(Keys.W, player2);
				players.Add(Keys.S, player2);
				players.Add(Keys.A, player2);
				players.Add(Keys.D, player2);
				Snakes.Add(snake2);
			}
			if (p >= 3)
			{
				var snake3 = new Snake(Settings.Size / 1, 2, Color.Green);
				players.Add(Keys.I, new Player(Keys.I, Keys.K, Keys.J, Keys.L, snake3));
				players.Add(Keys.K, new Player(Keys.I, Keys.K, Keys.J, Keys.L, snake3));
				players.Add(Keys.J, new Player(Keys.I, Keys.K, Keys.J, Keys.L, snake3));
				players.Add(Keys.L, new Player(Keys.I, Keys.K, Keys.J, Keys.L, snake3));
				Snakes.Add(snake3);
			}
			*/
		}

		public void Tick()
		{
            int index = 0;
			foreach (var p in players.Values)
			{
				if (index++ % 4 != 0)
					continue;
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
				if (snek.SnakeHeadRect.X > (Settings.Size*2) - 1 || snek.SnakeHeadRect.X < 0 || snek.SnakeHeadRect.Y > (Settings.Size*2) - 1 || snek.SnakeHeadRect.Y < 0)
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
						ScoreChanged?.Invoke();
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
		internal void MoveUp(Keys key)
		{
			players[key].ChangeDir(Direction.Up);
		}

		internal void MoveDown(Keys key)
		{
			players[key].ChangeDir(Direction.Down);
		}

		internal void MoveLeft(Keys key)
		{
			players[key].ChangeDir(Direction.Left);
		}

		internal void MoveRight(Keys key)
		{
			players[key].ChangeDir(Direction.Right);
		}

		public void Add(Snake snake)
		{
			Snakes.Add(snake);
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

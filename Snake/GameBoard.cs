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
		int Dimension;

		Snake snake = new Snake(60, 100, Color.Blue);
		Snake snake2 = new Snake(60, 200, Color.Red);
		Snake snake3 = new Snake(60, 300, Color.Green);

		Dictionary<Keys, Player> players;

		public ISet<Snake> Snakes = new HashSet<Snake>();
		public ISet<Snake> ToRemove = new HashSet<Snake>();
		public ISet<Food> Foods = new HashSet<Food>();
		public ISet<Food> FoodToRemove = new HashSet<Food>();

		FoodFactory foodFactory;

		int GridSize;

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

		public GameBoard(int dimension, int players)
		{
			foodFactory = new FoodFactory(this);

			GridSize = dimension;
			Dock = DockStyle.Fill;

			Add(snake);
			Add(snake2);
			Add(snake3);

			this.players = new Dictionary<Keys, Player>(players);

			var player = new Player(Keys.Up, Keys.Down, Keys.Left, Keys.Right, snake);
			this.players.Add(Keys.Up, player);
			this.players.Add(Keys.Down, player);
			this.players.Add(Keys.Left, player);
			this.players.Add(Keys.Right, player);

			var player2 = new Player(Keys.W, Keys.S, Keys.A, Keys.D, snake2);
			this.players.Add(Keys.W, player2);
			this.players.Add(Keys.S, player2);
			this.players.Add(Keys.A, player2);
			this.players.Add(Keys.D, player2);

			var player3 = new Player(Keys.I, Keys.K, Keys.J, Keys.L, snake3);
			this.players.Add(Keys.I, player3);
			this.players.Add(Keys.K, player3);
			this.players.Add(Keys.J, player3);
			this.players.Add(Keys.L, player3);

			//this.players[0] = new Player(Keys.Up, Keys.Down, Keys.Left, Keys.Right, snake);
			//this.players[1] = new Player(Keys.W, Keys.S, Keys.A, Keys.D, snakes[1]);

			Dimension = dimension;
			Paint += new PaintEventHandler(Draw);
		}

		public void Tick()
		{
			SpawnFood();
            int index = 0;
			foreach (var p in players.Values)
			{
				if (index++ % 4 != 0)
					continue;
				p.MoveSnake();
			}

			foreach(var snek in Snakes)
			{
				snek.HasMoved = true;
				if (snek.SnakeHead.X > Width || snek.SnakeHead.X < 0 || snek.SnakeHead.Y > Height || snek.SnakeHead.Y < 0)
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
						SpawnFood();
					}
				}
			}

			RemoveObjects();
		}

		private void SpawnFood()
		{
			Random rand = new Random();

			var foodRect = foodFactory.GetAvailableSpot();

			int generate = rand.Next(0, 1001);

			if (generate <= 50)
            {
				if (generate <= 25)
				{
					if (generate <= 10)
					{
						//Add random snake speed up
					}
					//Add Rare 5pts
				}
				//Add normal
				Add(new NormalFood(foodRect));
				return;
			}
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
			}

			FoodToRemove.Clear();
			ToRemove.Clear();
		}
	}
}

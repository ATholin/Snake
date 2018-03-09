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

		public ISet<Snake> snakes = new HashSet<Snake>();
		public ISet<Snake> toRemove = new HashSet<Snake>();

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
			Dock = DockStyle.Fill;

			snakes.Add(snake);
			snakes.Add(snake2);
			snakes.Add(snake3);

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
			int index = 0;
			foreach (var p in players.Values)
			{
				if (index++ % 4 != 0)
					continue;
				p.MoveSnake();
				
			}

			foreach(var snek in snakes)
			{
				snek.HasMoved = true;
				if (snek.Snakebody[0].X > Width || snek.Snakebody[0].X < 0 || snek.Snakebody[0].Y > Height || snek.Snakebody[0].Y < 0)
				{
					toRemove.Add(snek);
				}

				foreach (var enemysnek in snakes)
				{
					if (snek.SnakeColor == enemysnek.SnakeColor)
					{
						for (int i = 1; i < snek.Snakebody.Length; i++)
						{
							if (snek.Snakebody[0].IntersectsWith(snek.Snakebody[i]))
							{
								toRemove.Add(snek);
							}
						}
					}
					else
					{
						foreach (var snakepart in enemysnek.Snakebody)
						{
							if (snek.Snakebody[0].IntersectsWith(snakepart))
							{
								toRemove.Add(snek);
								enemysnek.OnCollision();
							}
						}
					}
				}
				// Check collision with food here
			}
			foreach(var s in toRemove)
			{
				snakes.Remove(s);
			}
			toRemove.Clear();
		}

		private void Draw(object sender, PaintEventArgs e)
		{
			var p = sender as Panel;
			e.Graphics.FillRectangle(new SolidBrush(Color.Black), p.DisplayRectangle);
			foreach (var s in snakes)
			{
				s.Draw(e.Graphics);
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
	}
}

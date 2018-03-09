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

		Snake snake = new Snake();
		Snake snake2 = new Snake();

		Dictionary<Keys, Player> players;

		public Snake[] snakes = new Snake[2];

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

			snakes[0] = snake;
			snakes[1] = snake2;

			this.players = new Dictionary<Keys, Player>(players);

			var player = new Player(Keys.Up, Keys.Down, Keys.Left, Keys.Right, snake);
			this.players.Add(Keys.Up, player);
			this.players.Add(Keys.Down, player);
			this.players.Add(Keys.Left, player);
			this.players.Add(Keys.Right, player);

			//this.players[0] = new Player(Keys.Up, Keys.Down, Keys.Left, Keys.Right, snake);
			//this.players[1] = new Player(Keys.W, Keys.S, Keys.A, Keys.D, snakes[1]);

			Dimension = dimension;

			Paint += new PaintEventHandler(Draw);
		}

		public void Tick()
		{
			foreach (var p in players)
			{
				p.Value.MoveSnake();
			}

			foreach(var snek in snakes)
			{
				if (snek.Snakebody[0].X > Width || snek.Snakebody[0].X < 0 || snek.Snakebody[0].Y > Height || snek.Snakebody[0].Y < 0)
				{
					snek.OnCollision(null);
				}

				foreach(var enemysnek in snakes)
				{
					if (snek.Intersects(enemysnek.Snakebody))
					{
						snek.OnCollision(enemysnek);
					}
				}
				snek.HasMoved = true;
			}
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

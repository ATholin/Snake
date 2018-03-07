using System;
using System.Collections.Generic;
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
		public GameBoard(int dimension, int players)
		{
            Dock = DockStyle.Fill;

			snakes[snakes.Length] = snake;
			dictionary = new Dictionary<ControlKeys, Snake>(players);
			dictionary.Add(new ControlKeys(Keys.Up, Keys.Down, Keys.Left, Keys.Right), snake);

			Dimension = dimension;

			Paint += new PaintEventHandler(Draw);
			
			timer = new Timer();
			timer.Tick += new EventHandler(TimerEventHandler);
			timer.Interval = 1000 / 5;
			timer.Start();
			
		}

		Timer timer;
		Snake snake = new Snake();

		Dictionary<ControlKeys, Snake> dictionary;

		public Snake[] snakes = new Snake[1];

		int Dimension;

		private void TimerEventHandler(object sender, EventArgs e)
		{
			snake.MoveSnake();
			/*
			foreach(var snek in snakes)
			{
				snek.MoveSnake();
				foreach(var enemysnek in snakes)
				{
					if (snek.Intersects(enemysnek.Snakebody))
					{
						//finish later...
					}
				}
			}
			*/
			Refresh();
		}

		private void Draw(object sender, PaintEventArgs e)
		{
			var p = sender as Panel;
			e.Graphics.FillRectangle(new SolidBrush(Color.Black), p.DisplayRectangle);
			snake.Draw(e.Graphics);
		}

		internal void MoveUp(Keys key)
		{
			foreach (var player in dictionary)
			{
				if (player.Key.Up == key)
				{
					var snek = dictionary[player.Key];
					snek.direction = Direction.Up;
				}
			}
		}

		internal void MoveDown(Keys key)
		{
			foreach (var player in dictionary)
			{
				if (player.Key.Down == key)
				{
					var snek = dictionary[player.Key];
					snek.direction = Direction.Down;
				}
			}
		}

		internal void MoveLeft(Keys key)
		{
			foreach (var player in dictionary)
			{
				if (player.Key.Left == key)
				{
					var snek = dictionary[player.Key];
					snek.direction = Direction.Left;
				}
			}
		}

		internal void MoveRight(Keys key)
		{
			foreach (var player in dictionary)
			{
				if (player.Key.Right == key)
				{
					var snek = dictionary[player.Key];
					snek.direction = Direction.Right;
				}
			}
		}
	}
}

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
		public GameBoard(int dimension, int players)
		{
            Dock = DockStyle.Fill;

			snakes[0] = snake;
			this.players[0] = new ControlKeys(Keys.Up, Keys.Down, Keys.Left, Keys.Right, snake);

			Dimension = dimension;

			Paint += new PaintEventHandler(Draw);
			
			timer = new Timer();
			timer.Tick += new EventHandler(TimerEventHandler);
			timer.Interval = 1000 / 10;
			timer.Start();
			
		}

		int Dimension;
		Timer timer;
		Snake snake = new Snake();

		ControlKeys[] players = new ControlKeys[1];
		public Snake[] snakes = new Snake[1];

		

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
			foreach (var player in players)
			{
				if (player.Up == key)
				{
					player.ChangeDir(Direction.Up);
					player.MoveSnake();
				}
			}
		}

		internal void MoveDown(Keys key)
		{
			foreach (var player in players)
			{
				if (player.Down == key)
				{
					player.ChangeDir(Direction.Down);
					player.MoveSnake();
				}
			}
		}

		internal void MoveLeft(Keys key)
		{
			foreach (var player in players)
			{
				if (player.Left == key)
				{
					player.ChangeDir(Direction.Left);
					player.MoveSnake();
				}
			}
		}

		internal void MoveRight(Keys key)
		{
			foreach (var player in players)
			{
				if (player.Right == key)
				{
					player.ChangeDir(Direction.Right);
					player.MoveSnake();
				}
			}
		}
	}
}

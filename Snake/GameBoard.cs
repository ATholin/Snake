﻿using System;
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
			snakes[1] = snake2;
			this.players[0] = new Player(Keys.Up, Keys.Down, Keys.Left, Keys.Right, snake);
			this.players[1] = new Player(Keys.W, Keys.S, Keys.A, Keys.D, snakes[1]);

			Dimension = dimension;

			Paint += new PaintEventHandler(Draw);
		}

		int Dimension;

		Snake snake = new Snake();
		Snake snake2 = new Snake();

		Player[] players = new Player[2];
		public Snake[] snakes = new Snake[2];

		public Player[] Players { get { return players; } }

		public void Tick()
		{
			players[1].SetPoints(snake.Snakebody[0].X);
			foreach (var p in players)
			{
				p.MoveSnake();
			}
			foreach(var snek in snakes)
			{
				foreach(var enemysnek in snakes)
				{
					if (snek.Intersects(enemysnek.Snakebody))
					{
						snek.OnCollision(enemysnek);
					}
				}
				snek.HasMoved = true;
			}
			Refresh();
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
			foreach (var player in players)
			{
				if (player.Up == key)
				{
						player.ChangeDir(Direction.Up);
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
				}
			}
		}
	}
}

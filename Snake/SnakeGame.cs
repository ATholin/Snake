﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
	public partial class SnakeGame : Form
	{
		public SnakeGame()
		{
			InitializeComponent();

			game = new GameBoard(20, 3);
			Controls.Add(game);

			scorepanel = new ScorePanel(game);
			Controls.Add(scorepanel);

			KeyDown += GameForm_KeyDown;
			KeyPreview = true;

			DoubleBuffered = false;

			timer = new Timer();
			timer.Tick += new EventHandler(TimerEventHandler);
			timer.Interval = 1000 / 10;
			timer.Start();
		}

		private void TimerEventHandler(object sender, EventArgs e)
		{
			game.Tick();
			scorepanel.Refresh();
		}

		Timer timer;
		ScorePanel scorepanel;
		GameBoard game;
		private void GameForm_KeyDown(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				//PLAYER ONE
				case Keys.Up:
					game.MoveUp(e.KeyCode);
					break;
				case Keys.Down:
					game.MoveDown(e.KeyCode);
					break;
				case Keys.Left:
					game.MoveLeft(e.KeyCode);
					break;
				case Keys.Right:
					game.MoveRight(e.KeyCode);
					break;

				//PLAYER TWO
				case Keys.W:
					game.MoveUp(e.KeyCode);
					break;
				case Keys.S:
					game.MoveDown(e.KeyCode);
					break;
				case Keys.A:
					game.MoveLeft(e.KeyCode);
					break;
				case Keys.D:
					game.MoveRight(e.KeyCode);
					break;
			}
		}
	}
}

using System;
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
		Timer timer;
		ScorePanel scorepanel;
		GameBoard game;

		public SnakeGame() : base()
		{
			InitializeComponent();

			var menu = new MainMenu(Width, Height);
			Controls.Add(menu);
			menu.BringToFront();

			menu.StartButtonClicked += Menu_StartButtonClicked;

			KeyDown += GameForm_KeyDown;
			KeyPreview = true;

			DoubleBuffered = false;

			timer = new Timer();
			timer.Tick += new EventHandler(TimerEventHandler);
			timer.Interval = 1000/Settings.FPS;
		}

		private void ResizeWindow()
		{
			
			var smallest = Math.Min(Width, Height - 150);
			smallest -= smallest % Settings.Dimension;
			game.Width = smallest;
			game.Height = smallest;
			Settings.Size = smallest / Settings.Dimension;
			game.Refresh();
		}

		private void Menu_StartButtonClicked(int numplayers)
		{
			game = new GameBoard(3);
			Controls.Add(game);
			ResizeWindow();
			Settings.NumPlayers = numplayers;
			game.AddPlayers(numplayers);
			scorepanel = new ScorePanel(game, Width);
			Controls.Add(scorepanel);
			game.Location = new Point((Width - game.Width) / 2, 0);
			game.ScoreChanged += Game_ScoreChanged;
			timer.Start();
		}

		private void Game_ScoreChanged()
		{
			scorepanel.UpdatePanels();
		}

		private void TimerEventHandler(object sender, EventArgs e)
		{
			game.Tick();
			game.Refresh();
		}

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

				//PLAYER THREE
				case Keys.I:
					game.MoveUp(e.KeyCode);
					break;
				case Keys.K:
					game.MoveDown(e.KeyCode);
					break;
				case Keys.J:
					game.MoveLeft(e.KeyCode);
					break;
				case Keys.L:
					game.MoveRight(e.KeyCode);
					break;
			}
		}
	}
}

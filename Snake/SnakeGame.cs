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

			game = new GameBoard(Size, 3);
			Controls.Add(game);

			Width =1000;
			Height = game.Height + 100;
			game.Location = new Point((Width - game.Width) / 2, 0);

			var menu = new MainMenu(Width, Height);
			Controls.Add(menu);
			menu.BringToFront();

			menu.StartButtonClicked += Menu_StartButtonClicked;

			Resize += SnakeGame_Resize;

			KeyDown += GameForm_KeyDown;
			KeyPreview = true;

			game.ScoreChanged += Game_ScoreChanged;

			DoubleBuffered = false;

			timer = new Timer();
			timer.Tick += new EventHandler(TimerEventHandler);
			timer.Interval = 1000/Settings.FPS;
		}

		private void ResizeWindow()
		{
			game.Location = new Point((Width - game.Width) / 2, 0);
			var smallest = Math.Min(game.Width, game.Height);
			if (smallest > Math.Min(Width, Height))
			{
				game.Width -= Settings.Size;
				game.Height -= Settings.Size;
				Settings.Size -= 1;
			}
			else
			{
				game.Width += Settings.Size;
				game.Height += Settings.Size;
				Settings.Size += 1;
			}
			game.Refresh();
		}

		private void SnakeGame_Resize(object sender, EventArgs e)
		{
			ResizeWindow();
		}

		private void Menu_StartButtonClicked(int numplayers)
		{
			Settings.NumPlayers = numplayers;
			game.AddPlayers(numplayers);
			scorepanel = new ScorePanel(game);
			Controls.Add(scorepanel);
			timer.Start();
		}

		private void Game_ScoreChanged()
		{
			scorepanel.Refresh();
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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
	public partial class SnakeGame : Form
	{
		public static PrivateFontCollection font = new PrivateFontCollection();
		Timer timer;
		int time;
		Label timelabel;
		Timer countdowntimer;
		ScorePanel scorepanel;
		GameBoard game;

		public SnakeGame() : base()
		{
			InitializeComponent();

			font.AddFontFile(@"../../font.ttf");

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
			countdowntimer = new Timer();
			countdowntimer.Interval = 1000;
			countdowntimer.Tick += Countdowntimer_Tick;
			time = 3;
			game.Refresh();
			Countdown();
		}

		private void Countdowntimer_Tick(object sender, EventArgs e)
		{
			if (time > 0)
			{
				time--;
				timelabel.Text = time.ToString();
				Refresh();
			} else
			{
				countdowntimer.Stop();
				timelabel.Visible = false;
				timer.Start();
			}
		}

		private void Countdown()
		{
			timelabel = new Label
			{
				Text = "3",
			};
			timelabel.Location = new Point((game.Width - timelabel.Width) / 2, (game.Width - timelabel.Width) / 2);
			timelabel.Padding = new Padding(5);
			timelabel.AutoSize = true;
			timelabel.ForeColor = Color.Black;
			timelabel.Font = new Font(SnakeGame.font.Families[0], 24);
			Controls.Add(timelabel);
			timelabel.BringToFront();
			countdowntimer.Start();
		}

		private void Game_ScoreChanged()
		{
			scorepanel.UpdatePanels();
		}

		private void TimerEventHandler(object sender, EventArgs e)
		{
			if (!game.Snakes.Count.Equals(0))
			{
				game.Tick();
				game.Refresh();
			} else
			{
				GameOver();
			}
		}

		private void GameOver()
		{
			timer.Stop();
			ShowWinner();
		}

		private void ShowWinner()
		{
			Player winner = game.Players[0];
			int highest = -1;
			int index = 0;
			int windex = 0;

			foreach(var player in game.Players)
			{
				index++;
				if (player.Score > highest)
				{
					highest = player.Score;
					winner = player;
					windex = index;
				}
			}

			var winnerlabel = new Label
			{
				Text = $"Player {windex} Wins!\n{winner.Score} Points",
				Location = new Point(game.Location.X + 50, game.Location.Y + 50)
			};
			winnerlabel.Padding = new Padding(5);
			winnerlabel.AutoSize = true;
			winnerlabel.ForeColor = Color.Black;
			winnerlabel.Font = new Font(SnakeGame.font.Families[0], 42);


			var restartbtn = new SnekButton
			{
				Text = "Restart",
				Location = new Point(winnerlabel.Location.X, winnerlabel.Location.Y + winnerlabel.Height * 6),
				BackColor = Color.White,
				AutoSize = true,
				Font = new Font(SnakeGame.font.Families[0], 32),
				Width = 200,
				Height = 50
			};

			restartbtn.Click += Restart_Game;

			Controls.Add(restartbtn);
			Controls.Add(winnerlabel);
			restartbtn.BringToFront();
			winnerlabel.BringToFront();
		}

		private void Restart_Game(object sender, EventArgs e)
		{
			Application.Restart();
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

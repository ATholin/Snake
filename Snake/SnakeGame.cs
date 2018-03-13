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
		Player[] players;

		MainMenu menu;

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

			Paint += SnakeGame_Paint;

			font.AddFontFile(@"../../Resources/font.ttf");

			menu = new MainMenu(Width, Height);
			Controls.Add(menu);
			menu.BringToFront();

			menu.StartButtonClicked += Menu_StartButtonClicked;

			KeyDown += GameForm_KeyDown;
			KeyPreview = true;

			DoubleBuffered = true;

			timer = new Timer();
			timer.Tick += new EventHandler(TimerEventHandler);
			timer.Interval = 1000/Settings.FPS;
		}

		private void SnakeGame_Paint(object sender, PaintEventArgs e)
		{
			Image newImage = Properties.Resources.bg;
			
			
			for (int i = 0; i < Width; i += Width / 10)
			{
				for (int k = 0; k < Height; k += Height / 10)
				{
					Rectangle srcRect = new Rectangle(i, k, Width / 10, Height / 10);
					e.Graphics.DrawImage(newImage, srcRect);
				}
			}
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
			game = new GameBoard();
			Controls.Add(game);
			ResizeWindow();

			players = new Player[numplayers];

			game.AddPlayers(numplayers);

			scorepanel = new ScorePanel(game, Width);
			Controls.Add(scorepanel);

			game.Location = new Point((Width - game.Width) / 2, 0);
			game.Padding = Padding.Empty;
			game.Margin = Padding.Empty;
	
			game.ScoreChanged += Game_ScoreChanged;

			countdowntimer = new Timer
			{
				Interval = 1000
			};
			countdowntimer.Tick += Countdowntimer_Tick;
			time = 3;
			game.Refresh();
			Countdown();
			timelabel.Location = new Point((Width-timelabel.Width)/2, (game.Height - timelabel.Height) / 2);
		}

		private void Countdowntimer_Tick(object sender, EventArgs e)
		{
			if (time > 1)
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
				Padding = new Padding(5),
				AutoSize = true,
				ForeColor = Color.Black,
				Font = new Font(SnakeGame.font.Families[0], 52),
			};

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
			var players = game.Players;
			int highest = -1;
			int index = 0;
			int windex = 0;

			for(int i = 0; i < players.Length; i += 4)
			{
				index++;
				if (players[i].Score > highest)
				{
					highest = players[i].Score;
					winner = players[i];
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
					game.ChangeDirection(Direction.Up, 0);
					break;
				case Keys.Down:
					game.ChangeDirection(Direction.Down, 0);
					break;
				case Keys.Left:
					game.ChangeDirection(Direction.Left, 0);
					break;
				case Keys.Right:
					game.ChangeDirection(Direction.Right, 0);
					break;

				//PLAYER TWO
				case Keys.W:
					game.ChangeDirection(Direction.Up, 1);
					break;
				case Keys.S:
					game.ChangeDirection(Direction.Down, 1);
					break;
				case Keys.A:
					game.ChangeDirection(Direction.Left, 1);
					break;
				case Keys.D:
					game.ChangeDirection(Direction.Right, 1);
					break;

				//PLAYER THREE
				case Keys.I:
					game.ChangeDirection(Direction.Up, 2);
					break;
				case Keys.K:
					game.ChangeDirection(Direction.Down, 2);
					break;
				case Keys.J:
					game.ChangeDirection(Direction.Left, 2);
					break;
				case Keys.L:
					game.ChangeDirection(Direction.Right, 2);
					break;
			}
		}
	}
}

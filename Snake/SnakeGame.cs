using System;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;
using Snake.Properties;

namespace Snake
{
	public partial class SnakeGame : Form
	{
		public static PrivateFontCollection font = new PrivateFontCollection();

		private readonly MainMenu menu;
		private readonly Timer timer;
		private Timer countdowntimer;
		private GameBoard game;
		private Player[] players;
		private ScorePanel scorepanel;
		private int time;
		private Label timelabel;

		public SnakeGame()
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
			timer.Tick += TimerEventHandler;
			timer.Interval = 1000 / Settings.FPS;
		}

		private void Game_BoardFull()
		{
			GameOver();
		}

		private void SnakeGame_Paint(object sender, PaintEventArgs e)
		{
			Image newImage = Resources.bg;


			for (var i = 0; i < Width; i += Width / 10)
			for (var k = 0; k < Height; k += Height / 10)
			{
				var srcRect = new Rectangle(i, k, Width / 10, Height / 10);
				e.Graphics.DrawImage(newImage, srcRect);
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
			game.BoardFull += Game_BoardFull;

			countdowntimer = new Timer
			{
				Interval = 1000
			};
			countdowntimer.Tick += Countdowntimer_Tick;
			time = 3;
			game.Refresh();
			Countdown();
			timelabel.Location = new Point((Width - timelabel.Width) / 2, (game.Height - timelabel.Height) / 2);
		}

		private void Countdowntimer_Tick(object sender, EventArgs e)
		{
			if (time > 1)
			{
				time--;
				timelabel.Text = time.ToString();
				Refresh();
			}
			else
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
				Width = 100,
				Height = 100,
				TextAlign = ContentAlignment.TopCenter,
				ForeColor = Color.Black,
				Font = new Font(font.Families[0], 52)
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
			}
			else
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
			var winner = game.Players[0];
			var players = game.Players;
			var highest = -1;
			var index = 0;
			var windex = 0;

			for (var i = 0; i < players.Length; i += 4)
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
				Text = $"Player {windex} Wins!",
				Location = new Point(game.Location.X + 50, game.Location.Y + 50)
			};
			winnerlabel.Padding = new Padding(5);
			winnerlabel.AutoSize = true;
			winnerlabel.ForeColor = Color.Black;
			winnerlabel.Font = new Font(font.Families[0], 42);

			var pointslabel = new Label
			{
				Text = $"{winner.Score} Points",
				Location = new Point(winnerlabel.Location.X, winnerlabel.Location.Y + winnerlabel.Height + 50)
			};
			pointslabel.Padding = new Padding(5);
			pointslabel.AutoSize = true;
			pointslabel.ForeColor = Color.Black;
			pointslabel.Font = new Font(font.Families[0], 26);

			var restartinfo = new Label
			{
				Text = "Press Escape to restart",
				Location = new Point(pointslabel.Location.X, pointslabel.Location.Y + pointslabel.Height + 50),
				ForeColor = Color.White,
				BackColor = Color.Black,
				AutoSize = true,
				Font = new Font(font.Families[0], 16)
			};

			Controls.Add(winnerlabel);
			Controls.Add(pointslabel);
			Controls.Add(restartinfo);
			pointslabel.BringToFront();
			winnerlabel.BringToFront();
			restartinfo.BringToFront();
		}

		private void GameForm_KeyDown(object sender, KeyEventArgs e)
		{
			if (!menu.Visible)
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

					case Keys.Escape:
						Application.Restart();
						break;
					case Keys.Enter:
						if (timer.Enabled) Application.Restart();
						break;
				}
		}
	}
}
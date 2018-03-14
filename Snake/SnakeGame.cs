using System;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;
using Snake.Properties;

namespace Snake
{
	public partial class SnakeGame : Form
	{
		public static readonly PrivateFontCollection _Font = new PrivateFontCollection();
		private readonly GameBoard _game;

		private readonly MainMenu _menu;
		private readonly Timer _timer;
		private Timer _countdowntimer;
		private Player[] _players;
		private ScorePanel _scorepanel;
		private int _time;
		private Label _timelabel;

		public SnakeGame()
		{
			_game = new GameBoard();
			Controls.Add(_game);

			InitializeComponent();

			Paint += SnakeGame_Paint;

			_Font.AddFontFile(@"../../Resources/font.ttf");

			_menu = new MainMenu(Width, Height);
			Controls.Add(_menu);
			_menu.BringToFront();

			_menu.StartButtonClicked += Menu_StartButtonClicked;

			KeyDown += GameForm_KeyDown;
			KeyPreview = true;

			DoubleBuffered = true;

			_timer = new Timer();
			_timer.Tick += TimerEventHandler;
			_timer.Interval = 1000 / Settings.FPS;
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
			_game.Width = smallest;
			_game.Height = smallest;
			Settings.Size = smallest / Settings.Dimension;
			_game.Refresh();
		}

		private void Menu_StartButtonClicked(int numplayers)
		{
			ResizeWindow();
			_game.Location = new Point((Width - _game.Width) / 2, 0);

			_players = new Player[numplayers];
			_game.AddPlayers(numplayers);

			_game.Padding = Padding.Empty;
			_game.Margin = Padding.Empty;

			_game.ScoreChanged += Game_ScoreChanged;
			_game.BoardFull += Game_BoardFull;

			_scorepanel = new ScorePanel(_game, Width);
			Controls.Add(_scorepanel);

			_countdowntimer = new Timer
			{
				Interval = 1000
			};
			_countdowntimer.Tick += Countdowntimer_Tick;
			_time = 3;
			_game.Refresh();
			Countdown();
			_timelabel.Location = new Point((Width - _timelabel.Width) / 2, (_game.Height - _timelabel.Height) / 2);
		}

		private void Countdowntimer_Tick(object sender, EventArgs e)
		{
			if (_time > 1)
			{
				_time--;
				_timelabel.Text = _time.ToString();
				Refresh();
			}
			else
			{
				_countdowntimer.Stop();
				_timelabel.Visible = false;
				_timer.Start();
			}
		}

		private void Countdown()
		{
			_timelabel = new Label
			{
				Text = "3",
				Width = 100,
				Height = 100,
				TextAlign = ContentAlignment.TopCenter,
				ForeColor = Color.Black,
				Font = new Font(_Font.Families[0], 52)
			};

			Controls.Add(_timelabel);
			_timelabel.BringToFront();
			_countdowntimer.Start();
		}

		private void Game_ScoreChanged()
		{
			_scorepanel.UpdatePanels();
		}

		private void TimerEventHandler(object sender, EventArgs e)
		{
			if (!_game.Snakes.Count.Equals(0))
			{
				_game.Tick();
				_game.Refresh();
			}
			else
			{
				GameOver();
			}
		}

		private void GameOver()
		{
			_timer.Stop();
			ShowWinner();
		}

		private void ShowWinner()
		{
			var winner = _game.Players[0];
			var players = _game.Players;
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
				Location = new Point(_game.Location.X + 50, _game.Location.Y + 50)
			};
			winnerlabel.Padding = new Padding(5);
			winnerlabel.AutoSize = true;
			winnerlabel.ForeColor = Color.Black;
			winnerlabel.Font = new Font(_Font.Families[0], 42);

			var pointslabel = new Label
			{
				Text = $"{winner.Score} Points",
				Location = new Point(winnerlabel.Location.X, winnerlabel.Location.Y + winnerlabel.Height + 50)
			};
			pointslabel.Padding = new Padding(5);
			pointslabel.AutoSize = true;
			pointslabel.ForeColor = Color.Black;
			pointslabel.Font = new Font(_Font.Families[0], 26);

			var restartinfo = new Label
			{
				Text = "Press Escape to restart",
				Location = new Point(pointslabel.Location.X, pointslabel.Location.Y + pointslabel.Height + 50),
				ForeColor = Color.White,
				BackColor = Color.Black,
				AutoSize = true,
				Font = new Font(_Font.Families[0], 16)
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
			if (!_menu.Visible)
				switch (e.KeyCode)
				{
					//PLAYER ONE
					case Keys.Up:
						_game.ChangeDirection(Direction.Up, 0);
						break;
					case Keys.Down:
						_game.ChangeDirection(Direction.Down, 0);
						break;
					case Keys.Left:
						_game.ChangeDirection(Direction.Left, 0);
						break;
					case Keys.Right:
						_game.ChangeDirection(Direction.Right, 0);
						break;

					//PLAYER TWO
					case Keys.W:
						_game.ChangeDirection(Direction.Up, 1);
						break;
					case Keys.S:
						_game.ChangeDirection(Direction.Down, 1);
						break;
					case Keys.A:
						_game.ChangeDirection(Direction.Left, 1);
						break;
					case Keys.D:
						_game.ChangeDirection(Direction.Right, 1);
						break;

					//PLAYER THREE
					case Keys.I:
						_game.ChangeDirection(Direction.Up, 2);
						break;
					case Keys.K:
						_game.ChangeDirection(Direction.Down, 2);
						break;
					case Keys.J:
						_game.ChangeDirection(Direction.Left, 2);
						break;
					case Keys.L:
						_game.ChangeDirection(Direction.Right, 2);
						break;

					case Keys.Escape:
						Application.Restart();
						break;
					case Keys.Enter:
						if (_timer.Enabled) Application.Restart();
						break;
				}
		}
	}
}
using System;
using System.Drawing;
using System.Windows.Forms;
using Snake.Properties;

namespace Snake
{
	internal class MainMenu : Control
	{
		public delegate void StartButtonClick(int numplayers);

		private SnekButton _addPlayer;
		private SnekButton _delPlayer;
		private FlowLayoutPanel _flow;
		private Label _infolabel;
		private int _numplayers = 1;
		private Label _numplayerslabel;
		private SnekButton _quitbtn;
		private Label _snakelabel;
		private SnekButton _startbtn;

		public MainMenu(int width, int height)
		{
			Image newImage = Resources.bg;
			BackgroundImage = newImage;

			Width = width;
			Height = height;
			BackColor = Color.Black;
			Dock = DockStyle.Fill;
			Font = new Font(SnakeGame._Font.Families[0], 16);

			Initialize();

			_delPlayer.Click += ChangePlayer_Click;
			_addPlayer.Click += ChangePlayer_Click;

			_startbtn.Click += Startbtn_Click;
			_quitbtn.Click += Quitbtn_Click;
			Resize += MainMenu_Resize;

			PreviewKeyDown += MainMenu_PreviewKeyDown;
		}

		// Keypresses while in the menu
		// Left and right adds and removed number of players.
		// Enter starts a game
		// Escape exits the application
		private void MainMenu_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.Left:
					ChangePlayer_Click(_delPlayer, EventArgs.Empty);
					break;
				case Keys.Right:
					ChangePlayer_Click(_addPlayer, EventArgs.Empty);
					break;
				case Keys.Escape:
					Application.Exit();
					break;
				case Keys.Enter:
					Startbtn_Click(null, EventArgs.Empty);
					break;
			}
		}

		private void Initialize()
		{
			var lfont = new Font(SnakeGame._Font.Families[0], 21);

			_snakelabel = new Label
			{
				Font = lfont,
				Text = "SUPREME SNAKE",
				Margin = Padding.Empty,
				Height = 100,
				BackColor = Color.Red,
				ForeColor = Color.White,
				Width = Width - 300,
				TextAlign = ContentAlignment.MiddleCenter
			};

			_startbtn = new SnekButton
			{
				Font = lfont,
				Text = "Start",
				Width = Width - 300,
				Height = 100
			};

			_quitbtn = new SnekButton
			{
				Font = lfont,
				Text = "Quit",
				Width = Width - 300,
				Height = 100
			};

			_flow = new FlowLayoutPanel
			{
				Font = lfont,
				BackColor = Color.Transparent,
				Padding = Padding.Empty,
				Margin = Padding.Empty,
				FlowDirection = FlowDirection.LeftToRight,
				AutoSizeMode = AutoSizeMode.GrowAndShrink,
				Width = 500
			};

			_addPlayer = new SnekButton
			{
				Margin = Padding.Empty,
				Height = _flow.Height,
				Width = _flow.Width / 3,
				Text = "+",
				Tag = "add"
			};

			_delPlayer = new SnekButton
			{
				Width = _flow.Width / 3,
				Height = _flow.Height,
				Text = "-",
				Tag = "del",
				Margin = Padding.Empty
			};

			_numplayerslabel = new Label
			{
				BackColor = Color.Black,
				Margin = Padding.Empty,
				Height = _flow.Height,
				ForeColor = Color.White,
				Width = _flow.Width / 3,
				TextAlign = ContentAlignment.MiddleCenter,
				Text = _numplayers.ToString()
			};

			_infolabel = new Label
			{
				BackColor = Color.Black,
				Margin = Padding.Empty,
				Height = _flow.Height,
				ForeColor = Color.White,
				Width = _flow.Width,
				TextAlign = ContentAlignment.MiddleCenter,
				Text = "<  > : add/remove players\n" +
				       "Enter: Start game\n" +
				       "Escape : quit"
			};

			_flow.Controls.Add(_delPlayer);
			_flow.Controls.Add(_numplayerslabel);
			_flow.Controls.Add(_addPlayer);

			_snakelabel.Location = new Point((Width - _snakelabel.Width) / 2, 100);
			_startbtn.Location = new Point((Width - _startbtn.Width) / 2, _snakelabel.Location.Y + _snakelabel.Height + 50);
			_flow.Location = new Point((Width - _flow.Width) / 2, _startbtn.Location.Y + _startbtn.Height + 10);
			_quitbtn.Location = new Point((Width - _startbtn.Width) / 2, _flow.Location.Y + _flow.Height + 10);
			_infolabel.Location = new Point((Width - _infolabel.Width) / 2, _quitbtn.Location.Y + _quitbtn.Height + 30);

			Controls.Add(_snakelabel);
			Controls.Add(_flow);
			Controls.Add(_quitbtn);
			Controls.Add(_startbtn);
			Controls.Add(_infolabel);
		}

		private static void Quitbtn_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		// Resize to fit the form
		private void MainMenu_Resize(object sender, EventArgs e)
		{
			_snakelabel.Location = new Point((Width - _snakelabel.Width) / 2, 100);
			_startbtn.Location = new Point((Width - _startbtn.Width) / 2, _snakelabel.Location.Y + _snakelabel.Height + 50);
			_flow.Location = new Point((Width - _flow.Width) / 2, _startbtn.Location.Y + _startbtn.Height + 10);
			_quitbtn.Location = new Point((Width - _startbtn.Width) / 2, _flow.Location.Y + _flow.Height + 10);
			_infolabel.Location = new Point((Width - _infolabel.Width) / 2, _quitbtn.Location.Y + _quitbtn.Height + 30);
		}

		private void ChangePlayer_Click(object sender, EventArgs e)
		{
			if (sender is Button btn)
			{
				if (btn.Text.Equals("+"))
				{
					if (_numplayers < Settings.MaxPlayers) _numplayers++;
				}
				else
				{
					if (_numplayers > 1) _numplayers--;
				}

				_numplayerslabel.Text = _numplayers.ToString();


				Refresh();
			}
		}

		private void Startbtn_Click(object sender, EventArgs e)
		{
			Visible = false;
			StartButtonClicked?.Invoke(_numplayers);
		}

		public event StartButtonClick StartButtonClicked;
	}
}
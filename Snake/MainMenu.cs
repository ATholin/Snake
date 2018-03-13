using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Snake
{
	class MainMenu : Control
	{
		int numplayers = 1;
		FlowLayoutPanel flow;
		Label numplayerslabel;
		Label snakelabel;
		Label infolabel;
		SnekButton startbtn;
		SnekButton quitbtn;
		SnekButton addPlayer;
		SnekButton delPlayer;

		public MainMenu(int width, int height) : base()
		{
			Image newImage = Properties.Resources.bg;
			BackgroundImage = newImage;

			Width = width;
			Height = height;
			BackColor = Color.Black;
			Dock = DockStyle.Fill;
			Font = new Font(SnakeGame.font.Families[0], 16);

			Initialize();

			delPlayer.Click += ChangePlayer_Click;
			addPlayer.Click += ChangePlayer_Click;

			startbtn.Click += Startbtn_Click;
			quitbtn.Click += Quitbtn_Click;
			Resize += MainMenu_Resize;

			PreviewKeyDown += MainMenu_PreviewKeyDown; ;
		}

		private void MainMenu_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.Left:
					ChangePlayer_Click(delPlayer, EventArgs.Empty);
					break;
				case Keys.Right:
					ChangePlayer_Click(addPlayer, EventArgs.Empty);
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
			var NinePlusTen = 21;
			var lfont = new Font(SnakeGame.font.Families[0], NinePlusTen);

			snakelabel = new Label
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

			startbtn = new SnekButton
			{
				Font = lfont,
				Text = "Start",
				Width = Width - 300,
				Height = 100,
			};

			quitbtn = new SnekButton
			{
				Font = lfont,
				Text = "Quit",
				Width = Width - 300,
				Height = 100
			};

			flow = new FlowLayoutPanel
			{
				Font = lfont,
				BackColor = Color.Transparent,
				Padding = Padding.Empty,
				Margin = Padding.Empty,
				FlowDirection = FlowDirection.LeftToRight,
				AutoSizeMode = AutoSizeMode.GrowAndShrink,
				Width = 500
			};

			addPlayer = new SnekButton
			{
				Margin = Padding.Empty,
				Height = flow.Height,
				Width = flow.Width / 3,
				Text = "+",
				Tag = "add"
			};

			delPlayer = new SnekButton
			{
				Width = flow.Width / 3,
				Height = flow.Height,
				Text = "-",
				Tag = "del",
				Margin = Padding.Empty
			};

			numplayerslabel = new Label
			{
				BackColor = Color.Black,
				Margin = Padding.Empty,
				Height = flow.Height,
				ForeColor = Color.White,
				Width = flow.Width / 3,
				TextAlign = ContentAlignment.MiddleCenter,
				Text = numplayers.ToString()
			};

			infolabel = new Label
			{
				BackColor = Color.Black,
				Margin = Padding.Empty,
				Height = flow.Height,
				ForeColor = Color.White,
				Width = flow.Width,
				TextAlign = ContentAlignment.MiddleCenter,
				Text =	"<  > : add/remove players\n" +
						"Enter: Start game\n" +
						"Escape : quit"
			};

			flow.Controls.Add(delPlayer);
			flow.Controls.Add(numplayerslabel);
			flow.Controls.Add(addPlayer);

			snakelabel.Location = new Point((Width - snakelabel.Width) / 2, 100);
			startbtn.Location = new Point((Width - startbtn.Width) / 2, snakelabel.Location.Y + snakelabel.Height + 50);
			flow.Location = new Point((Width - flow.Width) / 2, startbtn.Location.Y + startbtn.Height + 10);
			quitbtn.Location = new Point((Width - startbtn.Width) / 2, flow.Location.Y + flow.Height + 10);
			infolabel.Location = new Point((Width - infolabel.Width) / 2, quitbtn.Location.Y + quitbtn.Height + 30);

			Controls.Add(snakelabel);
			Controls.Add(flow);
			Controls.Add(quitbtn);
			Controls.Add(startbtn);
			Controls.Add(infolabel);
		}

		private void Quitbtn_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void MainMenu_Resize(object sender, EventArgs e)
		{
			snakelabel.Location = new Point((Width - snakelabel.Width) / 2, 100);
			startbtn.Location = new Point((Width - startbtn.Width) / 2, snakelabel.Location.Y + snakelabel.Height + 50);
			flow.Location = new Point((Width - flow.Width) / 2, startbtn.Location.Y + startbtn.Height + 10);
			quitbtn.Location = new Point((Width - startbtn.Width) / 2, flow.Location.Y + flow.Height + 10);
		}

		private void ChangePlayer_Click(object sender, EventArgs e)
		{
			var btn = sender as Button;
			if (btn.Text.Equals("+"))
			{

				if (numplayers < Settings.MaxPlayers)
				{
					numplayers++;
				}
			} else
			{
				if (numplayers> 1)
				{
					numplayers--;
				}
			}

			numplayerslabel.Text = numplayers.ToString();
			

			Refresh();
		}

		private void Startbtn_Click(object sender, EventArgs e)
		{
			Visible = false;
			StartButtonClicked?.Invoke(numplayers);
		}

		public delegate void StartButtonClick(int numplayers);
		public event StartButtonClick StartButtonClicked;
	}
}

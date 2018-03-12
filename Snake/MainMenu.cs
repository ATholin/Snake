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
		Label players;

		public MainMenu(int width, int height) : base()
		{
			Dock = DockStyle.Fill;

			var startbtn = new Button
			{
				Text = "Start"
			};

			var quitbtn = new Button
			{
				Text = "Quit",
				Location = new Point(100, 100)
			};

			flow = new FlowLayoutPanel
			{
				FlowDirection = FlowDirection.LeftToRight,
				AutoSizeMode = AutoSizeMode.GrowAndShrink,
				Width = 500
			};

			var addPlayer = new Button
			{
				Margin = Padding.Empty,
				Height = flow.Height,
				Width = flow.Width / 3,
				Text = "+",
				Tag = "add"
			};

			var delPlayer = new Button
			{
				Width = flow.Width / 3,
				Height = flow.Height,
				Text = "-",
				Tag = "del",
				Margin = Padding.Empty
			};

			players = new Label
			{
				Margin = Padding.Empty,
				Height = flow.Height,
				BackColor = Color.White,
				Width = flow.Width / 3,
				TextAlign = ContentAlignment.MiddleCenter,
				Text = numplayers.ToString()
			};

			flow.Controls.Add(delPlayer);
			flow.Controls.Add(players);
			flow.Controls.Add(addPlayer);

			startbtn.Location = new Point((width-startbtn.Width) / 2, 100);
			flow.Location = new Point((width - flow.Width) / 2, startbtn.Location.Y + startbtn.Height + 10);

			Controls.Add(flow);
			Controls.Add(quitbtn);
			Controls.Add(startbtn);

			delPlayer.Click += ChangePlayer_Click;
			addPlayer.Click += ChangePlayer_Click;

			startbtn.Click += Startbtn_Click;
		}

		private void ChangePlayer_Click(object sender, EventArgs e)
		{
			var btn = sender as Button;
			if (btn.Text.Equals("+"))
			{
				if (numplayers<Settings.MaxPlayers)
					numplayers++;
			} else
			{
				if (numplayers> 1)
				{
					numplayers--;
				}
			}

			players.Text = numplayers.ToString();
			flow.Refresh();
		}

		private void Startbtn_Click(object sender, EventArgs e)
		{
			Visible = false;
			StartButtonClicked.Invoke(numplayers);
		}

		public delegate void StartButtonClick(int numplayers);
		public event StartButtonClick StartButtonClicked;
	}
}

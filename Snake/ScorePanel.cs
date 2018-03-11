using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
	class ScorePanel : FlowLayoutPanel
	{
		public ScorePanel(GameBoard game)
		{
			Width = game.Width-30;
			this.game = game;
			AddSnakes();
			playercount = Snakes.Count;
			playerpanels = new PlayerPanel[playercount];

			for (int i = 0; i < playerpanels.Length; i++)
			{
				playerpanels[i] = new PlayerPanel("", Width / playerpanels.Length);

				Controls.Add(playerpanels[i]);
			}

			Dock = DockStyle.Bottom;
			Height = 100;
			Paint += ScoreLabel_Paint;
		}

		private void ScoreLabel_Paint(object sender, PaintEventArgs e)
		{

			int index = 1;
			foreach(var s in Snakes)
			{
				var pointstring = $"Player {index}: {s.points}";
				playerpanels[index - 1].SetText(pointstring);
				index++;
				//e.Graphics.DrawString(s, font, brush, new Point((Width / playercount+index), (Height - font.Height) / 2));
			}
		}

		PlayerPanel[] playerpanels;
		int playercount;
		Font font = new Font("Arial", 20);
		Brush brush = new SolidBrush(Color.Black);

		GameBoard game;
		ISet<Snake> Snakes = new HashSet<Snake>();

		public void AddSnakes()
		{
			foreach(var s in game.Snakes)
			{
				Snakes.Add(s);
			}
		}
	}
}

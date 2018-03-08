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
			AddPlayers();
			playercount = players.Count;
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
			foreach(var p in players)
			{
				var s = $"Player {index}: {p.points}";
				playerpanels[index - 1].SetText(s);
				index++;
				//e.Graphics.DrawString(s, font, brush, new Point((Width / playercount+index), (Height - font.Height) / 2));
			}
		}

		PlayerPanel[] playerpanels;
		int playercount;
		Font font = new Font("Arial", 20);
		Brush brush = new SolidBrush(Color.Black);

		GameBoard game;
		ISet<Player> players = new HashSet<Player>();

		public void AddPlayers()
		{
			foreach(var p in game.Players)
			{
				players.Add(p);
			}
		}
	}
}

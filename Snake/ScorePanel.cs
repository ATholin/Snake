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
			Padding = new Padding(5);
			Width = game.Width-15;
			Height = 115;


			this.game = game;
			playercount = game.Snakes.Count;
			playerpanels = new PlayerPanel[playercount];

			int index = 0;
			foreach (var snake in game.Snakes)
			{
				Snakes.Add(snake);
				playerpanels[index] = new PlayerPanel("", Width / playercount)
				{
					BackColor = snake.SnakeColor
				};
				Controls.Add(playerpanels[index]);
				index++;
			}

			Dock = DockStyle.Bottom;
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
	}
}

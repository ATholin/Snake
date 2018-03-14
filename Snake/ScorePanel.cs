using System.Collections.Generic;
using System.Windows.Forms;

namespace Snake
{
	internal class ScorePanel : FlowLayoutPanel
	{
		private readonly PlayerPanel[] playerpanels;

		private readonly ISet<Snake> Snakes = new HashSet<Snake>();

		public ScorePanel(GameBoard game, int width)
		{
			Width = width;
			BorderStyle = BorderStyle.None;
			Margin = Padding.Empty;
			Padding = Padding.Empty;
			Height = 100;

			var playercount = game.Snakes.Count;
			playerpanels = new PlayerPanel[playercount];

			var index = 0;
			foreach (var snake in game.Snakes)
			{
				Snakes.Add(snake);
				// Width depending on number of players
				// 3 players = panel is 1/3 of the form width
				playerpanels[index] = new PlayerPanel("", Width / playercount - playercount * playercount)
				{
					BackColor = snake.SnakeColor
				};
				Controls.Add(playerpanels[index]);
				index++;
			}

			UpdatePanels();
			Dock = DockStyle.Bottom;
		}

		public void UpdatePanels()
		{
			var index = 1;
			foreach (var s in Snakes)
			{
				var pointstring = s.Points.ToString();
				playerpanels[index - 1].SetText(pointstring);
				index++;
			}
		}
	}
}
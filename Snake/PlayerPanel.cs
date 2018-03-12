using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Snake
{
	public class PlayerPanel : Panel
	{
		public PlayerPanel(string s, int width)
		{
			label = new Label
			{
				Text = s
			};
			label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label.Dock = DockStyle.Fill;

			ForeColor = Color.Black;
			Font = new Font("Arial", 20);

			Margin = Padding.Empty;

			Width = width-5;
			Controls.Add(label);
		}

		public void SetText(string s) => label.Text = s;

		public Label label;
	}
}

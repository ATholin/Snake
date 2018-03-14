using System.Drawing;
using System.Windows.Forms;

namespace Snake
{
	public class PlayerPanel : Panel
	{
		private readonly Label _label;

		public PlayerPanel(string s, int width)
		{
			_label = new Label
			{
				Text = s
			};
			_label.TextAlign = ContentAlignment.MiddleCenter;
			_label.Dock = DockStyle.Fill;

			ForeColor = Color.White;
			Font = new Font(SnakeGame._Font.Families[0], 20);

			Margin = Padding.Empty;

			Width = width;
			Controls.Add(_label);
		}

		public void SetText(string s)
		{
			_label.Text = s;
		}
	}
}
using System.Drawing;
using System.Windows.Forms;

namespace Snake
{
	internal class SnekButton : Button
	{
		public SnekButton()
		{
			FlatStyle = FlatStyle.Flat;
			BackColor = Color.DarkGray;
		}
	}
}
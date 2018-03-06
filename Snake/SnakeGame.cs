using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Snake
{
	class SnakeGame : Form
	{
		public List<Point> Points = new List<Point>();

		private SolidBrush Brush;
		Form Form = new Form();

		Pen Pen;

		private int X, Y, FormWidth, FormHeight;
	}
}

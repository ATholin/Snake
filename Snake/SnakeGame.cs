using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
	public partial class SnakeGame : Form
	{
		public SnakeGame()
		{
			InitializeComponent();

			var gboard = new GameBoard(10, 1);
			Controls.Add(gboard);
		}
	}
}

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

			game = new GameBoard(10, 1);
			Controls.Add(game);

			KeyDown += GameForm_KeyDown;
			KeyPreview = true;
		}

		GameBoard game;

		private void GameForm_KeyDown(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.Up:
					game.MoveUp(e.KeyCode);
					break;
				case Keys.Down:
					game.MoveDown(e.KeyCode);
					break;
				case Keys.Left:
					game.MoveLeft(e.KeyCode);
					break;
				case Keys.Right:
					game.MoveRight(e.KeyCode);
					break;
			}
		}
	}
}

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

<<<<<<< HEAD
			game = new GameBoard(20, 1);
=======
			int dimension = 25;
			Width = 500;
			game = new GameBoard(dimension, 2, Width);
>>>>>>> 371065194639246aedc29c9d08d31bc1eccd41d3
			Controls.Add(game);

			KeyDown += GameForm_KeyDown;
			KeyPreview = true;
<<<<<<< HEAD
=======

			DoubleBuffered = false;
>>>>>>> 371065194639246aedc29c9d08d31bc1eccd41d3
		}
		
		GameBoard game;
		private void GameForm_KeyDown(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				//PLAYER ONE
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

				//PLAYER TWO
				case Keys.W:
					game.MoveUp(e.KeyCode);
					break;
				case Keys.S:
					game.MoveDown(e.KeyCode);
					break;
				case Keys.A:
					game.MoveLeft(e.KeyCode);
					break;
				case Keys.D:
					game.MoveRight(e.KeyCode);
					break;
			}
		}
	}
}

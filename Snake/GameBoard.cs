using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Snake.Interface;
using System.Drawing;

namespace Snake
{
    public class GameBoard : Panel
    {
		public GameBoard(int dimension, int players, int size)
		{

<<<<<<< HEAD
			snakes[0] = snake;
			this.players[0] = new ControlKeys(Keys.Up, Keys.Down, Keys.Left, Keys.Right, snake);
=======
			BoardSize = Width = Height = size;
>>>>>>> 371065194639246aedc29c9d08d31bc1eccd41d3

			Dimension = dimension;
			snake = new Snake((BoardSize / Dimension) * 3, (BoardSize / Dimension) * 1, BoardSize / Dimension);
			snake2 = new Snake((BoardSize / Dimension) * 3, (BoardSize / Dimension) * 3, BoardSize / Dimension);

			snakes[0] = snake;
			snakes[1] = snake2;
			this.players[0] = new ControlKeys(Keys.Up, Keys.Down, Keys.Left, Keys.Right, snake);
			this.players[1] = new ControlKeys(Keys.W, Keys.S, Keys.A, Keys.D, snakes[1]);

			

			snake = new Snake(Width / Dimension * 3, Height / Dimension * 1, this.Width / Dimension);
			snake2 = new Snake(Width / Dimension * 3, Height / Dimension * 1, this.Width / Dimension);


			Paint += new PaintEventHandler(Draw);
			
			timer = new Timer();
			timer.Tick += new EventHandler(TimerEventHandler);
<<<<<<< HEAD
			timer.Interval = 1000 / 2;
			timer.Start();
			
		}

=======
			timer.Interval = 1000/10;
			timer.Start();			
		}
		int BoardSize;
>>>>>>> 371065194639246aedc29c9d08d31bc1eccd41d3
		int Dimension;
		Timer timer;

<<<<<<< HEAD
		ControlKeys[] players = new ControlKeys[1];
		public Snake[] snakes = new Snake[1];

		
=======
		Snake snake;
		Snake snake2;

		ControlKeys[] players = new ControlKeys[2];
		public Snake[] snakes = new Snake[2];			
>>>>>>> 371065194639246aedc29c9d08d31bc1eccd41d3

		private void TimerEventHandler(object sender, EventArgs e)
		{
			foreach (var p in players)
			{
				p.MoveSnake();
			}
			foreach(var snek in snakes)
			{
				foreach(var enemysnek in snakes)
				{
					if (snek.Intersects(enemysnek.Snakebody))
					{
						snek.OnCollision(enemysnek);
					}
				}
				snek.HasMoved = true;
			}
			Refresh();
		}

		private void Draw(object sender, PaintEventArgs e)
		{
			var p = sender as Panel;
			e.Graphics.FillRectangle(new SolidBrush(Color.Black), p.DisplayRectangle);
			foreach (var s in snakes)
			{
				s.Draw(e.Graphics);
			}
		}
		internal void MoveUp(Keys key)
		{
			foreach (var player in players)
			{
				if (player.Up == key)
				{
<<<<<<< HEAD
					player.ChangeDir(Direction.Up);
					player.MoveSnake();
=======
						player.ChangeDir(Direction.Up);
>>>>>>> 371065194639246aedc29c9d08d31bc1eccd41d3
				}
			}
		}

		internal void MoveDown(Keys key)
		{
			foreach (var player in players)
			{
				if (player.Down == key)
				{
<<<<<<< HEAD
					player.ChangeDir(Direction.Down);
					player.MoveSnake();
=======
						player.ChangeDir(Direction.Down);
>>>>>>> 371065194639246aedc29c9d08d31bc1eccd41d3
				}
			}
		}

		internal void MoveLeft(Keys key)
		{
			foreach (var player in players)
			{
				if (player.Left == key)
				{
<<<<<<< HEAD
					player.ChangeDir(Direction.Left);
					player.MoveSnake();
=======
						player.ChangeDir(Direction.Left);
>>>>>>> 371065194639246aedc29c9d08d31bc1eccd41d3
				}
			}
		}

		internal void MoveRight(Keys key)
		{
			foreach (var player in players)
			{
				if (player.Right == key)
				{
<<<<<<< HEAD
					player.ChangeDir(Direction.Right);
					player.MoveSnake();
=======
						player.ChangeDir(Direction.Right);
>>>>>>> 371065194639246aedc29c9d08d31bc1eccd41d3
				}
			}
		}
	}
}

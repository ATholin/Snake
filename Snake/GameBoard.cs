using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Snake.Interface;

namespace Snake
{
    public class GameBoard : Panel
    {
		public GameBoard(int dimension, int players)
		{
			this.Dock = DockStyle.Fill;

			Dimension = dimension;

			CreatePlayers(players);

			timer = new Timer();
			this.Paint += new PaintEventHandler(Draw);
			timer.Tick += new EventHandler(TimerEventHandler);
			timer.Interval = 1000 / 25;
			timer.Start();
		}

		HashSet<ICollidable> collidables = new HashSet<ICollidable>();
		HashSet<Player> players;
        int Dimension;
		Timer timer;

		private void TimerEventHandler(Object obj, EventArgs args)
		{

		}

		public void Draw(Object obj, PaintEventArgs args)
		{
			foreach (var c in collidables)
			{
				c.Draw(args.Graphics);
			}
		}

		public void CreatePlayers(int players)
		{
			this.players = new HashSet<Player>();
		}
    }
}

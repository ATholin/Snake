using System;
using System.Collections.Generic;
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
		public GameBoard(int dimension, int players)
		{
            Dock = DockStyle.Fill;
            
			Dimension = dimension;

			CreatePlayers(players);
            foreach (var player in this.players)
            {
                collidables.Add(player.snek.AddPiece(50, 50, 50, 50));
            }
            timer = new Timer();
            Paint += new PaintEventHandler(Draw);
			timer.Tick += new EventHandler(TimerEventHandler);
			timer.Interval = 1000 / 25;
			timer.Start();
		}

		public HashSet<ICollidable> collidables = new HashSet<ICollidable>();
		HashSet<Player> players;
        int Dimension;
		Timer timer;

		private void TimerEventHandler(Object obj, EventArgs args)
		{
            Paint += new PaintEventHandler(Draw);
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
            foreach (var player in this.players)
            {
                collidables.Add(player.snek.AddPiece(50,50,50,50));
            }
		}
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Snake
{
	class Settings
	{
		// GAME SETTINGS
		public static int NumPlayers = 1;
		public static int MaxPlayers = 3;
		public static int Dimension = 40;
		public static int Size;
		public static int FPS = 30;

		public struct PlayerInfo
		{
			public PlayerInfo(Keys Up, Keys Down, Keys Left, Keys Right, Color color)
			{
				this.Up = Up;
				this.Down = Down;
				this.Left = Left;
				this.Right = Right;
				this.color = color;
			}

			public Keys Up;
			public Keys Down;
			public Keys Left;
			public Keys Right;
			public Color color;
		};

		

		public static PlayerInfo[] players = new PlayerInfo[MaxPlayers+1];

		public static void AddPlayers()
		{
			players[1] = new PlayerInfo(Keys.Up, Keys.Down, Keys.Left, Keys.Right, Color.Blue);
			players[2] = new PlayerInfo(Keys.W, Keys.S, Keys.A, Keys.D, Color.Red);
			players[3] = new PlayerInfo(Keys.I, Keys.K, Keys.J, Keys.L, Color.Green);
		}
	}
}

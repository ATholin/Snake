using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Snake.Interface;
using System.Drawing;

namespace Snake
{
	class SpeedFood : Food, ICollidable
	{
		GameBoard Game;

		public SpeedFood(GameBoard game, int x, int y) : base(x, y)
		{
			brush = new SolidBrush(Color.Cyan);
			Game = game;
		}

		public override void OnCollision(Snake snake)
		{
			var s = GetRandomSnake();
			s.SpeedUp();
		}

		public Snake GetRandomSnake()
		{
			var arr = Game.Snakes.ToArray();
			Random r = new Random();
			return arr[r.Next(0, arr.Length)];
		}
	}
}

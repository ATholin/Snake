using System;
using System.Drawing;
using System.Linq;
using Snake.Interface;

namespace Snake
{
	internal class SpeedFood : Food, ICollidable
	{
		private readonly GameBoard Game;

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
			var r = new Random();
			return arr[r.Next(0, arr.Length)];
		}
	}
}
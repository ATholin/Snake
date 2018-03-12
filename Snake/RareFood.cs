using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Snake.Interface;
using System.Drawing;

namespace Snake
{
	class RareFood : Food, ICollidable
	{
		public RareFood(int x, int y) : base(x, y)
		{
			brush = new SolidBrush(Color.Yellow);
		}

		public override void OnCollision(Snake snake)
		{
			snake.DoubleGrow(5);
		}
	}
}

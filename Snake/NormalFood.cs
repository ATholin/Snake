using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Snake.Interface;
using System.Windows.Forms;

namespace Snake
{
    public class NormalFood : Food, ICollidable
    {
		public NormalFood(Rectangle rect) : base(rect) { }

		public NormalFood(int x, int y, int size) : base(x, y, size) { }

		public override void OnCollision(Snake snake)
		{
			snake.Grow(1);
		}
	}
}
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Snake.Interface;

namespace Snake
{
    class NormalFood : Food, ICollidable
    {
		public NormalFood(int X, int Y, int size)
		{
			Init(this, X, Y, size);
		}

        public override void OnCollision(Snake snek)
        {
			//snek.Grow();
        }
    }
}
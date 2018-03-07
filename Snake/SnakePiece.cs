using Snake.Interface;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Snake
{
    public class SnakePiece : Tile, ICollidable
    {
		public SnakePiece(int x, int y, int width, int height) : base(x, y, width, height)
		{

		}
		Pen pen = new Pen(Color.Black);

        public void Draw(Graphics g)
        {
			g.DrawRectangle(pen, X, Y, Width, Height);
        }

        public bool Intersects(object obj)
        {
            throw new NotImplementedException();
        }

        public void OnCollision(object obj)
        {
            throw new NotImplementedException();
        }
    }
}

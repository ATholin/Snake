using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Snake.Interface;

namespace Snake
{
    public class SnakeBody
    {
		public SnakeBody(int length)
		{
			pieces = new LinkedList<SnakePiece>();
			Length = length;
            AddPiece(50, 50, 50, 50);
            AddPiece(100, 50, 50, 50);
            AddPiece(150, 50, 50, 50);
        }

        public SnakePiece AddPiece(int x, int y, int w, int h)
        {
            SnakePiece newPiece = new SnakePiece(x, y, w, h);
            pieces.AddLast(newPiece);
            return newPiece;
        }

		int Length;

		LinkedList<SnakePiece> pieces;

        Direction direction;
        Pen pen;
        Brush brush;
    }
}
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class SnakeBody
    {
		public SnakeBody(int length)
		{
			pieces = new LinkedList<SnakePiece>();
			Length = length;
			pieces.AddLast(new SnakePiece(50, 50, 50, 50));
			pieces.AddLast(new SnakePiece(100, 50, 50, 50));
			pieces.AddLast(new SnakePiece(150, 50, 50, 50));
		}

		int Length;

		LinkedList<SnakePiece> pieces;

        Direction direction;
        Pen pen;
        Brush brush;
    }
}

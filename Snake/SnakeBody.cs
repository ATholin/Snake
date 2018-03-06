using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class SnakeBody : LinkedList<SnakePiece>
    {
        Direction direction;
        Pen pen;
        Brush brush;
    }
}

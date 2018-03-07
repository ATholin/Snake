using Snake.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Snake
{
    public class SnakePiece : IDrawable, ICollidable
    {
        public void Draw(Graphics g)
        {
            throw new NotImplementedException();
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

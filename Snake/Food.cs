using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Snake.Interface;

namespace Snake
{
    public abstract class Food : ICollidable
    {
        public void Draw(Graphics g)
        {
            throw new NotImplementedException();
        }

        public abstract bool Intersects(object obj);

        public abstract void OnCollision(object obj);
    }
}

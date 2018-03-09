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
        public NormalFood(int X, int Y)
        {
            brush = new SolidBrush(Color.White);
            FoodPiece = new Rectangle(X, Y, foodSize, foodSize);

        }

        int foodSize = 20;
        Rectangle FoodPiece;
        SolidBrush brush;

        public override bool Intersects(Rectangle[] obj)
        {
            throw new NotImplementedException();
        }

        public override void OnCollision(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
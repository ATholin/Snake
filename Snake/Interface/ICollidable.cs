using System.Drawing;

namespace Snake.Interface
{
    public interface ICollidable
    {
        bool Intersects(Rectangle[] obj);
        void OnCollision(object obj);
        void Draw(Graphics g);
    }
}

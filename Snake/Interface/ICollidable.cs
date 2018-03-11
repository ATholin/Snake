using System.Drawing;

namespace Snake.Interface
{
    public interface ICollidable
    {
        bool Intersects(Snake obj);
        void OnCollision(Snake obj);
        void Draw(Graphics g);
    }
}
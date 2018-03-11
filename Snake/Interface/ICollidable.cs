using System.Drawing;

namespace Snake.Interface
{
    public interface ICollidable
    {
        bool Intersects(Snake snake);
        void OnCollision(Snake snake);
        void Draw(Graphics g);
    }
}
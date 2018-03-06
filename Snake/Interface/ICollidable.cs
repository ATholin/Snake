namespace Snake.Interface
{
    public interface ICollidable
    {
        bool Intersects(object obj);
        void OnCollision(object obj);
    }
}

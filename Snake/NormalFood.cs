using System.Drawing;
using Snake.Interface;

namespace Snake
{
	public class NormalFood : Food, ICollidable
	{
		public NormalFood(int x, int y) : base(x, y)
		{
			brush = new SolidBrush(Color.White);
		}

		public override void OnCollision(Snake snake)
		{
			snake.Grow(1);
		}
	}
}
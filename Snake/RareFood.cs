using System.Drawing;
using Snake.Interface;

namespace Snake
{
	internal class RareFood : Food, ICollidable
	{
		public RareFood(int x, int y) : base(x, y)
		{
			brush = new SolidBrush(Color.Yellow);
		}

		public override void OnCollision(Snake snake)
		{
			snake.DoubleGrow(5);
		}
	}
}
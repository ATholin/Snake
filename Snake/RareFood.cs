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

		// Grows snake by 2, adds 5 points
		public override void OnCollision(Snake snake)
		{
			snake.DoubleGrow(5);
		}
	}
}
using System.Drawing;
using System.Windows.Forms;

namespace Snake
{
	public class Player
	{
		private readonly Snake _snake;
		private Direction _direction;
		private Keys _down;
		private Keys _left;
		private Keys _right;

		private Keys _up;

		public Player(Keys up, Keys down, Keys left, Keys right, Snake snake)
		{
			_up = up;
			_down = down;
			_left = left;
			_right = right;
			_snake = snake;
			_direction = Direction.Down;
		}

		public int Counter
		{
			get => _snake.Counter;
			set => _snake.Counter = value;
		}

		public bool isalive => _snake.isAlive;

		public int Score => _snake.Points;
		public Color Color => _snake.SnakeColor;

		public void MoveSnake()
		{
			_snake.MoveSnake(_direction);
		}

		public void ChangeDir(Direction dir)
		{
			if (!IsOppositeDir(dir)) _direction = dir;
		}

		private bool IsOppositeDir(Direction newdir)
		{
			switch (_snake.LastDir)
			{
				case Direction.Up:
					if (newdir == Direction.Down)
						return true;
					break;
				case Direction.Down:
					if (newdir == Direction.Up)
						return true;
					break;
				case Direction.Left:
					if (newdir == Direction.Right)
						return true;
					break;
				case Direction.Right:
					if (newdir == Direction.Left)
						return true;
					break;
			}

			return false;
		}
	}
}
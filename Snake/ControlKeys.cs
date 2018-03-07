using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
	class ControlKeys
	{
		public ControlKeys(Keys up, Keys down, Keys left, Keys right)
		{
			Up = up;
			Down = down;
			Left = left;
			Right = right;
		}

		public Keys Up { get { return Up; } private set { } }
		public Keys Down { get { return Down; } private set { } }
		public Keys Left { get { return Right; } private set { } }
		public Keys Right { get { return Right; } private set { } }
	}
}

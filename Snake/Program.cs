using System.Windows.Forms;

namespace Snake
{
	internal static class Program
	{
		private static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new SnakeGame());
		}
	}
}
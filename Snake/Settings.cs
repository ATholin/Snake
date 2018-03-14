namespace Snake
{
	internal class Settings
	{
		// GAME SETTINGS

		// Max number of players
		// Tested and working for up to 3 players
		// Should support up to 16 players (not tested)
		public static int MaxPlayers = 3;

		// Max number of food instances on the board at once.
		public static int MaxFood = 3;

		// Number of "Tiles" the snake can move between
		// Board is Dimension^2
		public static int Dimension = 20;

		// Size of each Tile
		// Width / Dimension
		// Width has to be divisible by Dimension
		public static int Size;
		public static int FPS = 30;
	}
}
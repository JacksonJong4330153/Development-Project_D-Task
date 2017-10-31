using System;
using SwinGameSDK;


namespace MyGame
{
	public class MapClass
	{
		bool test;

		public void draw ()
		{
			SwinGame.DrawRectangle (Color.Yellow, 215, 210, 100, 100);
			SwinGame.DrawRectangle (Color.Yellow, 215, 310, 100, 100);
			SwinGame.DrawRectangle (Color.Yellow, 215, 410, 100, 100);
			SwinGame.DrawRectangle (Color.Yellow, 315, 210, 100, 100);
			SwinGame.DrawRectangle (Color.Yellow, 315, 310, 100, 100);
			SwinGame.DrawRectangle (Color.Yellow, 315, 410, 100, 100);
			SwinGame.DrawRectangle (Color.Yellow, 415, 210, 100, 100);
			SwinGame.DrawRectangle (Color.Yellow, 415, 310, 100, 100);
			SwinGame.DrawRectangle (Color.Yellow, 415, 410, 100, 100);
		}

		public void startgame ()
		{
			while (false == SwinGame.WindowCloseRequested ()) {
				SwinGame.ProcessEvents ();
				SwinGame.DrawBitmap ("instruction.png", 0, 0);


				if (SwinGame.KeyTyped (KeyCode.vk_SPACE)){
					break;
				}

				SwinGame.RefreshScreen (60);
			}
		}

		public void gameover (int score)
		{ 
			Font f = SwinGame.LoadFont (SwinGame.PathToResource ("arial.ttf", ResourceKind.FontResource), 50);

			while (test == false) {
				SwinGame.ProcessEvents ();
				SwinGame.DrawBitmap ("End.png", 0, 0);

				SwinGame.DrawText ("Your score is " + score.ToString (), Color.White, f, 320, 330);
				SwinGame.DrawText ("Press Space to Restart the game", Color.Red, f, 120, 430);

				if (SwinGame.KeyTyped (KeyCode.vk_SPACE)) {
					test = true;
				}

				SwinGame.RefreshScreen (60);
			}

			SwinGame.FreeFont (f);
			test = false;
		}


		public void RestartGame ()
		{
			

		}
	}
}

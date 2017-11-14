using System;
using SwinGameSDK;


namespace MyGame
{
	public class MapClass
	{
		bool test;
		string draw_text;
		int pos1, pos2, pos3;

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

		public void startgame (string dtext)
		{
			while (false == SwinGame.WindowCloseRequested ()) {
				if (dtext == "mainmenu") {
					//set text
					draw_text = "Play Game";
					pos1 = 50;
					pos2 = 400;
					pos3 = 170;
				} else if (dtext == "pausemenu") {
					//set text
					draw_text = "Resume Game";
					pos1 = 50;
					pos2 = 350;
					pos3 = 170;
				}

				SwinGame.ProcessEvents ();
				//draw beautiful BG
				SwinGame.DrawBitmap ("mainmenu.jpg", 0, 0);

				//display Menu
				SwinGame.DrawText ("SpaceShip - The Game", Color.White, "maven_pro_regular", 60, 210, 50);

				SwinGame.DrawText (draw_text, Color.White, "maven_pro_regular", pos1, pos2, pos3);
				SwinGame.DrawText ("HighScore", Color.White, "maven_pro_regular", 50, 400, 270);
				SwinGame.DrawText ("Instruction", Color.White, "maven_pro_regular", 50, 400, 370);
				SwinGame.DrawText ("Quit Game", Color.White, "maven_pro_regular", 50, 400, 470);

				//if (SwinGame.KeyTyped (KeyCode.vk_SPACE)){
				//	break;
				//}

				//check mouse position
				//x, y, w, h
				if (SwinGame.PointInRect (SwinGame.MousePosition (), 370, 150, 300, 70))
					SwinGame.DrawText (draw_text, Color.BlueViolet, "maven_pro_regular", pos1, pos2, pos3);
				else
					SwinGame.DrawText (draw_text, Color.White, "maven_pro_regular", pos1, pos2, pos3);

				if (SwinGame.PointInRect (SwinGame.MousePosition (), 370, 250, 300, 70))
					SwinGame.DrawText ("HighScore", Color.BlueViolet, "maven_pro_regular", 50, 400, 270);
				else
					SwinGame.DrawText ("HighScore", Color.White, "maven_pro_regular", 50, 400, 270);

				if (SwinGame.PointInRect (SwinGame.MousePosition (), 370, 350, 300, 70))
					SwinGame.DrawText ("Instruction", Color.BlueViolet, "maven_pro_regular", 50, 400, 370);
				else
					SwinGame.DrawText ("Instruction", Color.White, "maven_pro_regular", 50, 400, 370);

				if (SwinGame.PointInRect (SwinGame.MousePosition (), 370, 450, 300, 70))
					SwinGame.DrawText ("Quit Game", Color.BlueViolet, "maven_pro_regular", 50, 400, 470);
				else
					SwinGame.DrawText ("Quit Game", Color.White, "maven_pro_regular", 50, 400, 470);

				//Do function when clicked
				if (SwinGame.MouseClicked (MouseButton.LeftButton) && SwinGame.PointInRect (SwinGame.MousePosition (), 141, 150, 470, 55)) {
					break;
				}
				if (SwinGame.MouseClicked (MouseButton.LeftButton) && SwinGame.PointInRect (SwinGame.MousePosition (), 141, 250, 470, 55)) {
					drawHighScore (true);
				}
				if (SwinGame.MouseClicked (MouseButton.LeftButton) && SwinGame.PointInRect (SwinGame.MousePosition (), 101, 350, 470, 55)) {
					drawInstruction (true);
				}
				if (SwinGame.MouseClicked (MouseButton.LeftButton) && SwinGame.PointInRect (SwinGame.MousePosition (), 141, 450, 470, 55)) {
					//quit game here
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

		public void drawInstruction (bool b)
		{
			while (b == true) {
				SwinGame.ProcessEvents ();
				SwinGame.DrawBitmap ("instruction.png", 0, 0);

				SwinGame.RefreshScreen (60);
				if (SwinGame.KeyTyped (KeyCode.vk_SPACE)) {
					break;
				}
			}
		}


		public void drawHighScore (bool b)
		{
			while (b == true) {
				SwinGame.ProcessEvents ();
				HighScoreController.DrawHighScores ();

				SwinGame.RefreshScreen (60);
				if (SwinGame.KeyTyped (KeyCode.vk_SPACE)) {
					break;
				}
			}
		}
	}
}

﻿using System;
using SwinGameSDK;


namespace MyGame
{
		public class MapClass
		{
		bool game_over;
		string draw_text, draw_text2;
		int pos1, pos2, pos3;
		int pos4, pos5, pos6;
		string game = "gstart";

		bool endgame = false;

		public bool getRestart {
			get { return endgame; }
			set { endgame = value; } 
		}

		public void draw ()
		{
			//SwinGame.DrawRectangle (Color.Yellow, 215, 210, 100, 100);
			//SwinGame.DrawRectangle (Color.Yellow, 215, 310, 100, 100);
			//SwinGame.DrawRectangle (Color.Yellow, 215, 410, 100, 100);
			//SwinGame.DrawRectangle (Color.Yellow, 315, 210, 100, 100);
			//SwinGame.DrawRectangle (Color.Yellow, 315, 310, 100, 100);
			//SwinGame.DrawRectangle (Color.Yellow, 315, 410, 100, 100);
			//SwinGame.DrawRectangle (Color.Yellow, 415, 210, 100, 100);
			//SwinGame.DrawRectangle (Color.Yellow, 415, 310, 100, 100);
			//SwinGame.DrawRectangle (Color.Yellow, 415, 410, 100, 100);
			SwinGame.DrawBitmap ("spacebattleship.png", 265, 170);
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

					draw_text2 = "Quit Game";
					pos4 = 50;
					pos5 = 400;
					pos6 = 470;

					game = "gstart";
				} else if (dtext == "pausemenu") {
					//set text
					draw_text = "Resume Game";
					pos1 = 50;
					pos2 = 350;
					pos3 = 170;

					draw_text2 = "Restart Game";
					pos4 = 50;
					pos5 = 360;
					pos6 = 470;

					game = "gend";
				}

				SwinGame.ProcessEvents ();
				//draw beautiful BG
				SwinGame.DrawBitmap ("mainmenu.png", 0, 0);
				Font titlefont = SwinGame.LoadFont (SwinGame.PathToResource ("moonhouse.ttf", ResourceKind.FontResource), 60);
				SwinGame.FontSetStyle (titlefont, FontStyle.UnderlineFont);
				//display Menu, 60, 110, 50);
				SwinGame.DrawText ("SpaceShip - The Game", Color.Yellow, titlefont, 110, 50);

				SwinGame.DrawText (draw_text, Color.White, "maven_pro_regular", pos1, pos2, pos3);
				SwinGame.DrawText ("HighScore", Color.White, "maven_pro_regular", 50, 400, 270);
				SwinGame.DrawText ("Instruction", Color.White, "maven_pro_regular", 50, 400, 370);
				SwinGame.DrawText (draw_text2, Color.White, "maven_pro_regular", pos4, pos5, pos6);

				//if (SwinGame.KeyTyped (KeyCode.vk_SPACE)){
				//	break;
				//}

				//check mouse position
				//x, y, w, h
				if (SwinGame.PointInRect (SwinGame.MousePosition (), 370, 160, 300, 100))
					SwinGame.DrawText (draw_text, Color.IndianRed, "maven_pro_regular", pos1, pos2, pos3);
				else
					SwinGame.DrawText (draw_text, Color.White, "maven_pro_regular", pos1, pos2, pos3);

				if (SwinGame.PointInRect (SwinGame.MousePosition (), 380, 260, 330, 100))
					SwinGame.DrawText ("HighScore", Color.IndianRed, "maven_pro_regular", 50, 400, 270);
				else
					SwinGame.DrawText ("HighScore", Color.White, "maven_pro_regular", 50, 400, 270);

				if (SwinGame.PointInRect (SwinGame.MousePosition (), 380, 360, 330, 100))
					SwinGame.DrawText ("Instruction", Color.IndianRed, "maven_pro_regular", 50, 400, 370);
				else
					SwinGame.DrawText ("Instruction", Color.White, "maven_pro_regular", 50, 400, 370);

				if (SwinGame.PointInRect (SwinGame.MousePosition (), 380, 460, 330, 100))
					SwinGame.DrawText (draw_text2, Color.IndianRed, "maven_pro_regular", pos4, pos5, pos6);
				else
					SwinGame.DrawText (draw_text2, Color.White, "maven_pro_regular", pos4, pos5, pos6);

				//Do function when clicked
				if (SwinGame.MouseClicked (MouseButton.LeftButton) && SwinGame.PointInRect (SwinGame.MousePosition (), 141, 150, 500, 100)) {
					break;
				}
				if (SwinGame.MouseClicked (MouseButton.LeftButton) && SwinGame.PointInRect (SwinGame.MousePosition (), 141, 250, 500, 100)) {
                    drawHighScore (true);
				}
				if (SwinGame.MouseClicked (MouseButton.LeftButton) && SwinGame.PointInRect (SwinGame.MousePosition (), 141, 350, 500, 100)) {
					drawInstruction (true);
				}
				if (SwinGame.MouseClicked (MouseButton.LeftButton) && SwinGame.PointInRect (SwinGame.MousePosition (), 141, 450, 500, 100)) {
					if (game == "gend" && dtext == "pausemenu") {
						endgame = true;
						break;
					} else if (game == "gstart" && dtext == "mainmenu"){
						Environment.Exit (exitCode: 0);
					}
				}

				SwinGame.RefreshScreen (60);
			}	
		}

		public void gameover (int score, string timer)
		{
			Font f = SwinGame.LoadFont (SwinGame.PathToResource ("arial.ttf", ResourceKind.FontResource), 50);

			while (game_over == false) {
				SwinGame.ProcessEvents ();
				SwinGame.DrawBitmap ("End.png", -100, 0);
				SwinGame.DrawText ("Score: " + score.ToString (), Color.White, SwinGame.LoadFont (SwinGame.PathToResource ("arial.ttf", ResourceKind.FontResource), 40), 420, 330);
				SwinGame.DrawText ("Time: " + timer, Color.White, SwinGame.LoadFont (SwinGame.PathToResource ("arial.ttf", ResourceKind.FontResource), 40), 420, 370);
				SwinGame.DrawText ("Press Space to Restart the game", Color.Red, SwinGame.LoadFont (SwinGame.PathToResource ("arial.ttf", ResourceKind.FontResource), 30), 270, 500);

				if (SwinGame.KeyTyped (KeyCode.vk_SPACE)) {
					game_over = true;
					startgame ("mainmenu");
				}

				SwinGame.RefreshScreen (60);
			}

			SwinGame.FreeFont (f);
			game_over = false;
		}

		public void drawInstruction (bool b)
		{
			while (b == true) {
				SwinGame.ProcessEvents ();
				SwinGame.DrawBitmap ("instruction.png", 0, 0);

				SwinGame.RefreshScreen (60);
				if ((SwinGame.AnyKeyPressed() || SwinGame.MouseClicked(MouseButton.LeftButton) || SwinGame.MouseClicked(MouseButton.RightButton))) {
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
				if ((SwinGame.AnyKeyPressed() || SwinGame.MouseClicked(MouseButton.LeftButton) || SwinGame.MouseClicked(MouseButton.RightButton))) {
					break;
				}
			}
		}


		public void resetvalue (Player p, Trap t, Boss b)
		{
			p.getHealth = 5;
			p.getScore = 0;
			p.getMove.GetX = 325;
			p.getMove.GetY = 325;
			t.getTrap.getSpeed = 5;
			t.getTrap2.getSpeed = 5;
			t.randomposition ();
			t.randomposition2 ();
		}
	}
}

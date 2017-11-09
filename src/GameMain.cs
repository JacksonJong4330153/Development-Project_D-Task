using System;
using SwinGameSDK;

namespace MyGame
{
	public class GameMain
	{
		public static void Main ()
		{
			//Open the game window
			SwinGame.OpenGraphicsWindow ("GameMain", 1000, 600);

			SwinGame.LoadSoundEffect ("coin.wav");
			SwinGame.LoadSoundEffect ("explode.wav");
			SwinGame.LoadSoundEffect ("recover.wav");
			SwinGame.LoadSoundEffect ("gameover.wav");


			Player p = new Player ();

			Trap t = new Trap ();
			Bullet b = new Bullet ();
			b.getBullet.GetX = 0;
			b.getBullet.GetY = 0;
			Boss boss = new Boss ();
			Collision c = new Collision ();

			int bosstimer = 2000;
			Boolean potato = false;
			Movement direction = Movement.Top;

			bool co, co2, co3;
			Font f = SwinGame.LoadFont (SwinGame.PathToResource ("arial.ttf", ResourceKind.FontResource), 30);
			Point2D position, position2;

			position = SwinGame.PointAt (895, 110);
			position2 = SwinGame.PointAt (895, 275);
			Point2D bosstextposition = SwinGame.PointAt (325, 325);

			MapClass m = new MapClass ();

			m.startgame ();
			//Run the game loop
			while (false == SwinGame.WindowCloseRequested ()) {
				//Fetch the next batch of UI interaction
				SwinGame.ProcessEvents ();

				//Clear the screen and draw the framerate
				SwinGame.ClearScreen (Color.White);



				SwinGame.DrawBitmap ("BACK.png", 0, 0);
				SwinGame.DrawText (p.getHealth.ToString (), Color.Red, f, position);
				SwinGame.DrawText (p.getScore.ToString (), Color.Red, f, position2);


				m.draw ();
				p.Draw ();
				t.draw ();


				t.drop ();



				if (SwinGame.KeyTyped (KeyCode.vk_d)) {
					p.go (Movement.Right);

				} else if (SwinGame.KeyTyped (KeyCode.vk_a)) {
					p.go (Movement.Left);

				} else if (SwinGame.KeyTyped (KeyCode.vk_w)) {
					p.go (Movement.Top);

				} else if (SwinGame.KeyTyped (KeyCode.vk_s)) {
					p.go (Movement.Bottom);
				}

				while (potato == false) {
					b.getBullet.GetX = p.getMove.GetX;
					b.getBullet.GetY = p.getMove.GetY;
					break;
				}

				if (SwinGame.KeyTyped (KeyCode.vk_UP)) {
					p.facedirection (Movement.Top);
					direction = Movement.Top;
				} else if (SwinGame.KeyTyped (KeyCode.vk_DOWN)) {
					p.facedirection (Movement.Bottom);
					direction = Movement.Bottom;
				} else if (SwinGame.KeyTyped (KeyCode.vk_LEFT)) {
					p.facedirection (Movement.Left);
					direction = Movement.Left;
				} else if (SwinGame.KeyTyped (KeyCode.vk_RIGHT)) {
					p.facedirection (Movement.Right);
					direction = Movement.Right;
				}

				while (potato == false) {
					b.facedirection (direction);
					break;
				}

				if (SwinGame.KeyTyped (KeyCode.vk_SPACE)) {
					potato = true;
				}

				if (potato == true) {

					b.fire ();

					if (b.getFaceDirection == Movement.Left && b.getBullet.GetX < -10) {
						potato = false;
					} else if (b.getFaceDirection == Movement.Right && b.getBullet.GetX > 700) {
						potato = false;
					} else if (b.getFaceDirection == Movement.Top && b.getBullet.GetY < -10) {
						potato = false;
					} else if (b.getFaceDirection == Movement.Bottom && b.getBullet.GetY > 700) {
						potato = false;
					}

				}

				co = c.CheckCollideTrap1 (p, t);
				co3 = c.CheckCollideTrap2 (p, t);
				if (co == true) {
					p.getHealth = c.AfterCollideTrap (p.getHealth);
					co = false;
					t.randomposition ();
					SwinGame.PlaySoundEffect ("explode.wav");
				}

				if (co3 == true) {
					p.getHealth = c.AfterCollideTrap (p.getHealth);
					co3 = false;
					t.randomposition2 ();
					SwinGame.PlaySoundEffect ("explode.wav");
				}





				if (p.getScore == 0) {
					if (bosstimer != 0) {
						bosstimer = bosstimer - 10;
						SwinGame.DrawText ("Enemy appear!!!!", Color.Red, f, bosstextposition);
					} else if (bosstimer == 0) {
						boss.getBoss.GetY = 0;
						boss.draw ();
						boss.checkTime ();
						boss.bossfire ();
					}
				}

				co2 = c.BulletAndBoss (boss, b);
				if (co2 == true) {
					boss.getBossLife = boss.getBossLife - 1;
					co2 = false;
					p.getScore = p.getScore + 10;
					SwinGame.PlaySoundEffect ("explode.wav");
				}
				//t.checkscore (p.getScore);

				if (p.getHealth == 0) {

					SwinGame.PlaySoundEffect ("gameover.wav");
					m.gameover (p.getScore);
					p.getHealth = 5;
					p.getScore = 0;
					p.getMove.GetX = 325;
					p.getMove.GetY = 325;
					t.getTrap.getSpeed = 5;
					t.getTrap2.getSpeed = 5;
					t.randomposition ();
					t.randomposition2 ();
				}



				//Draw onto the screen
				SwinGame.RefreshScreen (60);
			}
			SwinGame.FreeFont (f);
		}
	}
}
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
			Item i = new Item ();
			Meteor t = new Meteor ();
			Bullet b = new Bullet ();
			Boss boss = new Boss ();
			Collision c = new Collision ();


			InGameTimer ingameTimer = new InGameTimer ();

			int bosstimer = 2000;
			int getHitTimer = 200;
			bool firetrigger = false;
			Movement direction = Movement.Top;

			bool co;
			Font f = SwinGame.LoadFont (SwinGame.PathToResource ("arial.ttf", ResourceKind.FontResource), 30);
			Point2D position, position2,position3;

			position = SwinGame.PointAt (840, 10);
			position2 = SwinGame.PointAt (840, 50);
			position3 = SwinGame.PointAt (100, 50);

			Point2D bosstextposition = SwinGame.PointAt (325, 325);

			MapClass m = new MapClass ();

			m.startgame ("mainmenu");

			//m.drawStartInstruction ("ok");
			//Run the game loop
			while (false == SwinGame.WindowCloseRequested ()) {
				//Fetch the next batch of UI interaction
				SwinGame.ProcessEvents ();

				//Clear the screen and draw the framerate
				SwinGame.ClearScreen (Color.White);



				SwinGame.DrawBitmap ("background.jpg", 0, 0);
				SwinGame.FillRectangle (Color.AliceBlue, 800, 0, 200, 150);
				SwinGame.DrawText ("Health: " + p.getHealth.ToString (), Color.Red, f, position);
				SwinGame.DrawText ("Score: " + p.getScore.ToString (), Color.Purple, f, position2);

				while (p.getMove.GetX == i.getXposition && p.getMove.GetY == i.getYposition) {
					i.randomposition ();
				}

				i.checktime ();

				m.draw ();
				p.Draw ();
				t.draw ();
				i.draw ();

				ingameTimer.drawTimer ();

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

				while (firetrigger == false) {
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

				while (firetrigger == false) {
					b.facedirection (direction);
					break;
				}

				if (SwinGame.KeyTyped (KeyCode.vk_SPACE)) {
					firetrigger = true;
				}

				if (firetrigger == true) {

					b.fire ();

					if (b.getFaceDirection == Movement.Left && b.getBullet.GetX < -10) {
						firetrigger = false;
					} else if (b.getFaceDirection == Movement.Right && b.getBullet.GetX > 990) {
						firetrigger = false;
					} else if (b.getFaceDirection == Movement.Top && b.getBullet.GetY < -10) {
						firetrigger = false;
					} else if (b.getFaceDirection == Movement.Bottom && b.getBullet.GetY > 700) {
						firetrigger = false;
					}

				}

				co = c.CheckCollideTrap1 (p, t);
				if (co == true) {
					p.getHealth = p.getHealth - 1;
					co = false;
					SwinGame.PlaySoundEffect ("explode.wav");
					t.randomposition ();
				}

				co = c.CheckCollideTrap2 (p, t);
				if (co == true) {
					p.getHealth = p.getHealth - 1;
					co = false;
					SwinGame.PlaySoundEffect ("explode.wav");
					t.randomposition2 ();
				}

				co = c.BulletAndBoss (boss, b);
				if (co == true) {
					boss.getBossLife = boss.getBossLife - 1;
					p.getScore = p.getScore + 10;
					boss.checkTime ();
					SwinGame.PlaySoundEffect ("explode.wav");
					co = false;
				}

				co = c.LaserAndPlayer (p, boss);
				if (co == true) {
					if (getHitTimer != 0) {
						getHitTimer = getHitTimer - 10;
					} else if (getHitTimer == 0) {
						p.getHealth = p.getHealth - 1;
						co = false;
						getHitTimer = 200;
						SwinGame.PlaySoundEffect ("explode.wav");
					}
				}


				co = c.BulletAndMeteor1 (b, t, firetrigger);
				if (co == true) {
					p.getScore = p.getScore + 10;
					t.randomposition ();
					firetrigger = false;
					co = false;
					SwinGame.PlaySoundEffect ("coin.wav");
				}

				co = c.BulletAndMeteor2 (b, t, firetrigger);
				if (co == true) {
					p.getScore = p.getScore + 10;
					t.randomposition2 ();
					firetrigger = false;
					co = false;
					SwinGame.PlaySoundEffect ("coin.wav");
				}

				co = c.CheckCollideItem (p, i);
				if (co == true) {
					p.getHealth = p.getHealth + 1;
					i.getXposition = -100;
					i.getYposition = -100;
					SwinGame.PlaySoundEffect ("recover.wav");
					co = false;
				}


				if (p.getScore > 50) {
					if (bosstimer != 0) {
						bosstimer = bosstimer - 10;
						SwinGame.DrawText ("Enemy appear!!!!", Color.Red, SwinGame.LoadFont (SwinGame.PathToResource ("arial.ttf", ResourceKind.FontResource), 50), bosstextposition);
					} else if (bosstimer == 0) {

						boss.getBoss.GetY = 0;
						boss.draw ();
						boss.checkTime ();
						boss.bossfire ();
					}
				}

				if (bosstimer == 0 && boss.getBossLife != 0) {
					SwinGame.DrawText ("BossHealth: " + boss.getBossLife.ToString (), Color.White, f, position3);
				}

				if (boss.getBossLife == 0) {
					boss = new Boss ();
				}

				if (p.getHealth == 0 || m.getEnd == true) {

					SwinGame.PlaySoundEffect ("gameover.wav");

					m.gameover (p.getScore, ingameTimer.getTimer.ToString ());
					ingameTimer.getX = 0;
					ingameTimer.drawTimer ();
					p = new Player ();
					t = new Meteor ();
					boss = new Boss ();
					i = new Item ();
					i.checktime ();
					bosstimer = 2000;
					//boss = new Boss ();


					m.getRestart = false;
					m.getEnd = false;
				}

				if (m.getRestart == true) {
					ingameTimer.getX = 0;
					ingameTimer.drawTimer ();

					bosstimer = 2000;

					p = new Player ();
					t = new Meteor ();
					boss = new Boss ();
					i = new Item ();
					i.checktime ();
					m.getRestart = false;
				}

				//get pause game screen
				if (SwinGame.KeyTyped (KeyCode.vk_ESCAPE)){
					m.startgame ("pausemenu");
				}

				//Draw onto the screen
				SwinGame.RefreshScreen (60);
			}
			SwinGame.FreeFont (f);
		}
	}
}
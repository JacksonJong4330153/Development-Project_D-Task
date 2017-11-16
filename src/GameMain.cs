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
			boss.getBossLife = 2;
			Collision c = new Collision ();
			InGameTimer ingameTimer = new InGameTimer ();

			int bosstimer = 2000;
			int getHitTimer = 200;
			bool potato = false;
			Movement direction = Movement.Top;

			bool co, co2, co3,co4,co5,co6;
			Font f = SwinGame.LoadFont (SwinGame.PathToResource ("arial.ttf", ResourceKind.FontResource), 25);
			Point2D position, position2,position3;

			position = SwinGame.PointAt (225, 570);
			position2 = SwinGame.PointAt (425, 570);
			position3 = SwinGame.PointAt (625, 50);

			Point2D bosstextposition = SwinGame.PointAt (325, 325);

			MapClass m = new MapClass ();

			m.startgame ("mainmenu");
			//Run the game loop
			while (false == SwinGame.WindowCloseRequested ()) {
				//Fetch the next batch of UI interaction
				SwinGame.ProcessEvents ();

				//Clear the screen and draw the framerate
				SwinGame.ClearScreen (Color.White);



				SwinGame.DrawBitmap ("background.jpg", 0, 0);
				SwinGame.DrawText ("Health: "+p.getHealth.ToString (), Color.PaleVioletRed, f, position);
				SwinGame.DrawText ("Score: "+p.getScore.ToString (), Color.White, f, position2);



				m.draw ();
				p.Draw ();
				t.draw ();

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
					} else if (b.getFaceDirection == Movement.Right && b.getBullet.GetX > 990) {
						potato = false;
					} else if (b.getFaceDirection == Movement.Top && b.getBullet.GetY < -10) {
						potato = false;
					} else if (b.getFaceDirection == Movement.Bottom && b.getBullet.GetY > 700) {
						potato = false;
					}

				}

				co = c.CheckCollideTrap1 (p, t);
				if (co == true) {
					p.getHealth = c.AfterCollideTrap (p.getHealth);
					co = false;
					t.randomposition ();
					SwinGame.PlaySoundEffect ("explode.wav");
				}

				co2 = c.BulletAndBoss (boss, b);
				if (co2 == true) {
					boss.getBossLife = boss.getBossLife - 1;
					p.getScore = p.getScore + 10;
					boss.checkTime ();
					SwinGame.PlaySoundEffect ("explode.wav");
					co2 = false;
				}

				co3 = c.CheckCollideTrap2 (p, t);
				if (co3 == true) {
					p.getHealth = c.AfterCollideTrap (p.getHealth);
					co3 = false;
					t.randomposition2 ();
					SwinGame.PlaySoundEffect ("explode.wav");
				}

				co4 = c.LaserAndPlayer (p, boss);
				if (co4 == true) {
					if (getHitTimer != 0) {
						getHitTimer = getHitTimer - 10;
					}else if(getHitTimer == 0){
						p.getHealth = p.getHealth - 1;
						co4 = false;
						getHitTimer = 200;
					}
				}


				co5 = c.BulletAndMeteor1 (b, t,potato);
				if (co5 == true) {
					p.getScore = p.getScore + 10;
					t.randomposition ();
					potato = false;
					co5 = false;
				}

				co6 = c.BulletAndMeteor2 (b, t,potato);
				if (co6 == true){
					p.getScore = p.getScore + 10;
					t.randomposition2 ();
					potato = false;
					co6 = false;
				}


				if (p.getScore > 0) {
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
					SwinGame.DrawText ("BossHealth: "+boss.getBossLife.ToString (), Color.White, f, position3);
				}

				if (boss.getBossLife == 0) {
					boss.getBoss.GetX = -200;
				} 

				if (p.getHealth == 0 || m.getRestart == true) {

					SwinGame.PlaySoundEffect ("gameover.wav");

					m.gameover (p.getScore, ingameTimer.getTimer.ToString ());
					ingameTimer.getX = 0;
					ingameTimer.drawTimer ();
					m.resetvalue (p, t, boss);
					bosstimer = 2000;
					boss = new Boss ();
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
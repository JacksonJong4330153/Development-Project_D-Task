using System;
using SwinGameSDK;

namespace MyGame
{
    public class GameMain
    {
        public static void Main()
        {
            //Open the game window
            SwinGame.OpenGraphicsWindow("GameMain", 1000, 600);
            
			SwinGame.LoadSoundEffect("coin.wav");
			SwinGame.LoadSoundEffect ("explode.wav");
			SwinGame.LoadSoundEffect ("recover.wav");
			SwinGame.LoadSoundEffect ("gameover.wav");


			Player p = new Player ();
			Item i = new Item ();
			Trap t = new Trap ();
			Collision c = new Collision ();

			bool co, co2,co3;
			Font f = SwinGame.LoadFont (SwinGame.PathToResource ("arial.ttf", ResourceKind.FontResource), 30);
			Point2D position, position2;

			position = SwinGame.PointAt (895, 110);
			position2 = SwinGame.PointAt (895, 275);

			MapClass m = new MapClass ();

			m.startgame ();
            //Run the game loop
            while(false == SwinGame.WindowCloseRequested())
            {
                //Fetch the next batch of UI interaction
                SwinGame.ProcessEvents();
                
                //Clear the screen and draw the framerate
                SwinGame.ClearScreen(Color.White);


				SwinGame.DrawBitmap ("BACK.png", 0, 0);
				SwinGame.DrawText (p.getHealth.ToString (), Color.Red,f, position);
				SwinGame.DrawText (p.getScore.ToString (), Color.Red,f, position2);


				m.draw ();
				p.Draw ();
				t.draw ();

				while (p.getMove.GetX == i.getXposition && p.getMove.GetY == i.getYposition) {
					i.randomposition ();
				}

				i.draw ();

				t.drop ();


				i.checktime ();


				if (SwinGame.KeyTyped (KeyCode.vk_d) || SwinGame.KeyTyped (KeyCode.vk_RIGHT)) {
					p.go (Movement.Right);
				} else if (SwinGame.KeyTyped (KeyCode.vk_a) || SwinGame.KeyTyped (KeyCode.vk_LEFT)) {
					p.go (Movement.Left);
				} else if (SwinGame.KeyTyped (KeyCode.vk_w) || SwinGame.KeyTyped (KeyCode.vk_UP)) {
					p.go (Movement.Top);
				} else if (SwinGame.KeyTyped (KeyCode.vk_s) || SwinGame.KeyTyped (KeyCode.vk_DOWN)) {
					p.go (Movement.Bottom);
				}

				co = c.CheckCollideTrap1 (p,t);
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

				co2 = c.CheckCollideItem (p,i);
				if (co2 == true) {
					if (i.getItem == ItemType.coin) {
						p.getScore = c.AfterCollideItemAffectScore(p.getHealth,p.getScore);
						co2 = false;
						i.getXposition = -100;
						i.getYposition = -100;
						SwinGame.PlaySoundEffect ("coin.wav");
					} else if (i.getItem == ItemType.health && p.getHealth < 5) {
						p.getHealth = c.AfterCollideItemAffectHp (p.getHealth,i.getItem);
						co2 = false;
						i.getXposition = -100;
						i.getYposition = -100;
						SwinGame.PlaySoundEffect ("recover.wav");
					} else if (i.getItem == ItemType.health && p.getHealth > 4) {
						p.getScore = c.AfterCollideItemAffectScore (p.getHealth, p.getScore);
						co2 = false;
						i.getXposition = -100;
						i.getYposition = -100;
						SwinGame.PlaySoundEffect ("coin.wav");
					} else if (i.getItem == ItemType.bomb) {
						p.getHealth = c.AfterCollideItemAffectHp (p.getHealth,i.getItem);
						co2 = false;
						i.getXposition = -100;
						i.getYposition = -100;
						SwinGame.PlaySoundEffect ("explode.wav");
					}
					 
				}


				t.checkscore (p.getScore);

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
                SwinGame.RefreshScreen(60);
            }
			SwinGame.FreeFont (f);
        }
    }
}
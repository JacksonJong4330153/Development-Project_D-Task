using System;
using SwinGameSDK;
using System.Collections.Generic;

namespace MyGame
{
	public class Bullet
	{

		private ProjectileObjectMovement _bullet;
		private Movement _facedirection;

		public Bullet ()
		{
			_bullet = new ProjectileObjectMovement ();
			_facedirection = Movement.Top;
		}

		public ProjectileObjectMovement getBullet {
			get { return _bullet; }
			set { _bullet = value; }
		}

		public Movement getFaceDirection {
			get { return _facedirection; }
		}

		public void facedirection (Movement move)
		{
			_facedirection = move;
		}

		public void fire ()
		{
			if (getFaceDirection == Movement.Left) {
				SwinGame.DrawBitmap ("bulletleft.png", getBullet.GetX, getBullet.GetY);
			} else if (getFaceDirection == Movement.Right) {
				SwinGame.DrawBitmap ("bulletright.png", getBullet.GetX, getBullet.GetY);
			} else { 
				SwinGame.DrawBitmap ("bullet.png", getBullet.GetX, getBullet.GetY);
			}
			getBullet.Moving (_facedirection);
		}


	}
}

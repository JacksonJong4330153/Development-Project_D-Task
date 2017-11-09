using System;
using SwinGameSDK;
using System.Collections.Generic;

namespace MyGame
{
	public class Bullet
	{

		private TrapMovement _bullet;
		private Movement _facedirection;

		public Bullet ()
		{
			_bullet = new TrapMovement ();
			_facedirection = Movement.Top;
		}

		public TrapMovement getBullet {
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
			SwinGame.DrawBitmap ("bullet.png", getBullet.GetX, getBullet.GetY);
			getBullet.Moving (_facedirection);
		}


	}
}

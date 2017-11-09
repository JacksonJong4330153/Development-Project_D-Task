using System;
using SwinGameSDK;

namespace MyGame
{
	public class Player
	{
		private int _score;
		private int _health;

		private Movement _facedirection;
		private PlayerMovement _pmove;
		private TrapMovement _bullet;

		public Player ()
		{
			_pmove = new PlayerMovement ();
			_health = 5;
			_score = 0;

			_bullet = new TrapMovement ();
			_facedirection = Movement.Top;
		}

		public TrapMovement _getBullet {
			get { return _bullet; }
			set { _bullet = value; }
		}


		public int getScore {
			get { return _score; }
			set { _score = value; }
		}

		public int getHealth {
			get { return _health; }
			set { _health = value; }
		}

		public Movement getFaceDirection {
			get { return _facedirection; }
		}

		public PlayerMovement getMove {
			get { return _pmove; }
		}

		public void Draw ()
		{
			if (getFaceDirection == Movement.Left) {
				SwinGame.DrawBitmap ("ship.left.png", _pmove.GetX, _pmove.GetY);
			} else if (getFaceDirection == Movement.Right) {
				SwinGame.DrawBitmap ("ship.right.png", _pmove.GetX, _pmove.GetY);
			} else if (getFaceDirection == Movement.Bottom) {
				SwinGame.DrawBitmap ("ship.bottom.png", _pmove.GetX, _pmove.GetY);
			} else {
				SwinGame.DrawBitmap ("ship.top.png", _pmove.GetX, _pmove.GetY);
			}

		}

		public void go (Movement move)
		{
			getMove.Moving (move);
		}

		public void facedirection (Movement move)
		{
			_facedirection = move;
		}


		public void fire ()
		{
			SwinGame.DrawBitmap ("bullet.png", _getBullet.GetX, _getBullet.GetY);
			_getBullet.Moving (getFaceDirection);
		}

	}
}

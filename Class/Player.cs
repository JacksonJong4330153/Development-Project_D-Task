using System;
using SwinGameSDK;

namespace MyGame
{
	public class Player
	{
		private int _score;
		private int _health;

		private PlayerMovement _move;

		public Player ()
		{
			_move = new PlayerMovement ();
			_health = 5;
			_score = 0;
		}

		public int getScore {
			get { return _score; }
			set { _score = value; }
		}

		public int getHealth {
			get { return _health; }
			set { _health = value; }
		}

		public PlayerMovement getMove {
			get { return _move; }
		}

		public void Draw ()
		{
			SwinGame.DrawBitmap ("ship.png", _move.GetX, _move.GetY);
		}

		public void go (Movement move)
		{
			getMove.Moving (move);
		}
	}
}

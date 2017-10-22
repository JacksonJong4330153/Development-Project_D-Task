using System;
using SwinGameSDK;
namespace MyGame
{
	public class Trap
	{
		private Movement _move,_move2;
		private TrapMovement _trapmove,_trapmove2;

		public Trap ()
		{
			_move = new Movement ();
			_move2 = new Movement ();
			_trapmove = new TrapMovement ();
			_trapmove2 = new TrapMovement ();
		}

		public TrapMovement getTrap {
			get { return _trapmove; }
			set { _trapmove = value; }
		}

		public TrapMovement getTrap2 {
			get { return _trapmove2; }
			set { _trapmove2 = value; }
		}

		public void checkscore (int score)
		{
			if (score == 100 && getTrap.getSpeed == 5) {
				getTrap.getSpeed = getTrap.getSpeed + 2;
			} else if (score == 200 && getTrap.getSpeed == 7) {
				getTrap.getSpeed = getTrap.getSpeed + 2;
			} else if (score == 300 && getTrap.getSpeed == 9) {
				getTrap.getSpeed = getTrap.getSpeed + 1;
				getTrap2.getSpeed = 9;

			}
		}

		public void randomposition ()
		{
			Random r = new Random ();
			int random = r.Next (0, 12);

			if (random == 0) {
				getTrap.GetX = 225;
				getTrap.GetY = -10;
				_move = Movement.Bottom;
			} else if (random == 1) {
				getTrap.GetX = 325;
				getTrap.GetY = -10;
				_move = Movement.Bottom;
			} else if (random == 2) {
				getTrap.GetX = 425;
				getTrap.GetY = -10;
				_move = Movement.Bottom;
			} else if (random == 3) {
				getTrap.GetX = -10;
				getTrap.GetY = 225;
				_move = Movement.Right;
			} else if (random == 4) {
				getTrap.GetX = -10;
				getTrap.GetY = 325;
				_move = Movement.Right;
			} else if (random == 5) {
				getTrap.GetX = -10;
				getTrap.GetY = 425;
				_move = Movement.Right;
			} else if (random == 6) {
				getTrap.GetX = 225;
				getTrap.GetY = 700;
				_move = Movement.Top;
			} else if (random == 7) {
				getTrap.GetX = 325;
				getTrap.GetY = 700;
				_move = Movement.Top;
			} else if (random == 8) {
				getTrap.GetX = 425;
				getTrap.GetY = 700;
				_move = Movement.Top;
			} else if (random == 9) {
				getTrap.GetX = 700;
				getTrap.GetY = 225;
				_move = Movement.Left;
			} else if (random == 10) {
				getTrap.GetX = 700;
				getTrap.GetY = 325;
				_move = Movement.Left;
			} else if (random == 11) {
				getTrap.GetX = 700;
				getTrap.GetY = 425;
				_move = Movement.Left;
			}
		}

		public void randomposition2 ()
		{
			Random r = new Random ();
			int random = r.Next (0, 12);

			if (random == 1) {
				getTrap2.GetX = 225;
				getTrap2.GetY = -10;
				_move2 = Movement.Bottom;
			} else if (random == 0) {
				getTrap2.GetX = 325;
				getTrap2.GetY = -10;
				_move2 = Movement.Bottom;
			} else if (random == 3) {
				getTrap2.GetX = 425;
				getTrap2.GetY = -10;
				_move2 = Movement.Bottom;
			} else if (random == 5) {
				getTrap2.GetX = -10;
				getTrap2.GetY = 225;
				_move2 = Movement.Right;
			} else if (random == 7) {
				getTrap2.GetX = -10;
				getTrap2.GetY = 325;
				_move2 = Movement.Right;
			} else if (random == 6) {
				getTrap2.GetX = -10;
				getTrap2.GetY = 425;
				_move2 = Movement.Right;
			} else if (random == 4) {
				getTrap2.GetX = 225;
				getTrap2.GetY = 700;
				_move2 = Movement.Top;
			} else if (random == 7) {
				getTrap2.GetX = 325;
				getTrap2.GetY = 700;
				_move2 = Movement.Top;
			} else if (random == 11) {
				getTrap2.GetX = 425;
				getTrap2.GetY = 700;
				_move2 = Movement.Top;
			} else if (random == 10) {
				getTrap2.GetX = 700;
				getTrap2.GetY = 225;
				_move2 = Movement.Left;
			} else if (random == 9) {
				getTrap2.GetX = 700;
				getTrap2.GetY = 325;
				_move2 = Movement.Left;
			} else if (random == 8) {
				getTrap2.GetX = 700;
				getTrap2.GetY = 425;
				_move2 = Movement.Left;
			}
		}


		public void draw ()
		{
			SwinGame.DrawBitmap ("batu.png", getTrap.GetX, getTrap.GetY);
			SwinGame.DrawBitmap ("batu.png", getTrap2.GetX, getTrap2.GetY);
		}

		public void drop ()
		{
			getTrap.Moving (_move);
			getTrap2.Moving (_move2);

			if (getTrap.GetY > 700) {
				randomposition ();
			} else if (getTrap.GetX > 700) {
				randomposition ();
			} else if (getTrap.GetY < -10) {
				randomposition ();
			} else if (getTrap.GetX < -10) {
				randomposition ();
			}


			if (getTrap2.GetY > 700) {
				randomposition2 ();
			} else if (getTrap2.GetX > 700) {
				randomposition2 ();
			} else if (getTrap2.GetY < -10) {
				randomposition2 ();
			} else if (getTrap2.GetX < -10) {
				randomposition2 ();
			}
		}
	}
}

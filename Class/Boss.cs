using System;
using System.Collections.Generic;
using SwinGameSDK;
namespace MyGame
{
	public class Boss
	{
		private TrapMovement _boss;
		private int _time;
		Random random_generator = new Random ();
		List<int> Position = new List<int> { 225, 325, 425 };
		public Boss ()
		{
			_boss = new TrapMovement ();
			_boss.GetX = 325;
			_boss.GetY = -100;

		}
		public TrapMovement getBoss {
			get { return _boss; }
			set { this._boss = value; }
		}
		public void draw ()
		{
			SwinGame.DrawBitmap ("boss.png", getBoss.GetX, getBoss.GetY);
		}
		public void checkTime () {
			if (_time != 0) {
				_time = _time - 10;
			}
			if (_time == 0) {
				if (_boss.GetX == 325)
					_boss.GetX = 225;
				else if (_boss.GetX == 225)
					_boss.GetX = 425;
				else if (_boss.GetX == 425)
					_boss.GetX = 325;
				_time = 2000;
			}
		}
	}
}

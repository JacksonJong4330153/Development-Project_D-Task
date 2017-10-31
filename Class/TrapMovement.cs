using System;
namespace MyGame
{
	public class TrapMovement : Move
	{
		private int _speed;

		public TrapMovement ()
		{
			_speed = 5;
		}

		public int getSpeed {
			get { return _speed; }
			set { _speed = value; }
		}

		public override void Moving (Movement move)
		{
			if (move == Movement.Bottom) {
				GetY = GetY + _speed;
			} else if (move == Movement.Right) {
				GetX = GetX + _speed;
			} else if (move == Movement.Top) {
				GetY = GetY - _speed;
			} else if (move == Movement.Left) {
				GetX = GetX - _speed;
			}
		}
	}
}

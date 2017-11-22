using System;
namespace MyGame
{
	public class ProjectileObjectMovement : Move
	{
		private int _speed;

		public ProjectileObjectMovement ()
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

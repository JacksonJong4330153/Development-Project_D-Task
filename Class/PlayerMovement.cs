using System;
using SwinGameSDK;
namespace MyGame
{
	public class PlayerMovement : Move
	{
		public PlayerMovement ()
		{
			GetX = 325;
			GetY = 325;
		}

		public override void Moving (Movement move)
		{
			if (move == Movement.Top) {
				if (GetY > 225) {
					GetY = GetY - 100;
				}
			} else if (move == Movement.Bottom) {
				if (GetY < 425) {
					GetY = GetY + 100;
				}
			} else if (move == Movement.Left) {
				if (GetX > 225) {
					GetX = GetX - 100;
				}
			} else if (move == Movement.Right) {
				if (GetX < 425) {
					GetX = GetX + 100;
				}
			}
		}


	}
}

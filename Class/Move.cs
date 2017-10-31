using System;
using SwinGameSDK;
namespace MyGame
{
	public abstract class Move
	{
		private int _x, _y;

		public Move ()
		{
		}

		public int GetX {
			get { return _x;}
			set { _x = value; }
		}

		public int GetY {
			get { return _y; }
			set { _y = value; }
		}

		public abstract void Moving (Movement move);
	}
}

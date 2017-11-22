using System;
using SwinGameSDK;
using System.Collections.Generic;
namespace MyGame
{
	public class Item
	{
		private int _xposition;
		private int _yposition;

		private int _time;
		Random random_generator = new Random ();

		List<int> PostitionX = new List<int> { 225 + 100, 325 + 100, 425 + 100 };
		List<int> PostitionY = new List<int> { 225, 325, 425 };

		public Item ()
		{
			_item = new ItemType ();
			_time = 5000;
			randomposition ();
		}

		public int getXposition {
			get { return _xposition; }
			set { _xposition = value; }
		}

		public int getYposition {
			get { return _yposition; }
			set { _yposition = value; }
		}

		public void randomposition ()
		{
			_xposition = PostitionX [random_generator.Next (0, 3)];
			_yposition = PostitionY [random_generator.Next (0, 3)];
		}

		public void draw ()
		{
			SwinGame.DrawBitmap ("tools.png", _xposition, _yposition);	
		}

		public void checktime ()
		{
			if (_time != 0) {
				_time = _time - 10;
			}
			if (_time == 0) {
				randomposition ();
				_time = 10000;
			}
		}
	}
}

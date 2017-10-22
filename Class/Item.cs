using System;
using SwinGameSDK;
namespace MyGame
{
	public class Item
	{
		private int _xposition;
		private int _yposition;

		private ItemType _item;
		private int _time;
		private bool _check;

		public Item ()
		{
			_item = new ItemType ();
			_check = false;
			_time = 2000;

			randomposition ();
		}

		public bool getCheck
		{
			get { return _check; }
			set { _check = value; }
		}

		public int getXposition {
			get { return _xposition; }
			set { _xposition = value; }
		}

		public int getYposition {
			get { return _yposition; }
			set { _yposition = value; }
		}

		public ItemType getItem {
			get { return _item; }
			set { _item = value; }
		}

		public void randomposition ()
		{
			Random r = new Random ();
			int random = r.Next (0, 9);

			if (random == 0) {
				_xposition = 225;
				_yposition = 225;
			} else if (random == 1) {
				_xposition = 325;
				_yposition = 225;
			} else if (random == 2) {
				_xposition = 425;
				_yposition = 225;
			} else if (random == 3) {
				_xposition = 225;
				_yposition = 325;
			} else if (random == 4) {
				_xposition = 225;
				_yposition = 425;
			} else if (random == 5) {
				_xposition = 325;
				_yposition = 325;
			} else if (random == 6) {
				_xposition = 325;
				_yposition = 425;
			} else if (random == 7) {
				_xposition = 425;
				_yposition = 425;
			} else if (random == 8) {
				_xposition = 425;
				_yposition = 325;
			} 
		}

		public void randomItem ()
		{
			Random r2 = new Random ();
			int random2 = r2.Next (0, 100);

			if (random2 <= 50) {
				_item = ItemType.bomb;
			} else if (random2 > 50 && random2 < 75) {
				_item = ItemType.coin;
			} else {
				_item = ItemType.health;
			}
		}

		public void draw ()
		{
			if (_item == ItemType.coin) {
				SwinGame.DrawBitmap ("coin1.png", _xposition, _yposition);
			} else if (_item == ItemType.health) {
				SwinGame.DrawBitmap ("tools.png", _xposition, _yposition);
			} else if (_item == ItemType.bomb) {
				SwinGame.DrawBitmap ("bomb.png", _xposition, _yposition);
			}
		}

		public void checktime ()
		{
			if (_time != 0) {
				_time = _time - 10;
			}

			if (_time == 0) {
				randomposition ();
				randomItem ();
				_time = 2000;
			}
		}
	}
}

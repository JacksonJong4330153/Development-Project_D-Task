using System;
using System.Collections.Generic;
using SwinGameSDK;
namespace MyGame
{
	public class Boss
	{
		private ProjectileObjectMovement _boss;

		private int _time;
		private int _bosshp;
		private int _firetime;
		private int _currentPosition;
		private int _spawnPosition;

		bool Isfire;

		//private int firepositionx, firepositiony;

		Random random_generator = new Random ();
		List<int> Position = new List<int> { 225, 325, 425 };
		List<int> PositionX = new List<int> { 225+100, 325+100, 425+100 };
		List<int> RandomTime = new List<int> { 10, 20, 40 };

		public Boss ()
		{
			_boss = new ProjectileObjectMovement ();
			_boss.GetX = 325+100;
			_boss.GetY = -100;
			_bosshp = 5;
			Isfire = false;
		}
		public ProjectileObjectMovement getBoss {
			get { return _boss; }
			set { this._boss = value; }
		}

		public int getBossLife {
			get { return _bosshp; }
			set { _bosshp = value; }
		}

		public bool _getfire {
			get { return Isfire;}
			set { Isfire = value; }
		}


		public void draw ()
		{
			SwinGame.DrawBitmap ("boss.png", getBoss.GetX, getBoss.GetY);
		}

		public void checkTime ()
		{
			if (_time != 0) {
				_time = _time - (RandomTime [random_generator.Next (0, 3)]);
			}
			if (_time <= 0) {
				_boss.GetX = PositionX [random_generator.Next (0, 3)];
				_currentPosition = _boss.GetX;
				_time = 4000;
			}
		}

		public void spawnBoss ()
		{
			_spawnPosition = Position [random_generator.Next (0, 3)];
			while (_spawnPosition == _currentPosition){
				_spawnPosition = PositionX [random_generator.Next (0, 3)];
				_boss.GetX = _spawnPosition;
			}
		}

		public void bossfire ()
		{
			if (_time >= 1000 && _time <= 3000) {
				Isfire = true;
				do {
					if (_firetime != 0) {
						_firetime = _firetime - 10;
					}
					SwinGame.DrawBitmap ("laser.png", _boss.GetX + 25, _boss.GetY + 25);


				} while (_firetime != 0);

			} else {
				Isfire = false;
			}
		}
	}
}

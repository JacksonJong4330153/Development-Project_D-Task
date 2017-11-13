﻿using System;
using System.Collections.Generic;
using SwinGameSDK;
namespace MyGame
{
	public class Boss
	{
		private TrapMovement _boss;
		private int _time;
		private int _bosshp;
		private int _firetime;
		private int _currentPosition;
		private int _spawnPosition;

		Random random_generator = new Random ();
		List<int> Position = new List<int> { 225, 325, 425 };
		List<int> RandomTime = new List<int> { 10, 20, 40 };

		public Boss ()
		{
			_boss = new TrapMovement ();
			_boss.GetX = 325;
			_boss.GetY = -100;
			_bosshp = 20;
		}
		public TrapMovement getBoss {
			get { return _boss; }
			set { this._boss = value; }
		}

		public int getBossLife {
			get { return _bosshp; }
			set { _bosshp = value; }
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
				_boss.GetX = Position [random_generator.Next (0, 3)];
				_currentPosition = _boss.GetX;
				_time = 4000;
			}
		}

		public void spawnBoss ()
		{
			_spawnPosition = Position [random_generator.Next (0, 3)];
			while (_spawnPosition == _currentPosition){
				_spawnPosition = Position [random_generator.Next (0, 3)];
				_boss.GetX = _spawnPosition;
			}
		}

		public void bossfire ()
		{
			if (_time >= 1000 && _time <= 3000) {
				do {
					if (_firetime != 0) {
						_firetime = _firetime - 10;
					}
					SwinGame.DrawBitmap ("laser.png", getBoss.GetX+25, getBoss.GetY + 25);

				} while (_firetime != 0);
			}
		}
	}
}

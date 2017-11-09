using System;
using System.Collections.Generic;
using SwinGameSDK;

namespace MyGame
{
	public class Trap
	{

		private TrapMovement _trapmove, _trapmove2;
		Random random_generator = new Random ();
		//Random r3;
		List<int> Postition = new List<int> { 225, 325, 425 };
		List<String> MeteorType = new List<string> { "meteorSmall.png", "meteorMedium.png", "meteorBig.png" };
		String meteor1;
		String meteor2;

		List<Movement> testmove = new List<Movement> { Movement.Top, Movement.Bottom, Movement.Left, Movement.Right };
		private Movement _getmove;
		private Movement _getmove2;

		public Trap ()
		{

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

		public void checkMeteorType ()
		{
			if (meteor1 == "meteorSmall.png") {
				getTrap.getSpeed = 150;
			} else if (meteor1 == "meteorMedium.png") {
				getTrap.getSpeed = 50;
			} else if (meteor1 == "meteorBig.png"){
				getTrap.getSpeed = 10;
			}

			if (meteor2 == "meteorSmall.png") {
				getTrap2.getSpeed = 150;
			} else if (meteor2 == "meteorMedium.png") {
				getTrap2.getSpeed = 50;
			} else if (meteor2 == "meteorBig.png"){
				getTrap2.getSpeed = 10;
			}
		}

		/*public void checkscore (int score)
		{
			if (score == 100 && getTrap.getSpeed == 5) {
				getTrap.getSpeed = getTrap.getSpeed + 2;
			} else if (score == 200 && getTrap.getSpeed == 7) {
				getTrap.getSpeed = getTrap.getSpeed + 2;
			} else if (score == 300 && getTrap.getSpeed == 9) {
				getTrap.getSpeed = getTrap.getSpeed + 1;
				getTrap2.getSpeed = 9;

			}
		}*/

		public void randomposition ()
		{
			if (random_generator.Next (0, 2) == 0) { // let 0 = x axis
				if (random_generator.Next (0, 2) == 0) { //let 0 be y = -10
					getTrap.GetY = -100;
				} else { //let 1 be y = 700
					getTrap.GetY = 800;
				}
				getTrap.GetX = Postition [random_generator.Next (0, 3)];

				_getmove = testmove [random_generator.Next (0, 2)]; // let 0 = top, 1 = bottom

			} else { // let 1 = y axis
				if (random_generator.Next (0, 2) == 0) { //let 0 be x = -10
					getTrap.GetX = -100;
				} else { //let 1 be x = 700
					getTrap.GetX = 800;
				}
				getTrap.GetY = Postition [random_generator.Next (0, 3)];

				_getmove = testmove [random_generator.Next (2, 4)]; // let 2 = left, 3 = right

				meteor1 = MeteorType [random_generator.Next (0, 3)]; // generate random meteor type
				//Console.WriteLine ("meteor1 = " + meteor1);
			}

			//r3 = new Random ();
			//int random = r1.Next (0, 2);
			//int randomDirection = r3.Next (0, 4);

			//_getmove = testmove [randomDirection];

			//if (_getmove == Movement.Left) {
			//	getTrap.GetX = 700;
			//	getTrap.GetY = Postition1 [random];
			//	Console.WriteLine ("Direction = " + _getmove + ", y = " + Postition1[random]);
			//} else if (_getmove == Movement.Right) {
			//	getTrap.GetX = -10;
			//	getTrap.GetY = Postition1 [random];
			//	Console.WriteLine ("Direction = " + _getmove + ", y = " + Postition1[random]);
			//} else if (_getmove == Movement.Top) {
			//	getTrap.GetX = Postition1 [random];
			//	getTrap.GetY = 700;
			//	Console.WriteLine ("Direction = " + _getmove + ", x = " + Postition1[random]);
			//} else if (_getmove == Movement.Bottom) {
			//	getTrap.GetX = Postition1 [random];
			//	getTrap.GetY = -10;
			//	Console.WriteLine ("Direction = " + _getmove + ", x = " + Postition1[random]);
			//}
		}

		public void randomposition2 ()
		{
			if (random_generator.Next (0, 2) == 0) { // let 0 = x axis

				if (random_generator.Next (0, 2) == 0) { //let 0 be y = -10
					getTrap2.GetY = -100;
				} else { //let 1 be y = 700
					getTrap2.GetY = 800;
				}
				getTrap2.GetX = Postition [random_generator.Next (0, 3)];

				_getmove2 = testmove [random_generator.Next (0, 2)]; // let 0 = top, 1 = bottom

			} else { // let 1 = y axis
				if (random_generator.Next (0, 2) == 0) { //let 0 be x = -10
					getTrap2.GetX = -100;
				} else { //let 1 be x = 700
					getTrap2.GetX = 800;
				}
				getTrap2.GetY = Postition [random_generator.Next (0, 3)];

				_getmove2 = testmove [random_generator.Next (2, 4)]; // let 2 = left, 3 = right

				meteor2 = MeteorType [random_generator.Next (0, 3)]; // generate random meteor type
				//Console.WriteLine ("meteor2 = " + meteor2);
			}

			//r1 = new Random ();
			//r2 = new Random ();
			//int random = r1.Next (0, 3);

			//int randomDirection = r2.Next (0, 4);

			//_getmove = testmove [randomDirection];

			//if (_getmove == Movement.Left) {
			//	getTrap.GetX = 700;
			//	getTrap.GetY = Postition [random];
			//} else if (_getmove == Movement.Right) {
			//	getTrap.GetX = -10;
			//	getTrap.GetY = Postition [random];
			//} else if (_getmove == Movement.Top) {
			//	getTrap.GetX = Postition [random];
			//	getTrap.GetY = 700;
			//} else if (_getmove == Movement.Bottom) {
			//	getTrap.GetX = Postition [random];
			//	getTrap.GetY = -10;
			//}
		}


		public void draw ()
		{
			SwinGame.DrawBitmap (meteor1, getTrap.GetX, getTrap.GetY);
			SwinGame.DrawBitmap (meteor2, getTrap2.GetX, getTrap2.GetY);
		}

		public void drop ()
		{
			getTrap.Moving (_getmove);
			getTrap2.Moving (_getmove2);

			if (_getmove == Movement.Left && getTrap.GetX < -10) {
				randomposition ();
			} else if (_getmove == Movement.Right && getTrap.GetX > 700) {
				randomposition ();
			} else if (_getmove == Movement.Top && getTrap.GetY < -10) {
				randomposition ();
			} else if (_getmove == Movement.Bottom && getTrap.GetY > 700) {
				randomposition ();
			}

			if (_getmove2 == Movement.Left && getTrap2.GetX < -10) {
				randomposition2 ();
			} else if (_getmove2 == Movement.Right && getTrap2.GetX > 700) {
				randomposition2 ();
			} else if (_getmove2 == Movement.Top && getTrap2.GetY < -10) {
				randomposition2 ();
			} else if (_getmove2 == Movement.Bottom && getTrap2.GetY > 700) {
				randomposition2 ();
			}

			//if (getTrap2.GetY > 700) {
			//	randomposition2 ();
			//} else if (getTrap2.GetX > 700) {
			//	randomposition2 ();
			//} else if (getTrap2.GetY < -10) {
			//	randomposition2 ();
			//} else if (getTrap2.GetX < -10) {
			//	randomposition2 ();
			//}
		}

	}
}

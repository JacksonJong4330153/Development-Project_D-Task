using System;
using System.Collections.Generic;
using SwinGameSDK;

namespace MyGame
{
	public class Meteor
	{

		private ProjectileObjectMovement _objectmove1, _objectmove2;
		Random random_generator = new Random ();
		List<int> PostitionX = new List<int> { 225+100, 325+100, 425+100 };
		List<int> PostitionY = new List<int> { 225, 325, 425 };
		List<String> MeteorType = new List<string> { "meteorSmall.png", "meteorMedium.png", "meteorBig.png" };
		String meteor1;
		String meteor2;

		List<Movement> testmove = new List<Movement> { Movement.Top, Movement.Bottom, Movement.Left, Movement.Right };
		private Movement _getmove;
		private Movement _getmove2;

		public Meteor ()
		{
			_objectmove1 = new ProjectileObjectMovement ();
			_objectmove2 = new ProjectileObjectMovement ();
		}

		public string getMeteorType {
			get { return meteor1; }
			set { meteor1 = value; }	
		}

		public ProjectileObjectMovement getMove1 {
			get { return _objectmove1; }
			set { _objectmove1 = value; }
		}

		public ProjectileObjectMovement getMove2 {
			get { return _objectmove2; }
			set { _objectmove2 = value; }
		}

		public void checkMeteorType ()
		{
			if (meteor1 == "meteorSmall.png") {
				getMove1.getSpeed = 150;
			} else if (meteor1 == "meteorMedium.png") {
				getMove1.getSpeed = 50;
			} else if (meteor1 == "meteorBig.png"){
				getMove1.getSpeed = 10;
			}

			if (meteor2 == "meteorSmall.png") {
				getMove2.getSpeed = 150;
			} else if (meteor2 == "meteorMedium.png") {
				getMove2.getSpeed = 50;
			} else if (meteor2 == "meteorBig.png"){
				getMove2.getSpeed = 10;
			}
		}

		public void randomposition ()
		{
			if (random_generator.Next (0, 2) == 0) { // let 0 = x axis
				if (random_generator.Next (0, 2) == 0) { //let 0 be y = -10
					getMove1.GetY = -100;
				} else { //let 1 be y = 700
					getMove1.GetY = 800;
				}
				getMove1.GetX = PostitionX [random_generator.Next (0, 3)];

				_getmove = testmove [random_generator.Next (0, 2)]; // let 0 = top, 1 = bottom

			} else { // let 1 = y axis
				if (random_generator.Next (0, 2) == 0) { //let 0 be x = -10
					getMove1.GetX = -100;
				} else { //let 1 be x = 700
					getMove1.GetX = 800+100;
				}
				getMove1.GetY = PostitionY [random_generator.Next (0, 3)];

				_getmove = testmove [random_generator.Next (2, 4)]; // let 2 = left, 3 = right

				meteor1 = MeteorType [random_generator.Next (0, 3)]; // generate random meteor type
				//Console.WriteLine ("meteor1 = " + meteor1);
			}
		}

		public void randomposition2 ()
		{
			if (random_generator.Next (0, 2) == 0) { // let 0 = x axis

				if (random_generator.Next (0, 2) == 0) { //let 0 be y = -10
					getMove2.GetY = -100;
				} else { //let 1 be y = 700
					getMove2.GetY = 800;
				}
				getMove2.GetX = PostitionX [random_generator.Next (0, 3)];

				_getmove2 = testmove [random_generator.Next (0, 2)]; // let 0 = top, 1 = bottom

			} else { // let 1 = y axis
				if (random_generator.Next (0, 2) == 0) { //let 0 be x = -10
					getMove2.GetX = -100;
				} else { //let 1 be x = 700
					getMove2.GetX = 800+100;
				}
				getMove2.GetY = PostitionY [random_generator.Next (0, 3)];

				_getmove2 = testmove [random_generator.Next (2, 4)]; // let 2 = left, 3 = right

				meteor2 = MeteorType [random_generator.Next (0, 3)]; // generate random meteor type
				//Console.WriteLine ("meteor2 = " + meteor2);
			}
		}


		public void draw ()
		{
			SwinGame.DrawBitmap (meteor1, getMove1.GetX, getMove1.GetY);
			SwinGame.DrawBitmap (meteor2, getMove2.GetX, getMove2.GetY);
		}

		public void drop ()
		{
			getMove1.Moving (_getmove);
			getMove2.Moving (_getmove2);

			if (_getmove == Movement.Left && getMove1.GetX < -10) {
				randomposition ();
			} else if (_getmove == Movement.Right && getMove1.GetX > 700+300) {
				randomposition ();
			} else if (_getmove == Movement.Top && getMove1.GetY < -10) {
				randomposition ();
			} else if (_getmove == Movement.Bottom && getMove1.GetY > 700) {
				randomposition ();
			}

			if (_getmove2 == Movement.Left && getMove2.GetX < -10) {
				randomposition2 ();
			} else if (_getmove2 == Movement.Right && getMove2.GetX > 700+300) {
				randomposition2 ();
			} else if (_getmove2 == Movement.Top && getMove2.GetY < -10) {
				randomposition2 ();
			} else if (_getmove2 == Movement.Bottom && getMove2.GetY > 700) {
				randomposition2 ();
			}
		}

	}
}

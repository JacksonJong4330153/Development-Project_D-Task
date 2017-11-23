using System;
using NUnit.Framework;

namespace MyGame
{
	[TestFixture()]
	public class _330153_UnitTest
	{
		[Test ()]
		public void PlayerMovement ()
		{
			Player p = new Player ();

			p.go (Movement.Left);
			Assert.AreEqual (p.getMove.GetX, 325);
			p.go (Movement.Top);
			Assert.AreEqual (p.getMove.GetX, 325);
		}

		[Test ()]
		public void TestCheckCollisionTrap ()
		{
			Player p = new Player ();
			Meteor t = new Meteor();
			Collision c = new Collision ();

			p.getMove.GetX = 425;
			p.getMove.GetY = 425;

			t.getMove1.GetX = 425;
			t.getMove1.GetY = 425;

			Assert.IsTrue (p.getMove.GetX == t.getMove1.GetX && p.getMove.GetY == t.getMove1.GetY);
			Assert.IsTrue (c.CheckCollideTrap1 (p, t));

		}

		[Test ()]
		public void TestCheckCollisionItem ()
		{
			Player p = new Player ();
			Item i = new Item ();
			Collision c = new Collision ();

			p.getMove.GetX = 425;
			p.getMove.GetY = 425;

			i.getXposition = 425;
			i.getYposition = 425;

			Assert.IsTrue (c.CheckCollideItem (p, i));
		}

		[Test ()]
		public void TestCheckCollisionMeteor ()
		{
			Player p = new Player ();
			Meteor t = new Meteor ();
			Collision c = new Collision ();

			p.getMove.GetX = 425;
			p.getMove.GetY = 425;

			t.getMove1.GetX = 425;
			t.getMove1.GetY = 425;

			Assert.IsTrue (c.CheckCollideTrap1 (p, t));
		}
	}
}

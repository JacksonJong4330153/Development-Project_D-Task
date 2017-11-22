using System;
using NUnit.Framework;

namespace MyGame
{
	[TestFixture()]
	public class _330153_UnitTest
	{

		[Test()]
		public void MeteorRandomPosition()
		{
			Trap t = new Trap ();
			t.randomposition ();

			Assert.AreEqual (325, t.getTrap.GetX);
		}

		[Test ()]
		public void PlayerMovement ()
		{
			Player p = new Player ();

			p.go (Movement.Left);
			Assert.AreEqual (p.getMove.GetX, 325);
			p.go (Movement.Top);
			Assert.AreEqual (p.getMove.GetX, 325);
		}


	}
}

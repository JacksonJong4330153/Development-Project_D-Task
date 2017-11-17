using System;
using NUnit.Framework;
namespace MyGame
{
	[TestFixture ()]
	public class unittest_4318501
	{
		[Test ()]
		public void MeteorSpawnTest ()
		{
			String meteor1 = "";
			Trap t = new Trap ();

			t.randomposition ();

			meteor1 = t.getMeteorType;

			Assert.AreEqual ("meteorSmall.png", meteor1);
		}

		[Test ()]
		public void MeteorSpeedTest ()
		{
			int chkspeed = 0;
			Trap t = new Trap ();

			t.randomposition ();

			t.getMeteorType = "meteorSmall.png";

			t.checkMeteorType ();

			chkspeed = t.getTrap.getSpeed;

			Assert.AreEqual (150, chkspeed);
		}

		[Test ()]
		public void BossLaserAndPlayerCollisionTest ()
		{
			Boss boss = new Boss ();
			Player player = new Player ();
			Collision collision = new Collision ();

			bool result = false;

			boss._getfire = true;

			boss.getBoss.GetX = 325;

			player.getMove.GetX = 325;

			result = collision.LaserAndPlayer (player, boss);

			Assert.AreEqual (true, result);
		}
	}
}

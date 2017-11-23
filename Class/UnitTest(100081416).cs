using System;
using NUnit.Framework;
namespace MyGame
{
	[TestFixture()]
	public class UnitTest_100081416_
	{
		[Test()]
		public void TestBulletBehavior () {
			Bullet b = new Bullet ();
			b.getBullet.GetX = 425;
			b.getBullet.GetY = 425;
			b.facedirection (Movement.Top);
			Meteor m = new Meteor ();
			m.getMove1.GetX = 425;
			m.getMove1.GetY = 420;
			b.fire ();
			bool firetriggered = true;
			Collision co = new Collision ();
			Assert.IsTrue (co.BulletAndMeteor1 (b, m, firetriggered));
		}
		[Test ()]
		public void TestBulletAndBossCollision () {
			Boss boss = new Boss ();
			boss.getBoss.GetY = 0;
			Bullet b = new Bullet ();
			b.getBullet.GetX = 425;
			b.getBullet.GetY = 5;
			b.fire ();
			Collision co = new Collision ();
			Assert.IsTrue (co.BulletAndBoss(boss,b));
		}

	}
}

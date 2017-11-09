using System;
using NUnit.Framework;

namespace MyGame
{
	//[TestFixture()]
	//public class UnitTest
	//{
	//	[Test()]
	//	public void PlayerMovement ()
	//	{
	//		Player p = new Player ();

	//		p.go (Movement.Left);
	//		Assert.AreEqual (p.getMove.GetX, 225);
	//		p.go (Movement.Top);
	//		Assert.AreEqual (p.getMove.GetX, 225);
	//	}

	//	[Test ()]
	//	public void TestCheckCollisionTrap ()
	//	{
	//		Player p = new Player ();
	//		Trap t = new Trap ();
	//		Collision c = new Collision ();

	//		t.getTrap.GetX = 325;
	//		t.getTrap.GetY = 325;

	//		Assert.IsTrue (p.getMove.GetX == t.getTrap.GetX && p.getMove.GetY == t.getTrap.GetY);
	//		Assert.IsTrue (c.CheckCollideTrap1 (p, t));

	//	}

	//	[Test()]
	//	public void TestAfterCollisionTrap ()
	//	{
	//		Player p = new Player ();
	//		Trap t = new Trap ();
	//		Collision c = new Collision ();


	//		t.getTrap.GetX = 325;
	//		t.getTrap.GetY = 325;




	//		p.getHealth = c.AfterCollideTrap (p.getHealth);
	//		Assert.AreEqual (p.getHealth, 4);

	//	}

	//	[Test ()]
	//	public void TestCheckCollisionItem ()
	//	{
	//		Player p = new Player ();
	//		Item i = new Item ();
	//		Collision c = new Collision ();

	//		i.getXposition = 325;
	//		i.getYposition = 325;

	//		Assert.IsTrue (c.CheckCollideItem (p, i));
	//	}

	//	[Test ()]
	//	public void TestAfterCollisionItemCoin ()
	//	{
	//		Player p = new Player ();
	//		Item i = new Item ();
	//		Collision c = new Collision ();


	//		i.getXposition = 325;
	//		i.getYposition = 325;
	//		i.getItem = ItemType.coin;

	//		p.getScore = c.AfterCollideItemAffectScore (p.getHealth, p.getScore);
	//		Assert.AreEqual (p.getScore, 100);
	//	}

	//	[Test ()]
	//	public void TestAfterCollisionItemTools ()
	//	{
	//		Player p = new Player ();
	//		Item i = new Item ();
	//		Collision c = new Collision ();


	//		i.getXposition = 325;
	//		i.getYposition = 325;
	//		i.getItem = ItemType.health;

	//		p.getScore = c.AfterCollideItemAffectScore (p.getHealth, p.getScore);
	//		Assert.AreEqual (p.getScore, 100);
	//	}

	//	[Test ()]
	//	public void TestAfterCollisionItemTools2 ()
	//	{
	//		Player p = new Player ();
	//		Item i = new Item ();
	//		Collision c = new Collision ();


	//		i.getXposition = 325;
	//		i.getYposition = 325;
	//		i.getItem = ItemType.health;
	//		p.getHealth = 4;

	//		p.getHealth = c.AfterCollideItemAffectHp (p.getHealth, i.getItem);
	//		Assert.AreEqual (p.getHealth, 5);
	//	}

	//	[Test ()]
	//	public void TestAfterCollisionItemBomb ()
	//	{
	//		Player p = new Player ();
	//		Item i = new Item ();
	//		Collision c = new Collision ();


	//		i.getXposition = 325;
	//		i.getYposition = 325;
	//		i.getItem = ItemType.bomb;


	//		p.getHealth = c.AfterCollideItemAffectHp (p.getHealth, i.getItem);
	//		Assert.AreEqual (p.getHealth, 4);
	//	}

}

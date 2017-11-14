﻿using System;
namespace MyGame
{
	public class Collision
	{
		public bool co, co2;




		public Collision ()
		{

		}

		public Boolean CheckCollideTrap1 (Player p, Trap t)
		{
			if ((p.getMove.GetX > (t.getTrap.GetX - 10) && p.getMove.GetX < (t.getTrap.GetX + 10)) && (p.getMove.GetY > (t.getTrap.GetY - 10) && p.getMove.GetY < (t.getTrap.GetY + 10))) {
				return true;
			} else {
				return false;
			}

		}

		public Boolean CheckCollideTrap2 (Player p, Trap t)
		{
			if ((p.getMove.GetX > (t.getTrap2.GetX - 10) && p.getMove.GetX < (t.getTrap2.GetX + 10)) && (p.getMove.GetY > (t.getTrap2.GetY - 10) && p.getMove.GetY < (t.getTrap2.GetY + 10))) {
				return true;
			} else {
				return false;
			}

		}

		public int AfterCollideTrap (int hp)
		{
			hp = hp - 1;
			return hp;
		}

		public Boolean CheckCollideItem (Player p, Item i)
		{
			if ((p.getMove.GetX > (i.getXposition - 10) && p.getMove.GetX < (i.getXposition + 10)) && (p.getMove.GetY > (i.getYposition - 10) && p.getMove.GetY < (i.getYposition + 10))) {
				return true;
			} else {
				return false;
			}
		}

		public Boolean BulletAndBoss (Boss boss, Bullet b)
		{
			if ((boss.getBoss.GetX == b.getBullet.GetX && boss.getBoss.GetY == b.getBullet.GetY)) {
				return true;
			} else {
				return false;
			}
		}

		public Boolean LaserAndPlayer (Player p, Boss boss)
		{
			if (boss.getBoss.GetX == p.getMove.GetX && boss._getfire == true) {
				return true;
			} else {
				return false;
			}
		}


		public Boolean BulletAndMeteor1 (Bullet b, Trap t, bool p)
		{
			if ((b.getBullet.GetX > t.getTrap.GetX - 50) && (b.getBullet.GetX < t.getTrap.GetX + 50)
			    && (b.getBullet.GetY > t.getTrap.GetY - 50) && (b.getBullet.GetY < t.getTrap.GetY + 50)
			    && (p != false)) {
				return true;
			} else {
				return false;
			}
			//if ((b.getBullet.GetX == t.getTrap.GetX && b.getBullet.GetY == t.getTrap.GetY) && b.getBullet.GetX != p.getMove.GetX) {
			//	return true;
			//} else {
			//	return false;
			//}

		}

		public Boolean BulletAndMeteor2 (Bullet b, Trap t, bool p)
		{
			if ((b.getBullet.GetX > t.getTrap2.GetX - 50) && (b.getBullet.GetX < t.getTrap2.GetX + 50)
				&& (b.getBullet.GetY > t.getTrap2.GetY - 50) && (b.getBullet.GetY < t.getTrap2.GetY + 50)
			    && (p != false)) {
				return true;
			} else {
				return false;
			}
			//if ((b.getBullet.GetX == t.getTrap.GetX && b.getBullet.GetY == t.getTrap.GetY) && b.getBullet.GetX != p.getMove.GetX) {
			//	return true;
			//} else {
			//	return false;
			//}
		}

		//public int AfterCollideItemAffectHp (int hp, ItemType type)
		//{
		//	if (hp < 5 && type == ItemType.health) {
		//		hp = hp + 1;
		//		return hp;
		//	} else if (type == ItemType.bomb) {
		//		hp = hp - 1;
		//		return hp;
		//	} else {
		//		return hp;
		//	}

		//}

		//public int AfterCollideItemAffectScore (int hp,int score)
		//{
		//	if (hp> 4) {
		//		score = score + 100;
		//		return score;
		//	} else{
		//		score = score + 100;
		//		return score;
		//	}

		//}


	}
}

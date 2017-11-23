using System;
namespace MyGame
{
	public class Collision
	{
		public Collision ()
		{

		}

		public Boolean CheckCollideTrap1 (Player p, Meteor t)
		{
			if ((p.getMove.GetX > (t.getMove1.GetX - 10) && p.getMove.GetX < (t.getMove1.GetX + 10)) 
			    && (p.getMove.GetY > (t.getMove1.GetY - 10) && p.getMove.GetY < (t.getMove1.GetY + 10))) {
				return true;
			} else {
				return false;
			}

		}

		public Boolean CheckCollideTrap2 (Player p, Meteor t)
		{
			if ((p.getMove.GetX > (t.getMove2.GetX - 10) && p.getMove.GetX < (t.getMove2.GetX + 10)) 
			    && (p.getMove.GetY > (t.getMove2.GetY - 10) && p.getMove.GetY < (t.getMove2.GetY + 10))) {
				return true;
			} else {
				return false;
			}

		}

		public Boolean CheckCollideItem (Player p, Item i)
		{
			if ((p.getMove.GetX > (i.getXposition - 10) && p.getMove.GetX < (i.getXposition + 10)) 
			    && (p.getMove.GetY > (i.getYposition - 10) && p.getMove.GetY < (i.getYposition + 10))) {
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


		public Boolean BulletAndMeteor1 (Bullet b, Meteor t, bool p)
		{
			if ((b.getBullet.GetX > t.getMove1.GetX - 50) && (b.getBullet.GetX < t.getMove1.GetX + 50)
			    && (b.getBullet.GetY > t.getMove1.GetY - 50) && (b.getBullet.GetY < t.getMove1.GetY + 50)
			    && (p != false)) {
				return true;
			} else {
				return false;
			}
		}

		public Boolean BulletAndMeteor2 (Bullet b, Meteor t, bool p)
		{
			if ((b.getBullet.GetX > t.getMove2.GetX - 50) && (b.getBullet.GetX < t.getMove2.GetX + 50)
				&& (b.getBullet.GetY > t.getMove2.GetY - 50) && (b.getBullet.GetY < t.getMove2.GetY + 50)
			    && (p != false)) {
				return true;
			} else {
				return false;
			}
		}

	}
}

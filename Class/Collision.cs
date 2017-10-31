using System;
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

		public int AfterCollideItemAffectHp (int hp, ItemType type)
		{
			if (hp < 5 && type == ItemType.health) {
				hp = hp + 1;
				return hp;
			} else if (type == ItemType.bomb) {
				hp = hp - 1;
				return hp;
			} else {
				return hp;
			}

		}

		public int AfterCollideItemAffectScore (int hp,int score)
		{
			if (hp> 4) {
				score = score + 100;
				return score;
			} else{
				score = score + 100;
				return score;
			}

		}


	}
}

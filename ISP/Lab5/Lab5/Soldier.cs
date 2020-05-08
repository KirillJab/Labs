using System;
using System.Threading;

namespace Lab3
{
	public abstract class Soldier : Human
	{
		public enum Qualities
		{
			Legendary,       // k = 1,8 
			BattleHardened,  // k = 1,5
			Skillful,        // k = 1,2
			Heavy,           // hp += 10, armor += 10
			Lame,            // speed -= 5
			Subblind,        // damage -=7, speed -=3
			Rookie           // 
		};
		public enum Kingdoms
		{
			Nords,
			Empire,
			Khuzaits,
			Vlandia
		};
		public static int number = 0;
		public int tier { get; set; }
		public int curhp { get; set; }
		public int damage { get; set; }
		public int armour { get; set; }
		public int speed { get; set; }
		public bool isAlive { get; set; }
		public int seqnumber { get; set; }
		public Qualities quality { get; set; }
		public Kingdoms banner { get; set; }

		// CONSTRUCTORS
		public Soldier() : base()
		{
			number++;
			seqnumber = number;
			Random rand = new Random((int)DateTime.Now.Ticks);
			name = Names[(number + rand.Next(0, 10)) % 11];
			damage = rand.Next(30, 115);
			armour = rand.Next(10, 55);
			speed = rand.Next(10, 55);
			tier = (damage + armour) / 40;
			quality = Qualities.Legendary;
			banner = Kingdoms.Empire;
			curhp = hp;
			isAlive = true;
			Thread.Sleep(1);
		}

		public Soldier(string _name, int _age, Genders _gender, int _damage, int _armour, int _speed, Qualities _quality, Kingdoms _banner) : base(_name, _age, _gender)
		{
			number++;
			seqnumber = number;
			damage = _damage;
			armour = _armour;
			speed = _speed;
			tier = (damage + armour) / 40;
			quality = _quality;
			banner = _banner;
			isAlive = true;
		}

		// METHODS
		public override void showInfo()
		{
			if (isAlive)
			{
				Console.WriteLine(seqnumber + ")" + name + ": I am " + age + " year old " + tier + " tier " + quality + " soldier of the " + banner + ". I can deal " + damage + " damage and have " + armour + " armour");
			}
		}
		public virtual void showHp()
		{
			if (isAlive)
			{
				Console.WriteLine(name + " " + tier + " tier " + quality + " soldier of the " + banner + " is  " + curhp + "/" + hp);
			}
		}

		public abstract int attack();
		public abstract void gethit(int hit);

		public virtual void heal()
		{
			if (isAlive)
			{
				curhp = curhp + 5 > hp ? hp : curhp + 5;
			}
		}
	}
}

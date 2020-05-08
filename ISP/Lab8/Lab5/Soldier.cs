using System;
using System.Threading;
using System.Collections.Generic;

namespace Lab3
{
	public abstract class Soldier : Human, IComparable
	{
		public delegate void WinEventHandler(Soldier winner);
		public delegate void DiedEventHandler(Soldier dead);
		public static event WinEventHandler Win;
		public event DiedEventHandler Died;
		public static void OnWin(Soldier winner)
		{
			Win?.Invoke(winner);
		}
		public void OnDied(Soldier dead)
		{
			Died?.Invoke(dead);
		}


		public enum Qualities
		{
			Legendary,
			BattleHardened,
			Skillful,
			Heavy,
			Lame,
			Subblind,
			Rookie
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


		public int CompareTo(object obj)
		{
			Soldier p = obj as Soldier;
			if (p != null)
			{
				if (this.damage < p.damage)
					return -1;
				if (this.damage > p.damage)
					return 1;
				return 0;
			}
			else
			{
				throw new Exception("Parametr should be of type Soldier");
			}
		}
	}
	public class IdComparer : IComparer<Soldier>
	{
		public int Compare(Soldier x, Soldier y)
		{
			return x.id.CompareTo(y.id);
		}
	}
}

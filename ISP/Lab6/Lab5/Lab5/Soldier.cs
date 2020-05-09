using System;
using System.Threading;
using System.Collections.Generic;

namespace Lab3
{
	public abstract class Soldier : Human, IComparable
	{
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
		public static int Number = 0;
		public int Tier { get; set; }
		public int Curhp { get; set; }
		public int Damage { get; set; }
		public int Armor { get; set; }
		public int Speed { get; set; }
		public bool IsAlive { get; set; }
		public int Seqnumber { get; set; }
		public Qualities Quality { get; set; }
		public Kingdoms Banner { get; set; }

		// CONSTRUCTORS
		public Soldier() : base()
		{
			Number++;
			Seqnumber = Number;
			Random rand = new Random((int)DateTime.Now.Ticks);
			Name = Names[(Number + rand.Next(0, 10)) % 11];
			Damage = rand.Next(30, 115);
			Armor = rand.Next(10, 55);
			Speed = rand.Next(10, 55);
			Tier = (Damage + Armor) / 40;
			Quality = Qualities.Legendary;
			Banner = Kingdoms.Empire;
			Curhp = Hp;
			IsAlive = true;
			Thread.Sleep(1);
		}

		public Soldier(string _name, int _age, Genders _gender, int _damage, int _armour, int _speed, Qualities _quality, Kingdoms _banner) : base(_name, _age, _gender)
		{
			Number++;
			Seqnumber = Number;
			Damage = _damage;
			Armor = _armour;
			Speed = _speed;
			Tier = (Damage + Armor) / 40;
			Quality = _quality;
			Banner = _banner;
			IsAlive = true;
		}

		// METHODS
		public override void showInfo()
		{
			if (IsAlive)
			{
				Console.WriteLine(Seqnumber + ")" + Name + ": I am " + Age + " year old " + Tier + " tier " + Quality + " soldier of the " + Banner + ". I can deal " + Damage + " damage and have " + Armor + " armour");
			}
		}
		public virtual void showHp()
		{
			if (IsAlive)
			{
				Console.WriteLine(Name + " " + Tier + " tier " + Quality + " soldier of the " + Banner + " is  " + Curhp + "/" + Hp);
			}
		}

		public abstract int attack();
		public abstract void gethit(int hit);


		public int CompareTo(object obj)
		{
			Soldier p = obj as Soldier;
			if (p != null)
			{
				if (this.Damage < p.Damage)
					return -1;
				if (this.Damage > p.Damage)
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

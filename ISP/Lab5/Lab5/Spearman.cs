using System;

namespace Lab3
{
	public class Spearman : Soldier
	{
		int spearLength { get; set; }


		// CONSTRUCTORS
		public Spearman() : base()
		{
			Random rand = new Random((int)DateTime.Now.Ticks);
			Speed = rand.Next(10, 35);
			Damage = rand.Next(30, 45);
			Armor = rand.Next(10, 25);
			Tier = (Damage + Armor) / 40;
			Quality = (Qualities)rand.Next(0, 7);
			Banner = (Kingdoms)rand.Next(0, 4);

			spearLength = 180;
		}
		public Spearman(string name, int age, Genders gender, int damage, int armour, int speed, int spearLength, Qualities quality, Kingdoms banner) : base(name, age, gender, damage, armour, speed, quality, banner)
		{
			this.spearLength = spearLength;
		}

		//METHODS
		public override int Attack()
		{
			if (IsAlive)
			{
				Random rand = new Random();
				int hit = Damage + Speed / 5 + spearLength / 20;
				if (rand.Next(0, 4) == 3)
				{
					hit += Damage / 2;
				}
				Console.Write("\n" + Quality + " Spearman dealed " + hit + " damage to");
				return hit;
			}
			return 0;
		}

		public override void GetHit(int hit)
		{
			hit -= Armor;
			Console.WriteLine(" " + Quality + " Spearman. Armour blocked " + Armor + " damage");
			if (hit > 0)
			{
				Curhp -= hit;
			}
			if (Curhp < 1)
			{
				IsAlive = false;
			}
			Heal();
		}

		public override void Heal()
		{
			if (IsAlive)
			{
				int healed = Curhp + 5 > Hp ? Hp - Curhp : 5;
				Curhp += healed;
				Console.WriteLine("Healed " + healed);
			}
			ShowHp();
		}

		public override void ShowInfo()
		{
			Console.WriteLine(Seqnumber + ")" + Name + ": I am " + Age + " year old " + Tier + " tier " + Quality + " Spearman of the " + Banner + ". I can deal minimum of " + Damage + " damage and have " + Armor + " armour");
		}

		public override void ShowHp()
		{
			if (IsAlive)
			{
				Console.WriteLine(Name + " the " + Quality + " Spearman of the " + Banner + " is " + Curhp + "/" + Hp);
			}
			else
			{
				Console.WriteLine(Name + " the " + Quality + " Spearman of the " + Banner + " is DEAD\n\n");
			}
		}
	}
}

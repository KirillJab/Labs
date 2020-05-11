using System;

namespace Lab3
{
	public class Legionary : Soldier, IHeal
	{
		int shieldArmour { get; set; }


		// CONSTRUCTORS
		public Legionary() : base()
		{
			Random rand = new Random((int)DateTime.Now.Ticks);
			Speed = rand.Next(5, 25);
			Damage = rand.Next(30, 45);
			Armor = rand.Next(20, 35);
			Tier = (Damage + Armor) / 20;
			Quality = (Qualities)rand.Next(0, 7);
			Banner = (Kingdoms)rand.Next(0, 4);

			shieldArmour = 20;
		}
		public Legionary(string name, int age, Genders gender, int damage, int armour, int speed, int shieldArmour, Qualities quality, Kingdoms banner) : base(name, age, gender, damage, armour, speed, quality, banner)
		{
			this.shieldArmour = shieldArmour;
		}

		//METHODS
		public override int Attack()
		{
			if (IsAlive)
			{
				Random rand = new Random();
				int hit = Damage + Speed / 5;
				if (rand.Next(0, 10) == 1)
				{
					hit += Damage / 2;
				}
				Console.Write("\n" + Quality + " Legionary dealed " + hit + " damage to");
				return hit;
			}
			return 0;
		}
		public override void GetHit(int hit)
		{
			hit -= Armor + shieldArmour;
			Console.WriteLine(" " + Quality + " Legioanry. Armour and shield blocked " + (Armor + shieldArmour) + " damage");
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

		public void Heal()
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
			Console.WriteLine(Seqnumber + ")" + Name + ": I am " + Age + " year old " + Tier + " tier " + Quality + " Legionary of the " + Banner + ". I can deal minimum of " + Damage + " damage and have " + Armor + " armour");
		}

		public override void ShowHp()
		{
			if (IsAlive)
			{
				Console.WriteLine(Name + " the " + Tier + " tier " + Quality + " Legionary of the " + Banner + " is " + Curhp + "/" + Hp);
			}
			else
			{
				Console.WriteLine(Name + " the " + Tier + " tier " + Quality + " Legionary of the " + Banner + " is DEAD\n\n");
				OnDied(this);
			}
		}
	}
}

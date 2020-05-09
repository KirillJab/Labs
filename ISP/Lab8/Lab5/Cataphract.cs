using System;

namespace Lab3
{
	public class Cataphract : Soldier, IHeal
	{
		int horseSpeed { get; set; }


		// CONSTRUCTORS
		public Cataphract() : base()
		{
			Random rand = new Random((int)DateTime.Now.Ticks);
			Speed = rand.Next(15, 55);
			Damage = rand.Next(30, 65);
			Armor = rand.Next(27, 30);
			Tier = (Damage + Armor) / 30;
			Quality = (Qualities)rand.Next(0, 7);
			Banner = (Kingdoms)rand.Next(0, 4);

			horseSpeed = 100;
		}
		public Cataphract(string name, int age, Genders gender, int damage, int armour, int speed, int horseSpeed, Qualities quality, Kingdoms banner) : base(name, age, gender, damage, armour, speed, quality, banner)
		{
			this.horseSpeed = horseSpeed;
		}

		//METHODS
		public override int attack()
		{
			if (IsAlive)
			{
				Random rand = new Random();
				int hit = Damage + Speed / 5 + horseSpeed / 5;
				if (rand.Next(0, 10) == 1)
				{
					hit += Damage / 2;
				}
				Console.Write("\n" + Quality + " Cataphract dealed " + hit + " damage to");
				return hit;
			}
			return 0;
		}
		public override void gethit(int hit)
		{
			hit -= Armor;
			Console.WriteLine(" " + Quality + " Cataphract. Armour blocked " + Armor + " damage");
			if (hit > 0)
			{
				Curhp -= hit;
			}
			if (Curhp < 1)
			{
				IsAlive = false;
			}
			heal();
			showHp();
		}

		public void heal() //Won't heal, cause too OP
		{

		}

		public override void showInfo()
		{
			Console.WriteLine(Seqnumber + ")" + Name + ": I am " + Age + " year old " + Tier + " tier " + Quality + " Cataphract of the " + Banner + ". I can deal minimum of " + Damage + " damage and have " + Armor + " armour");
		}

		public override void showHp()
		{
			if (IsAlive)
			{
				Console.WriteLine(Name + " the " + Quality + " Cataphract of the " + Banner + " is " + Curhp + "/" + Hp);
			}
			else
			{
				Console.WriteLine(Name + " the " + Quality + " Cataphract of the " + Banner + " is DEAD\n\n");
				OnDied(this);
			}
		}
	}
}

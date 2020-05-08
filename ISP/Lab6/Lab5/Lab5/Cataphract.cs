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
			speed = rand.Next(15, 55);
			damage = rand.Next(30, 65);
			armour = rand.Next(27, 30);
			tier = (damage + armour) / 30;
			quality = (Qualities)rand.Next(0, 7);
			banner = (Kingdoms)rand.Next(0, 4);

			horseSpeed = 100;
		}
		public Cataphract(string _name, int _age, Genders _gender, int _damage, int _armour, int _speed, int _horseSpeed, Qualities _quality, Kingdoms _banner) : base(_name, _age, _gender, _damage, _armour, _speed, _quality, _banner)
		{
			horseSpeed = _horseSpeed;
		}

		//METHODS
		public override int attack()
		{
			if (isAlive)
			{
				Random rand = new Random();
				int hit = damage + speed / 5 + horseSpeed / 5;
				if (rand.Next(0, 10) == 1)
				{
					hit += damage / 2;
				}
				Console.Write("\n" + quality + " Cataphract dealed " + hit + " damage to");
				return hit;
			}
			return 0;
		}
		public override void gethit(int hit)
		{
			hit -= armour;
			Console.WriteLine(" " + quality + " Cataphract. Armour blocked " + armour + " damage");
			if (hit > 0)
			{
				curhp -= hit;
			}
			if (curhp < 1)
			{
				isAlive = false;
			}
			heal();
			showHp();
		}

		public void heal() //Won't heal, cause too OP
		{

		}

		public override void showInfo()
		{
			Console.WriteLine(seqnumber + ")" + name + ": I am " + age + " year old " + tier + " tier " + quality + " Cataphract of the " + banner + ". I can deal minimum of " + damage + " damage and have " + armour + " armour");
		}

		public override void showHp()
		{
			if (isAlive)
			{
				Console.WriteLine(name + " the " + quality + " Cataphract of the " + banner + " is " + curhp + "/" + hp);
			}
			else
			{
				Console.WriteLine(name + " the " + quality + " Cataphract of the " + banner + " is DEAD\n\n");
			}
		}
	}
}

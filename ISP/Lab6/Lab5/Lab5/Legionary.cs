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
			speed = rand.Next(5, 25);
			damage = rand.Next(30, 45);
			armour = rand.Next(20, 35);
			tier = (damage + armour) / 20;
			quality = (Qualities)rand.Next(0, 7);
			banner = (Kingdoms)rand.Next(0, 4);

			shieldArmour = 20;
		}
		public Legionary(string _name, int _age, Genders _gender, int _damage, int _armour, int _speed, int _shieldArmour, Qualities _quality, Kingdoms _banner) : base(_name, _age, _gender, _damage, _armour, _speed, _quality, _banner)
		{
			shieldArmour = _shieldArmour;
		}

		//METHODS
		public override int attack()
		{
			if (isAlive)
			{
				Random rand = new Random();
				int hit = damage + speed / 5;
				if (rand.Next(0, 10) == 1)
				{
					hit += damage / 2;
				}
				Console.Write("\n" + quality + " Legionary dealed " + hit + " damage to");
				return hit;
			}
			return 0;
		}
		public override void gethit(int hit)
		{
			hit -= armour + shieldArmour;
			Console.WriteLine(" " + quality + " Legioanry. Armour and shield blocked " + (armour + shieldArmour) + " damage");
			if (hit > 0)
			{
				curhp -= hit;
			}
			if (curhp < 1)
			{
				isAlive = false;
			}
			heal();
		}

		public void heal()
		{
			if (isAlive)
			{
				int healed = curhp + 5 > hp ? hp - curhp : 5;
				curhp += healed;
				Console.WriteLine("Healed " + healed);
			}
			showHp();
		}

		public override void showInfo()
		{
			Console.WriteLine(seqnumber + ")" + name + ": I am " + age + " year old " + tier + " tier " + quality + " Legionary of the " + banner + ". I can deal minimum of " + damage + " damage and have " + armour + " armour");
		}

		public override void showHp()
		{
			if (isAlive)
			{
				Console.WriteLine(name + " the " + tier + " tier " + quality + " Legionary of the " + banner + " is " + curhp + "/" + hp);
			}
			else
			{
				Console.WriteLine(name + " the " + tier + " tier " + quality + " Legionary of the " + banner + " is DEAD\n\n");
			}
		}
	}
}

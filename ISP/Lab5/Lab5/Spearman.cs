using System;

public class Spearman : Soldier
{
	int spearlength { get; set; }


	// CONSTRUCTORS
	public Spearman() : base()
	{
		Random rand = new Random((int)DateTime.Now.Ticks);
		speed = rand.Next(10, 35);
		damage = rand.Next(30, 45);
		armour = rand.Next(10, 25);
		tier = (damage + armour) / 40;
		quality = (Qualities)rand.Next(0, 7);
		banner = (Kingdoms)rand.Next(0, 4);

		spearlength = 180;
	}
	public Spearman(string _name, int _age, Genders _gender, int _damage, int _armour, int _speed, int _spearlength, Qualities _quality, Kingdoms _banner) : base(_name, _age, _gender, _damage, _armour, _speed, _quality, _banner)
	{
		spearlength = _spearlength;
	}

	//METHODS
	public override int attack()
	{
		if (isAlive)
		{
			Random rand = new Random();
			int hit = damage + speed / 5;
			if (rand.Next(0, 4) == 3)
			{
				hit += damage / 2;
			}
			Console.Write("\n" + quality + " Spearman dealed " + hit + " damage to");
			return hit;
		}
		return 0;
	}

	public override void gethit(int hit)
	{
		hit -= armour;
		Console.WriteLine(" " + quality + " Spearman. Armour blocked " + armour + " damage");
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

	public override void heal()
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
		Console.WriteLine(seqnumber + ")" + name + ": I am " + age + " year old " + tier + " tier " + quality + " Spearman of the " + banner + ". I can deal minimum of " + damage + " damage and have " + armour + " armour");
	}

	public override void showHp()
	{
		if (isAlive)
		{
			Console.WriteLine(name + " the " + quality + " Spearman of the " + banner + " is " + curhp + "/" + hp);
		}
		else
		{
			Console.WriteLine(name + " the " + quality + " Spearman of the " + banner + " is DEAD\n\n");
		}
	}
}

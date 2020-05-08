using System;

namespace Lab3
{
	public class Human
	{
		public enum Genders { Male, Female };

		public string[] Names = new string[] { "John", "Ivan", "Paul", "Arthur", "Edward", "Wladzislaw", "Gravet", "Jaroglek", "Ulrich", "Gotfrid", "Robert" };
		public string[] GirlNames = new string[] { "Johnana", "Ivana", "Paula", "Veronica", "Milena", "Wladzislawa", "Ksenia", "Jana", "Ulya", "Gerda", "Roberta" };
		public int hp { get; set; }
		public int age { get; set; }
		public string name { get; set; }
		static int count = 0;
		public int id { get; }
		Genders gender { get; set; }


		// CONSTRUCTORS
		public Human()
		{
			Random rand = new Random((int)DateTime.Now.Ticks);
			hp = 100;
			age = rand.Next(16, 41);
			gender = (Genders)rand.Next(0, 2);
			name = gender == Genders.Male ? Names[rand.Next(0, 11)] : GirlNames[rand.Next(0, 11)];
			count++;
			id = count;
		}
		public Human(string _name, int _age, Genders _gender)
		{
			hp = 100;
			name = _name;
			age = _age;
			gender = _gender;
			count++;
			id = count;
		}

		// METHODS
		public void sayHello()
		{
			Console.WriteLine(name + " (" + age + "): Hello everyone!");
		}
		public void sayHello(string toName)
		{
			Console.WriteLine(name + " (" + age + "): Hello, " + toName + " !");
		}

		public virtual void showInfo()
		{
			Console.WriteLine(" " + id + ") " + name + " is " + age + " years old, has " + hp + "hp and is " + gender.ToString());
		}

		public Human setInfo()
		{
			Human person = new Human();
			Console.WriteLine("Name: ");
			person.name = Console.ReadLine();
			Console.WriteLine("Age: ");
			while (true)
			{
				try
				{
					person.age = int.Parse(Console.ReadLine());
					break;
				}
				catch
				{
					Console.WriteLine("Wrong input, please, try one more time");
				}
			}
			Console.WriteLine("Press 1 if peson is male");
			person.gender = Console.ReadLine() == "1" ? Genders.Male : Genders.Female;
			return person;
		}
	}
}

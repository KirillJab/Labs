using System;

namespace Lab3
{
	public class Human
	{
		public enum Genders { Male, Female };

		public string[] Names = new string[] { "John", "Ivan", "Paul", "Arthur", "Edward", "Wladzislaw", "Gravet", "Jaroglek", "Ulrich", "Gotfrid", "Robert" };
		public string[] GirlNames = new string[] { "Johnana", "Ivana", "Paula", "Veronica", "Milena", "Wladzislawa", "Ksenia", "Jana", "Ulya", "Gerda", "Roberta" };
		public int Hp { get; set; }
		public int Age { get; set; }
		public string Name { get; set; }
		static int count = 0;
		int id;
		Genders gender { get; set; }


		// CONSTRUCTORS
		public Human()
		{
			Random rand = new Random((int)DateTime.Now.Ticks);
			Hp = 100;
			Age = rand.Next(16, 41);
			gender = (Genders)rand.Next(0, 2);
			Name = gender == Genders.Male ? Names[rand.Next(0, 11)] : GirlNames[rand.Next(0, 11)];
			count++;
			id = count;
		}
		public Human(string name, int Age, Genders gender1)
		{
			Hp = 100;
			Name = name;
			Age = Age;
			gender = gender1;
			count++;
			id = count;
		}

		// METHODS
		public void SayHello()
		{
			Console.WriteLine(Name + " (" + Age + "): Hello everyone!");
		}
		public void SayHello(string toName)
		{
			Console.WriteLine(Name + " (" + Age + "): Hello, " + toName + " !");
		}

		public void ShowInfo()
		{
			Console.WriteLine(" " + id + ") " + Name + " is " + Age + " years old, has " + Hp + "Hp and is " + gender.ToString());
		}

		public Human SetInfo()
		{
			Human person = new Human();
			Console.WriteLine("Name: ");
			person.Name = Console.ReadLine();
			Console.WriteLine("Age: ");
			while (true)
			{
				try
				{
					person.Age = int.Parse(Console.ReadLine());
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
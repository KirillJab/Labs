using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Lab3
{
    class Program
    {


        static void Main(string[] args)
        {
            Random rand = new Random();
            List<Soldier> tournament = new List<Soldier>();
            Soldier warrior;
            int cont1 = -1, cont2 = -1;
            for (int i = 0; i < 3; i++)
            {
                if (rand.Next(0, 10) == 0)
                {
                    warrior = new Spearman("Garold", 22, Human.Genders.Male, 100, 100, 100, 100, Soldier.Qualities.Heavy, Soldier.Kingdoms.Empire);
                    warrior.isAlive = false;
                }
                else
                {
                    warrior = new Spearman();
                }
                if (warrior.isAlive)
                {
                    tournament.Add(warrior);
                }
                else
                {
                    throw new InvalidOperationException("You can't add a dead warrior to the tournament list..");
                }
                warrior = new Legionary();
                tournament.Add(warrior);
                warrior = new Cataphract();
                tournament.Add(warrior);
            }

            Console.WriteLine("Here is the warriors participating in the tournament:");

            foreach (Soldier soldier in tournament)
            {
                soldier.sayHello();
            }
            Console.WriteLine("\n" + new string('-', 30));
            Console.WriteLine("\nSoldiers sorted by damage: ");
            tournament.Sort();
            foreach (Soldier soldier in tournament)
            {
                soldier.showInfo();
            }
            Console.WriteLine("\n" + new string('-', 30));
            Console.WriteLine("\nSoldiers sorted by id: ");
            tournament.Sort(new IdComparer());
            foreach (Soldier soldier in tournament)
            {
                soldier.showInfo();
            }


            while (tournament.Count > 1)
            {
                Console.WriteLine("\nWho do you want to see fighting for glory? Enter the number of the first contestant! (not id)");
                while (true)
                {
                    try
                    {
                        cont1 = int.Parse(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine("Wrong input!");
                    }
                    if (cont1 < 1 || cont1 > tournament.Count)
                    {
                        Console.WriteLine("Try again");
                    }
                    else
                    {
                        break;
                    }
                }
                Console.WriteLine("Enter the number of the second contestant! (not id)");
                while (true)
                {
                    try
                    {
                        cont2 = int.Parse(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine("Wrong input!");
                    }
                    if (cont2 < 1 || cont2 > tournament.Count || cont2 == cont1)
                    {
                        Console.WriteLine("Try again");
                    }
                    else
                    {
                        break;
                    }
                }
                Console.WriteLine("Let's see them fight!");
                cont1--;
                cont2--;
                int count = 0;

                while (tournament[cont1].isAlive && tournament[cont2].isAlive)
                {
                    count++;
                    tournament[cont2].gethit(tournament[cont1].attack());
                    if (count == 10)
                    {
                        if (tournament[cont2].curhp < tournament[cont1].curhp)
                        {
                            tournament[cont2].isAlive = false;
                            Console.WriteLine("\nThe warriors got tired and the second contestant gave up");
                        }
                        else
                        {
                            tournament[cont1].isAlive = false;
                            Console.WriteLine("\nThe warriors got tired and the first contestant gave up");
                        }
                    }
                    Console.WriteLine();
                    if (tournament[cont2].isAlive)
                    {
                        tournament[cont1].gethit(tournament[cont2].attack());
                    }
                    Thread.Sleep(500);
                }
                if (!tournament[cont1].isAlive)
                {
                    tournament[cont1].Died += delegate (Soldier dead)
                    {
                        Console.WriteLine(dead.name + " (" + dead.age + "): AAARGH!...\n");
                    };
                    tournament[cont1].OnDied(tournament[cont1]);
                    tournament.RemoveAt(cont1);
                }
                else
                if (!tournament[cont2].isAlive)
                {
                    tournament[cont2].Died += delegate (Soldier dead)
                    {
                        Console.WriteLine(dead.name + " (" + dead.age + "): AAARGH!...\n");
                    };
                    tournament[cont2].OnDied(tournament[cont2]);
                    tournament.RemoveAt(cont2);
                }
                if (tournament.Count < 2)
                {
                    Console.WriteLine("HEY!\n Seems like you running out fighters, aren't you?\nWanna add some more fresh meat?\n\n" +
                        "1) Yes\n" +
                        "Any other key) No, let's and this bloodshee.., I mean tournament");
                    if (Console.ReadKey(true).KeyChar == '1')
                    {
                        bool quit = false;
                        while (!quit)
                        {
                            Console.WriteLine("1)  Spearman\n" +
                                              "2)  Legionary\n" +
                                              "3)  Cataphract\n");
                            switch (Console.ReadKey(true).KeyChar)
                            {
                                case '1':
                                    {
                                        warrior = new Spearman();
                                        warrior.showInfo();
                                        warrior.sayHello();
                                        tournament.Add(warrior);
                                        quit = true;
                                        break;
                                    }
                                case '2':
                                    {
                                        warrior = new Legionary();
                                        warrior.showInfo();
                                        warrior.sayHello();
                                        tournament.Add(warrior);
                                        quit = true;
                                        break;
                                    }
                                case '3':
                                    {
                                        warrior = new Cataphract();
                                        warrior.showInfo();
                                        warrior.sayHello();
                                        tournament.Add(warrior);
                                        quit = true;
                                        break;
                                    }
                                default:
                                    {
                                        break;
                                    }
                            }
                        }
                    }
                }

                Console.WriteLine("\n" + new string('-', 30) + "\n");
                foreach (Soldier soldier in tournament)
                {
                    soldier.showInfo();
                }
            }
            //EVENT WITH LAMBDA-EXPRESSION CALLING
            Soldier.Win += (dead) => Console.WriteLine("\n" + new string('-', 30) + "\n\n" + dead.name + " (" + dead.age + "): HOOORAAAAY!!! I am the WINNER in todays tournament!!!!"+ "\n\n" + new string('-', 30));
            Soldier.OnWin(tournament[0]);
            Console.ReadKey();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Soldier> tournament = new List<Soldier>();
            Soldier warrior1 = new Spearman();
            int cont1 = -1, cont2 = -1;
            tournament.Add(warrior1);
            warrior1 = new Spearman();
            tournament.Add(warrior1);
            warrior1 = new Legionary();
            tournament.Add(warrior1);
            warrior1 = new Legionary();
            tournament.Add(warrior1);
            warrior1 = new Cataphract();
            tournament.Add(warrior1);
            warrior1 = new Cataphract();
            tournament.Add(warrior1);


            foreach (Soldier warrior in tournament)
            {
                warrior.SayHello();
            }
            Console.WriteLine();
            Console.WriteLine(new string('-', 30));
            Console.WriteLine("\nSoldiers sorted by damage: ");
            tournament.Sort();
            foreach (Soldier warrior in tournament)
            {
                warrior.ShowInfo();
            }
            Console.WriteLine();
            Console.WriteLine(new string('-', 30));
            Console.WriteLine("\nSoldiers sorted by id: ");
            tournament.Sort(new IdComparer());
            foreach (Soldier warrior in tournament)
            {
                warrior.ShowInfo();
            }


            while (tournament.Count > 1)
            {
                Console.WriteLine("\nWho do you want to see fighting for glory? Enter the number of the first contestant! (not id)");
                while(true)
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

                while(tournament[cont1].IsAlive && tournament[cont2].IsAlive)
                {
                    count++;
                    
                    tournament[cont2].GetHit(tournament[cont1].Attack());if (count == 10)
                    {
                        tournament[cont2].IsAlive = false;
                        Console.WriteLine("\nThe warriors got tired and the second contestant gave up");
                    }
                    Console.WriteLine();
                    if (tournament[cont2].IsAlive)
                    {
                        tournament[cont1].GetHit(tournament[cont2].Attack());
                    }
                }
                if (!tournament[cont1].IsAlive)
                {
                    tournament.RemoveAt(cont1);
                }
                else
                if (!tournament[cont2].IsAlive)
                {
                    tournament.RemoveAt(cont2);
                }
                if (tournament.Count < 2)
                {
                    Console.WriteLine("HEY!\n Seems like you running out fighters, aren't you?\nWanna add some more fresh meat?\n\n" +
                        "1) Yes\n" +
                        "Any other key) No");
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
                                        warrior1 = new Spearman();
                                        warrior1.ShowInfo();
                                        warrior1.SayHello();
                                        tournament.Add(warrior1);
                                        quit = true;
                                        break;
                                    }
                                case '2':
                                    {
                                        warrior1 = new Legionary();
                                        warrior1.ShowInfo();
                                        warrior1.SayHello();
                                        tournament.Add(warrior1);
                                        quit = true;
                                        break;
                                    }
                                case '3':
                                    {
                                        warrior1 = new Cataphract();
                                        warrior1.ShowInfo();
                                        warrior1.SayHello();
                                        tournament.Add(warrior1);
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
                    soldier.ShowInfo();
                }
            }
            Console.WriteLine("\nAND THIS IS THE WINNER!");
            Console.ReadKey();
        }
    }
}

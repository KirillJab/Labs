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
            List<Soldier> battlefield = new List<Soldier>() { };
            Soldier warrior1 = new Spearman();
            int cont1 = -1, cont2 = -1;

            battlefield.Add(warrior1);
            warrior1 = new Legionary();
            battlefield.Add(warrior1);
            warrior1 = new Cataphract();
            battlefield.Add(warrior1);
            foreach (Soldier warrior in battlefield)
            {
                warrior.showInfo();
                warrior.sayHello();
                Console.WriteLine();
            }
            while(battlefield.Count > 1)
            {
                Console.WriteLine("\nWho do you want to see fighting for glory? Enter the number of the first contestant!");
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
                    if (cont1 < 1 || cont1 > battlefield.Count)
                    {
                        Console.WriteLine("Try again");
                    }
                    else
                    {
                        break;
                    }
                }
                Console.WriteLine("Enter the number of the second contestant!");
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
                    if (cont2 < 1 || cont2 > battlefield.Count || cont2 == cont1)
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

                while(battlefield[cont1].isAlive && battlefield[cont2].isAlive)
                {
                    count++;
                    
                    battlefield[cont2].gethit(battlefield[cont1].attack());if (count == 10)
                    {
                        battlefield[cont2].isAlive = false;
                        Console.WriteLine("\nThe warriors got tired and the second contestant gave up");
                    }
                    Console.WriteLine();
                    if (battlefield[cont2].isAlive)
                    {
                        battlefield[cont1].gethit(battlefield[cont2].attack());
                    }
                }
                if (!battlefield[cont1].isAlive)
                {
                    battlefield.RemoveAt(cont1);
                }
                else
                if (!battlefield[cont2].isAlive)
                {
                    battlefield.RemoveAt(cont2);
                }
                if (battlefield.Count < 2)
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
                                        warrior1.showInfo();
                                        warrior1.sayHello();
                                        battlefield.Add(warrior1);
                                        quit = true;
                                        break;
                                    }
                                case '2':
                                    {
                                        warrior1 = new Legionary();
                                        warrior1.showInfo();
                                        warrior1.sayHello();
                                        battlefield.Add(warrior1);
                                        quit = true;
                                        break;
                                    }
                                case '3':
                                    {
                                        warrior1 = new Cataphract();
                                        warrior1.showInfo();
                                        warrior1.sayHello();
                                        battlefield.Add(warrior1);
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
            }
            battlefield[0].gethit(battlefield[1].attack());
            Console.ReadKey();
        }
    }
}

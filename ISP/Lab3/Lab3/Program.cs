using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class Program
    {
        static int checkid(int count)
        {
            int id = -1;
            while (true)
            {
                try
                {
                    id = int.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Wrong input! ");
                }
                if (id > count || id < 1)
                {
                    Console.WriteLine("Please, try one more time");
                }
                else
                {
                    break;
                }
            }
            return id;
        }

        static void Main(string[] args)
        {
            bool quit = false;
            List<Human> people = new List<Human>();
            Human person = new Human("Gleb", 18, Human.Genders.Male);
            people.Add(person);

            while (!quit)
            {
                Console.WriteLine("1)  Add one more person to the list\n" +
                                  "2)  Add random person to the list\n" +
                                  "3)  Show all people in the list\n" +
                                  "4)  Delete person by index\n" +
                                  "5)  Make index say hello to everyone!\n" +
                                  "6)  Make everyone say hello to each other!\n" +
                                  "q)  Exit");
                switch (Console.ReadKey(true).KeyChar)
                {
                    case '1':
                        {
                            Console.Clear();
                            people.Add(person.setInfo());
                            break;
                        }
                    case '2':
                        {
                            Console.Clear();
                            person = new Human();
                            Console.WriteLine(" " + person.Name + " was added\n\n");
                            people.Add(person);
                            break;
                        }
                    case '3':
                        {
                            Console.Clear();
                            if (people.Count!=0)
                            {
                                Console.WriteLine();
                                Console.WriteLine("id");
                                people.ForEach(humanbeing => humanbeing.showInfo());
                                Console.WriteLine("\n\n");
                            }
                            else
                            {
                                Console.WriteLine("There is no one in the list right now");
                            }
                            break;
                        }
                    case '4':
                        {
                            Console.Clear();
                            Console.WriteLine("Enter the index you want to delete: ");
                            people.RemoveAt(checkid(people.Count) - 1);
                            break;
                        }
                    case '5':
                        {
                            Console.Clear();
                            Console.WriteLine("Enter the index which you want to say hello: ");
                            people[checkid(people.Count) - 1].sayHello();
                            Console.WriteLine();
                            break;
                        }
                    case '6':
                        {
                            Console.Clear();
                            Console.WriteLine();
                            for (int i = 0; i < people.Count; i++)
                            {
                                int j = i != people.Count - 1 ? i + 1 : 0;
                                people[i].sayHello(people[j].Name);
                            }
                            Console.WriteLine("\n\n");
                            break;
                        }
                    case 'q':
                        {
                            Console.Clear();
                            return;
                            break;
                        }
                    default:
                        {
                            Console.Clear();
                            break;
                        }
                }
            }
            Console.ReadKey(true);
        }
    }
}

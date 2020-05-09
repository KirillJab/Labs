using System;

namespace Lab7
{
    class Program
    {
        static void Main(string[] args)
        {
            Division first = new Division(20, 20);
            Division second = new Division(30, 20);
            Console.WriteLine((first / second).ToString('s'));
            Console.WriteLine((first / second).ToString('i'));
            Console.WriteLine((first / second).ToString('f'));
            Console.WriteLine((first / second).ToString('d'));
            Console.WriteLine((first / second).ToString('D'));
            while (true)
            {
                Division a = Division.Parse(Console.ReadLine());
                Console.WriteLine(a);
            }
            Console.ReadKey();
        }
    }
}

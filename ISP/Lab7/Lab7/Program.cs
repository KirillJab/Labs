using System;

namespace Lab7
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            Division a;
            Division b;
            Division[] mas = new Division[15];

            a = Division.Parse("1,125");
            b = Division.Parse("4/3");
            Console.WriteLine("a = " + a + " = " + a + " = " + a.ToString('d') + " = " + a.ToString('f') + " = " + a.ToString('F') + " = " + a.ToString('D'));
            Console.WriteLine("a++;");
            a++;
            Console.WriteLine("a = " + a + " = " + a.ToString('d') + " = " + a.ToString('f') + " = " + a.ToString('F') + " = " + a.ToString('D'));
            Console.WriteLine("b = " + b + " = " + (long)b + " = " + (float)b + " = " + (double)b + " = " + (decimal)b);
            if (a > b)
            {
                Console.WriteLine("a > b");
            }
            if (a < b)
            {
                Console.WriteLine("a < b");
            }
            if (a == b)
            {
                Console.WriteLine("a == b");
            }
            if (a != b)
            {
                Console.WriteLine("a != b");
            }
            if (a <= b)
            {
                Console.WriteLine("a <+ b");
            }
            if (a >= b)
            {
                Console.WriteLine("a >= b");
            }
            Console.WriteLine();
            Console.WriteLine("a + b = " + a + " + " + b + " = " + (a + b) + " = " + (a + b).ToString('f'));
            Console.WriteLine("a - b = " + a + " - " + b + " = " + (a - b) + " = " + (a - b).ToString('f'));
            Console.WriteLine("a * b = " + a + " * " + b + " = " + (a * b) + " = " + (a * b).ToString('f'));
            Console.WriteLine("a / b = " + a + " / " + b + " = " + (a / b) + " = " + (a / b).ToString('f'));
            Console.WriteLine("\n\n");

            Console.WriteLine("Unsorted Massive:");
            for (int i = 0; i< 15; i++)
            {
                mas[i] = new Division(rand.Next(-50, 100), rand.Next(-50, 100));
                Console.Write(mas[i] + " ");
            }
            Array.Sort(mas);
            Console.WriteLine("\nSorted Massive:");
            for (int i = 0; i < 15; i++)
            {
                Console.Write(mas[i] + " ");
            }
            Console.ReadKey();

        }
    }
}

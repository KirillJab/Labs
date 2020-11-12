using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Lab4_2_Itself
{
    class Program
    {
        const string DllPath = "D:\\University\\Labs\\ISP\\Lab4_2\\MyDll\\Debug\\MyDll.dll";

        [DllImport(DllPath, CallingConvention = CallingConvention.StdCall)]
        public static extern float Area(float rad);

        [DllImport(DllPath, CallingConvention = CallingConvention.StdCall)]
        public static extern float Volume(float rad);

        [DllImport(DllPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern float AreaAtDistance(float rad, float dist);

        [DllImport(DllPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern float CubeSide(float rad);

        static void Main(string[] args)
        {
            float rad;
            float dist;
            while (true)
            {
                while (true)
                {
                    try
                    {
                        Console.WriteLine("Please, enter the Radius of the sphere: ");
                        rad = float.Parse(Console.ReadLine());
                        if (rad <= 0)
                        {
                            throw new Exception();
                        }
                        break;
                    }
                    catch
                    {
                        Console.Clear();
                        Console.WriteLine("Please, try again\nRadius should be a positive float number\n");
                    }
                }
                while (true)
                {
                    try
                    {
                        Console.WriteLine("\nPlease, enter Distance (0 <= distance < radius): ");
                        dist = float.Parse(Console.ReadLine());
                        if (dist < 0 || dist >= rad)
                        {
                            throw new Exception();
                        }
                        break;
                    }
                    catch
                    {
                        Console.Clear();
                        Console.WriteLine("\nPlease, try again\nDistance should be a positive float number\n");
                    }
                }
                Console.WriteLine("\n\n" + new string('-', 40));
                Console.WriteLine("Area: " + Area(rad));
                Console.WriteLine("Volume: " + Volume(rad));
                Console.WriteLine("Cross-sectional Area at Distance from the centre: " + AreaAtDistance(rad, 0));
                Console.WriteLine("Cube Side with the same Volume: " + CubeSide(rad));
                Console.WriteLine(new string('-', 40));
                Console.WriteLine("\n\n" + new string('-', 30) + "\nPress 'q' to exit\n" + new string('-', 30));
                if ('q' == Console.ReadKey(true).GetHashCode())
                {
                    break;
                }
                else
                {
                    Console.Clear();
                }
            }
        }
    }
}

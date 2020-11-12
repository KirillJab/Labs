using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using static System.Math;
using System.Threading;
using System.Threading.Tasks;

namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Введите номер задания для проверки (1 - 3): \n\n1)  В заданной строке поменять порядок слов на обратный (слова разделены пробелами).\n");
                Console.WriteLine("2)  Сгенерировать равновероятно случайную строку длиной не более четырех строчных английских букв.\n");
                Console.WriteLine("3)  Реализовать вычисление параметров треугольника (стороны, углы, периметр, площадь, радиусы вписанной и описанной окружностей) по трем заданным параметрам.\n");
                Console.WriteLine("q)  Выход\n");
                switch (Console.ReadKey(true).KeyChar)
                {
                    case '1':
                        {
                            List<string> listOfWords = new List<string>();
                            string inpStr;
                            StringBuilder buff = new StringBuilder(40);

                            Console.WriteLine("Введите исходную строку:");
                            inpStr = Console.ReadLine();
                            for (int i = 0; i < inpStr.Length; i++)
                            {
                                if (inpStr[i] == ' ' && buff.Length != 0)
                                {
                                    buff.Append(' ');
                                    listOfWords.Insert(0, buff.ToString());
                                    buff.Clear();
                                    buff.Append(' ');
                                }
                                else
                                if (i == inpStr.Length - 1)
                                {
                                    buff.Append(inpStr[i].ToString() + ' ');
                                    if (buff[0] != ' ')
                                    {
                                        listOfWords.Insert(0, buff.ToString());
                                    }
                                    buff.Clear();
                                    buff.Append(' ');
                                }
                                else
                                {
                                    buff.Append(inpStr[i]);
                                }
                                if (buff[0] == ' ')
                                {
                                    buff.Clear();
                                }
                            }
                            listOfWords.ForEach(Console.Write);
                            listOfWords.Clear();
                            Console.WriteLine("\n\nНажмите любую кнопку, чтобы продолжить\n");
                            Console.ReadKey();
                            break;
                        }
                    case '2':
                        {
                            Random random = new Random();
                            StringBuilder str = new StringBuilder("abcdefghijklmnopqrstuvwxyz"), res = new StringBuilder(4);
                            int j;

                            for (int i = 0; i < 4; i++)
                            {
                                j = random.Next(0, 26 - i);
                                res.Append(str[j].ToString());
                                str.Remove(j, 1);
                            }
                            Console.WriteLine(res + " равновероятно случайная строка");
                            Console.WriteLine("\nНажмите любую кнопку, чтобы продолжить\n");
                            Console.ReadKey();
                            break;
                        }
                    case '3':
                        {
                            bool parseCheck = true; ;
                            int x1, x2, x3, y1, y2, y3;
                            double angA, angB, angC, AB, BC, CA, per, area, rad1, rad2, dotx, doty;
                            x1 = x2 = x3 = y1 = y2 = y3 = 0;

                            while (parseCheck)
                            {
                                try
                                {
                                    Console.Write("Введите x1: ");
                                    x1 = int.Parse(Console.ReadLine());
                                    parseCheck = false;
                                }
                                catch
                                {
                                    Console.WriteLine("Некорректный ввод. Попробуйте снова");
                                }
                            }
                            parseCheck = true;
                            while (parseCheck)
                            {
                                try
                                {
                                    Console.Write("Введите y1: ");
                                    y1 = int.Parse(Console.ReadLine());
                                    parseCheck = false;
                                }
                                catch
                                {
                                    Console.WriteLine("Некорректный ввод. Попробуйте снова");
                                }
                            }
                            parseCheck = true;
                            while (parseCheck)
                            {
                                try
                                {
                                    Console.Write("Введите x2: ");
                                    x2 = int.Parse(Console.ReadLine());
                                    parseCheck = false;
                                }
                                catch
                                {
                                    Console.WriteLine("Некорректный ввод. Попробуйте снова");
                                }
                            }
                            parseCheck = true;
                            while (parseCheck)
                            {
                                try
                                {
                                    Console.Write("Введите y2: ");
                                    y2 = int.Parse(Console.ReadLine());
                                    parseCheck = false;
                                }
                                catch
                                {
                                    Console.WriteLine("Некорректный ввод. Попробуйте снова");
                                }
                            }
                            parseCheck = true;
                            while (parseCheck)
                            {
                                try
                                {
                                    Console.Write("Введите x3: ");
                                    x3 = int.Parse(Console.ReadLine());
                                    parseCheck = false;
                                }
                                catch
                                {
                                    Console.WriteLine("Некорректный ввод. Попробуйте снова");
                                }
                            }
                            parseCheck = true;
                            while (parseCheck)
                            {
                                try
                                {
                                    Console.Write("Введите y3: ");
                                    y3 = int.Parse(Console.ReadLine());
                                    parseCheck = false;
                                }
                                catch
                                {
                                    Console.WriteLine("Некорректный ввод. Попробуйте снова");
                                }
                            }
                            AB = Sqrt((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2));
                            BC = Sqrt((x2 - x3) * (x2 - x3) + (y2 - y3) * (y2 - y3));
                            CA = Sqrt((x1 - x3) * (x1 - x3) + (y1 - y3) * (y1 - y3));
                            if (AB == 0 || BC == 0 || CA == 0 || AB + BC == CA || AB + CA == BC || BC + CA == AB)
                            {
                                Console.WriteLine("\n\nТакого треугольника не существует!");
                            }
                            else
                            {
                                angA = Acos((BC * BC - CA * CA - AB * AB) / (-2 * CA * AB)) / PI * 180;
                                angB = Acos((CA * CA - BC * BC - AB * AB) / (-2 * BC * AB)) / PI * 180;
                                angC = Acos((AB * AB - CA * CA - BC * BC) / (-2 * BC * CA)) / PI * 180;
                                per = AB + BC + CA;
                                area = Abs(((x1 - x3) * (y2 - y3) - (x2 - x3) * (y1 - y3)) / 2);
                                rad1 = Sqrt(2 * ((per / 2 - AB) * (per / 2 - BC) * (per / 2 - CA)) / per);
                                rad2 = AB * BC * CA / (4 * Sqrt(per / 2 * (per / 2 - AB) * (per / 2 - BC) * (per / 2 - CA)));
                                dotx = (float)(x1 + x2 + x3) / 3;
                                doty = (float)(y1 + y2 + y3) / 3;
                                Console.WriteLine("\nУгол А: " + angA + "\nУгол b: " + angB + "\nУгол C: " + angC + "\nAB = " + AB + "\nBC = " + BC + "\nCA = " + CA + "\nПериметр: " + per + "\nПлощадь: " + area + "\nРадиус вписанной окружности: " + rad1 + "\nРадиус описанной окружности: " + rad2 + "\nТочка перескчения медиан (Центр тяжести): (" + dotx + "; " + doty + ")");
                            }
                            Console.WriteLine("\nНажмите любую кнопку, чтобы продолжить\n");
                            Console.ReadKey();
                            break;
                        }
                    case 'q':
                        {
                            exit = true;
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
                Console.Clear();
            }
        }
    }
}
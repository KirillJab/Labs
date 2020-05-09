using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Lab7
{
    class Division : IComparable<Division>, IEquatable<Division>
    {
        public long Numerator { get; }
        public long Denominator { get; }

        public Division(long num, long den)
        {
            long gcd;

            if (den == 0)
            {
                throw new DivideByZeroException();
            }
            if (den < 0)
            {
                den = -den;
                num = -num;
            }
            gcd = GCD(num, den);
            Numerator = num / gcd;
            Denominator = den / gcd;
        }
        public Division(long number) : this(number, 1) { }
        public Division() : this(0) { }
        public static Division Parse(string input)
        {
            Regex rx;
            MatchCollection matches;

            rx = new Regex(@"-?\d+/-?\d+");
            matches = rx.Matches(input);

            if (matches.Count == 1)
            {
                try
                {
                    string str = matches[0].ToString();
                    string[] nums = str.Split(new char[] { '/' });

                    return new Division(long.Parse(nums[0]), long.Parse(nums[1]));
                    
                }
                catch { }
            }

            rx = new Regex(@"-?\d+");
            matches = rx.Matches(input);

            if (matches.Count == 2)
            {
                try
                {
                    Console.WriteLine("ASD");
                    return new Division(long.Parse(matches[0].Value), long.Parse(matches[1].Value));
                }
                catch { }
            }
            return null;
        }

        public int Compare(Division other)
        {
            long a;
            long b;
            checked //Preventing overflow
            {
                b = Denominator * other.Numerator;
                a = Numerator * other.Denominator;
            }
            return a.CompareTo(b);
        }
        public int CompareTo(Division other)
        {
            return this.Compare(other);
        }
        public bool Equals(Division other)
        {
            return this.Compare(other) == 0;
        }

        static long GCD(long a, long b) //НОД method
        {
            if (a == 0)
            {
                return Math.Abs(b);
            }
            if (b == 0)
            {
                return Math.Abs(a);
            }
            while (true)
            {
                if ((a %= b) == 0)
                    return Math.Abs(b);
                else if ((b %= a) == 0)
                    return Math.Abs(a);
            }
        }

        public Division ReduceFraction(Division fraction)
        {
            long gcd;
            gcd = GCD(fraction.Numerator, fraction.Denominator);
            return new Division(fraction.Numerator / gcd, fraction.Denominator / gcd);
        }


        public static Division operator +(Division a, Division b)
        {
            long num;
            long den;
            checked
            {
                num = a.Numerator * b.Denominator + b.Numerator * a.Denominator;
                den = a.Denominator * b.Denominator;
            }
            return new Division(num, den);
        }

        public static Division operator -(Division a, Division b)
        {
            long num;
            long den;
            checked
            {
                num = a.Numerator * b.Denominator - b.Numerator * a.Denominator;
                den = a.Denominator * b.Denominator;
            }
            return new Division(num, den);
        }

        public static Division operator *(Division a, Division b)
        {
            long num;
            long den;
            checked
            {
                num = a.Numerator * b.Numerator;
                den = a.Denominator * b.Denominator;
            }
            return new Division(num, den);
        }

        public static Division operator /(Division a, Division b)
        {
            long num;
            long den;

            checked
            {
                num = a.Numerator * b.Denominator;
                den = a.Denominator * b.Numerator;
            }
            return new Division(num, den);
        }

        public override string ToString()
        {
            return ToString('s');
        }
        public string ToString(char type)
        {
            switch (type)
            {
                case 's':
                    {
                        if (Denominator != 1 && Numerator != 0)
                        {
                            return Numerator + "/" + Denominator;
                        }
                        else
                        {
                            return Numerator.ToString();
                        }
                        break;
                    }
                case 'i':
                    {
                        if (Denominator != 1 && Numerator != 0)
                        {
                            return (Numerator / Denominator).ToString();
                        }
                        else
                        {
                            return Numerator.ToString();
                        }
                        break;
                    }
                case 'f':
                    {
                        if (Denominator != 1 && Numerator != 0)
                        {
                            return (Numerator / (float) Denominator).ToString();
                        }
                        else
                        {
                            return Numerator.ToString();
                        }
                        break;
                    }
                case 'd':
                    {
                        if (Denominator != 1 && Numerator != 0)
                        {
                            return (Numerator / (double)Denominator).ToString();
                        }
                        else
                        {
                            return Numerator.ToString();
                        }
                        break;
                    }
                case 'D':
                    {
                        if (Denominator != 1 && Numerator != 0)
                        {
                            return (Numerator / (decimal)Denominator).ToString();
                        }
                        else
                        {
                            return Numerator.ToString();
                        }
                        break;
                    }
                default:
                    {
                        throw new Exception("Unkown type");
                        break;
                    }
            }
            return null;
        }
    }
}

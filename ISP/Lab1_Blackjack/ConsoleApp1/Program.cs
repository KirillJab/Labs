using System;
using System.Collections.Generic;
using System.Threading;

namespace ConsoleApp1
{
    class BlackJack
    {
        static void Main(string[] args)
        {
            throw new ArgumentException("ASDASDASDASDASSSSSSSSSSSSSSSSSSSSSSSSSSS");
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("\n\t Здравуствуйте, Дорогой Игрок! Добро пожаловать в наше -КАЗИНО-!\n\n В данный момент доступны только столики с игрой -BLACKJACK-. Желаете испытать удачу?\n\n\n 1 - Да\n\n 2 - Пожалуй откажусь (выйти из казино)");
            bool choice = true;
            while (choice)
            {
                switch (Console.ReadKey(true).KeyChar)
                {
                    case '1':
                        {
                            choice = false;
                            break;
                        }
                    case '2':
                        {
                            choice = false;
                            Console.WriteLine(" \n\n Думаете сегодня не ваш день? Что ж, тогда до скорой встречи!\n\n\n\n");
                            return;
                        }
                    default:
                        {
                            break;
                        }
                }
            }
            Console.Clear();
            Game Player = new Game();
            bool firstTry = true;
            bool watchesOn = true;
            while (true)
            {
                if (Player.Money > 0)
                {
                    if (!firstTry)
                    {
                        Console.WriteLine("Ваш баланс: " + Player.Money + " Желаете продолжить играть?\n\n\n 1 - Да\n\n 2 - Нет, с меня хватит");
                        bool choice1 = true;
                        while (choice1)
                        {
                            switch (Console.ReadKey(true).KeyChar)
                            {
                                case '1':
                                    {
                                        choice1 = false;
                                        Console.Clear();
                                        break;
                                    }
                                case '2':
                                    {
                                        choice1 = false;
                                        Console.WriteLine(" \n\n Что ж, тогда до скорой встречи!\n\n\n\n");
                                        return;
                                    }
                                default:
                                    {
                                        break;
                                    }
                            }
                        }
                    }
                    Player.GetBet();
                    Player.GetColdDeck();
                    Console.Write(" Тасуем карты."); Thread.Sleep(600); Console.Write("."); Thread.Sleep(600); Console.WriteLine(".");
                    Console.WriteLine(" Раздаём карты: \n");
                    Player.DealCards();
                    Player.DealCards();
                    Player.Play();
                    firstTry = false;
                }
                else
                if (watchesOn)
                {
                    Console.WriteLine(" Ваш баланс: " + Player.Money + ". У вас законичились фишки. Заложить дедовы часы? (+800)\n\n\n 1 - Да\n\n 2 - Нет, с меня хватит");
                    bool choice2 = true;
                    while (choice2)
                    {
                        switch (Console.ReadKey(true).KeyChar)
                        {
                            case '1':
                                {
                                    Player.Money += 800;
                                    watchesOn = false;
                                    choice2 = false;
                                    Console.Clear();
                                    break;
                                }
                            case '2':
                                {
                                    choice2 = false;
                                    Console.WriteLine(" \n\n Что ж, тогда до следующей зарплаты!\n\n\n\n");
                                    return;
                                }
                        }
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine(" Ваш баланс: " + Player.Money + ". У вас законичились фишки. \n Снова. \n Вы проиграли дедовы часы! Как вам не стыдно! \n\n Идите домой!");
                    Thread.Sleep(5000);
                    return;
                }
            }
        }
    }
}

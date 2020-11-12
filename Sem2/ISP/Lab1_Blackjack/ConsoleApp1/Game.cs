using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ConsoleApp1
{
    class Game
    {
        protected static int origRow;
        protected static int origCol;
        public int Money = 500;
        int Bet;
        int Bet2;
        Deck Hand = new Deck();
        Deck DealerHand = new Deck();
        Deck Hand2 = new Deck();
        Deck Deck = new Deck();
        public int GetBet()
        {
            Console.WriteLine("\n Ваш баланс в фишках: " + Money + "\n Введите сумму ставки:");
            while (true)
            {
                try
                {
                    Console.Write(" ");
                    Bet = Convert.ToInt32(Console.ReadLine());
                    if (Bet <= Money && Bet > 0)
                    {
                        break;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine(" Ставка НЕ может превышать текущий баланс или быть ниже 1!\n Ваш баланс в фишках: " + Money + "\n Введите сумму ставки:"); ;
                        continue;
                    }
                }
                catch
                {
                    Console.Clear();
                    Console.WriteLine(" Ввод ставки некоректен! Попробуйте снова");
                    Console.WriteLine(" Ваш баланс в фишках: " + Money + "\n Введите сумму ставки:");
                    continue;
                }
            }
            Money -= Bet;
            Console.Clear();
            Console.WriteLine("\n Ваш баланс в фишках:" + Money + "\n Ваша ставка #1: " + Bet);
            return Bet;
        }
        int GetBet2()
        {
            Console.WriteLine("\n Ваш баланс в фишках: " + Money + "\n Введите сумму ставки #2:");
            while (true)
            {
                try
                {
                    Console.Write(" ");
                    Bet2 = Convert.ToInt32(Console.ReadLine());
                    if (Bet2 <= Money && Bet2 > 0)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine(" Ставка НЕ может превышать текущий баланс или быть ниже 1!\n Ваш баланс в фишках: " + Money + "\n Введите сумму ставки:"); ;
                        continue;
                    }
                }
                catch
                {
                    Console.WriteLine(" Ввод ставки некоректен! Попробуйте снова");
                    Console.WriteLine(" Ваш баланс в фишках: " + Money + "\n Введите сумму ставки:");
                    continue;
                }
            }
            Money -= Bet2;
            return Bet2;
        }
        public void GetColdDeck()
        {
            Deck.GetDeck();
            Deck.ShuffleDeck();
            Hand.Cards.Clear();
            DealerHand.Cards.Clear();
        }
        public void DealCards()
        {
            Console.SetCursorPosition(origCol + 0, origRow + 6);
            Console.WriteLine(" Карты Игрока:\n\n");
            Console.WriteLine(" Карты Дилера:");
            Thread.Sleep(600);
            Hand.Cards.Add(Deck.GetCard());
            DealerHand.Cards.Add(Deck.GetCard());
            Console.SetCursorPosition(origCol + 3, origRow + 7);
            Hand.ShowDeck();
            Console.SetCursorPosition(origCol + 0, origRow + 6);
            if (GetDealerScore() > 21)
            {
                for (int i = 0; i < DealerHand.Cards.Count; i++)
                {
                    if (DealerHand.Cards[i].Cost == 11)
                    {
                        DealerHand.Cards[i].Cost = 1;
                        if (GetDealerScore() < 22)
                        {
                            break;
                        }
                    }
                }
            }
            if (GetScore() > 21)
            {
                for (int i = 0; i < Hand.Cards.Count; i++)
                {
                    if (Hand.Cards[i].Cost == 11)
                    {
                        Hand.Cards[i].Cost = 1;
                        if (GetScore() < 22)
                        {
                            break;
                        }
                    }
                }
            }
            Console.WriteLine(" Карты Игрока:\tСчёт руки: " + GetScore());
            Thread.Sleep(600);
            Console.SetCursorPosition(origCol + 3, origRow + 10);
            DealerHand.ShowDealerDeck();
            Console.SetCursorPosition(origCol + 3, origRow + 11);
        }
        public int GetScore()
        {
            int score = 0;
            for (int i = 0; i < Hand.Cards.Count; i++)
            {
                score += Hand.Cards[i].Cost;
            }
            return score;
        }
        public int GetScore2()
        {
            int score = 0;
            for (int i = 0; i < Hand2.Cards.Count; i++)
            {
                score += Hand2.Cards[i].Cost;
            }
            return score;
        }
        public int GetDealerScore()
        {
            int score = 0;
            for (int i = 0; i < DealerHand.Cards.Count; i++)
            {
                score += DealerHand.Cards[i].Cost;
            }
            return score;
        }
        public void Play()
        {
            bool passed = GetScore() > 21;
            bool passed2 = true;
            bool isSplit = false;
            if (!passed)
            {
                if (Hand.Cards[0].Cost == Hand.Cards[1].Cost)
                {
                    Console.WriteLine("\n 1 - Дубль \n\n 2 - Взять\n\n 3 - Остановиться\n\n 4 - Сплит");
                    bool choice = false;
                    while (!choice)
                    {
                        switch (Console.ReadKey(true).KeyChar)
                        {
                            case '1':
                                {
                                    if (Money >= Bet)
                                    {
                                        Money -= Bet;
                                        Bet *= 2;
                                        Hand.Cards.Add(Deck.GetCard());
                                        if (isSplit)
                                            Console.Write(" Переходим ко второй ставке\r");
                                        passed = UpdateCards();
                                        choice = true;
                                    }
                                    else
                                        Console.Write("Ставка НЕ может превышать текущий баланс!\r");
                                    break;
                                }
                            case '2':
                                {
                                    Hand.Cards.Add(Deck.GetCard());
                                    passed = UpdateCards();
                                    break;
                                }
                            case '3':
                                {
                                    if (isSplit)
                                        Console.Write(" Переходим ко второй ставке");
                                    choice = true;
                                    break;
                                }
                            case '4':
                                {
                                    if (!isSplit)
                                    {
                                        Split();
                                        Console.Clear();
                                        passed = UpdateCards();
                                        passed2 = UpdateCards2();
                                        Thread.Sleep(600);
                                        Console.SetCursorPosition(origCol + 0, origRow + 9);
                                        Console.WriteLine(" Карты Дилера:");
                                        Console.SetCursorPosition(origCol + 3, origRow + 10);
                                        DealerHand.ShowDealerDeck();
                                        Thread.Sleep(600);
                                        Console.SetCursorPosition(origCol + 0, origRow + 11);
                                        Console.WriteLine("\n 1 - Дубль \n\n 2 - Взять\n\n 3 - Остановиться");
                                        isSplit = true;
                                    }
                                    break;
                                }
                            default:
                                {
                                    break;
                                }
                        }
                        if (passed && !isSplit)
                        {
                            Console.WriteLine(" У вас перебор! Ставка проиграна.");
                            Thread.Sleep(2500);
                            Console.Clear();
                            break;
                        }
                        if (passed)
                        {
                            Console.WriteLine(" У вас перебор! Ставка проиграна. Переходим ко второй");
                            choice = true;
                        }
                    }
                    if (isSplit)
                        Bet2 = GetBet2();
                    while (choice && !passed2)
                    {
                        Console.SetCursorPosition(origCol + 0, origRow + 11);
                        Console.WriteLine("\n 1 - Дубль \n\n 2 - Взять\n\n 3 - Остановиться");
                        switch (Console.ReadKey(true).KeyChar)
                        {
                            case '1':
                                {
                                    if (Money >= Bet2)
                                    {
                                        Money -= Bet2;
                                        Bet2 *= 2;
                                        Hand2.Cards.Add(Deck.GetCard());
                                        passed2 = UpdateCards2();
                                        choice = true;
                                    }
                                    else
                                        Console.Write("Ставка НЕ может превышать текущий баланс!\r");
                                    break;
                                }
                            case '2':
                                {
                                    Hand2.Cards.Add(Deck.GetCard());
                                    passed2 = UpdateCards2();
                                    break;
                                }
                            case '3':
                                {
                                    choice = false;
                                    break;
                                }
                            default:
                                {
                                    break;
                                }
                        }
                        if (passed2)
                        {
                            Console.WriteLine(" У вас перебор! Ставка #2 проиграна.");
                            break;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("\n 1 - Дубль \n\n 2 - Взять\n\n 3 - Остановиться");
                    bool choice = false;
                    while (!choice)
                    {
                        switch (Console.ReadKey(true).KeyChar)
                        {
                            case '1':
                                {
                                    if (Money >= Bet)
                                    {
                                        Money -= Bet;
                                        Bet *= 2;
                                        Hand.Cards.Add(Deck.GetCard());
                                        passed = UpdateCards();
                                        choice = true;
                                    }
                                    else
                                        Console.Write("Ставка НЕ может превышать текущий баланс!\r");
                                    break;
                                }
                            case '2':
                                {
                                    Hand.Cards.Add(Deck.GetCard());
                                    passed = UpdateCards();
                                    break;
                                }
                            case '3':
                                {
                                    choice = true;
                                    break;
                                }
                            default:
                                {
                                    break;
                                }
                        }
                        if (passed)
                        {
                            choice = true;
                            break;
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine(" У вас перебор! Ставка проиграна.");
                Thread.Sleep(2500);
                Console.Clear();
            }
            int X = 0;
            if (isSplit)
                X = 5;
            if (!passed)
            {

                Console.SetCursorPosition(origCol + 0, origRow + 19 + X);
                Console.WriteLine(" Результаты руки #1");
                UpdateDealerCards();
                while (GetDealerScore() < 17)
                {
                    DealerHand.Cards.Add(Deck.GetCard());
                    UpdateDealerCards();
                }
                Console.SetCursorPosition(origCol + 0, origRow + 20 + X);
                if (GetDealerScore() > 21)
                {
                    Console.WriteLine(" У дилера перебор! Вы выиграли +" + Bet * 2 + "!");
                    Money += Bet * 2;
                }
                else
                {
                    if (GetDealerScore() < GetScore())
                    {
                        Console.WriteLine(" У дилера меньше! Вы выиграли +" + Bet * 2 + "!");
                        Money += Bet * 2;
                    }
                    if (GetDealerScore() > GetScore())
                    {
                        Console.WriteLine(" У дилера больше! Вы проиграли -" + Bet + "!");
                    }
                    if (GetDealerScore() == GetScore())
                    {
                        Console.WriteLine(" Ничья! Вам возвращается ваша ставка!");
                        Money += Bet;
                    }
                }
            }
            Thread.Sleep(300);
            if (!passed2)
            {
                Console.SetCursorPosition(origCol + 60, origRow + 19 + X);
                Console.WriteLine(" Результаты руки #2");
                UpdateDealerCards();
                while (GetDealerScore() < 17)
                {
                    DealerHand.Cards.Add(Deck.GetCard());
                    UpdateDealerCards();
                }
                Console.SetCursorPosition(origCol + 60, origRow + 20 + X);
                if (GetDealerScore() > 21)
                {
                    Console.WriteLine(" У дилера перебор! Вы выиграли +" + Bet2 * 2 + "!");
                    Money += Bet2 * 2;
                }
                else
                {
                    if (GetDealerScore() < GetScore2())
                    {
                        Console.WriteLine(" У дилера меньше! Вы выиграли +" + Bet2 * 2 + "!");
                        Money += Bet2 * 2;
                    }
                    if (GetDealerScore() > GetScore2())
                    {
                        Console.WriteLine(" У дилера больше! Вы проиграли -" + Bet2 + "!");
                    }
                    if (GetDealerScore() == GetScore2())
                    {
                        Console.WriteLine(" Ничья! Вам возвращается ваша ставка!");
                        Money += Bet2;
                    }
                }
            }
            if (passed)
            {
                Console.WriteLine(" У вас перебор! Ставка проиграна.");
            }
               Thread.Sleep(3500);
            Console.Clear();
        }
        bool UpdateCards()
        {
            if (GetScore() > 21)
            {
                for (int i = 0; i < Hand.Cards.Count; i++)
                {
                    if (Hand.Cards[i].Cost == 11)
                    {
                        Hand.Cards[i].Cost = 1;
                        if (GetScore() < 22)
                        {
                            break;
                        }
                    }
                }
            }
            Thread.Sleep(600);
            Console.SetCursorPosition(origCol + 3, origRow + 7);
            Hand.ShowDeck();
            Console.SetCursorPosition(origCol + 0, origRow + 6);
            Console.WriteLine(" Карты Игрока:\tСчёт руки: " + GetScore());
            Console.SetCursorPosition(origCol + 0, origRow + 1);
            Console.WriteLine(" Ваш баланс в фишках:" + Money + "\n Ваша ставка #1: " + Bet);
            Console.SetCursorPosition(origCol + 0, origRow + 18);
            return GetScore() > 21;
        }
        void UpdateDealerCards()
        {
            if (GetDealerScore() > 21)
            {
                for (int i = 0; i < DealerHand.Cards.Count; i++)
                {
                    if (DealerHand.Cards[i].Cost == 11)
                    {
                        DealerHand.Cards[i].Cost = 1;
                        if (GetDealerScore() < 22)
                        {
                            break;
                        }
                    }
                }
            }
            Thread.Sleep(600);
            Console.SetCursorPosition(origCol + 3, origRow + 10);
            DealerHand.ShowDeck();
            Console.SetCursorPosition(origCol + 0, origRow + 9);
            Console.WriteLine(" Карты Дилера:\tСчёт дилера: " + GetDealerScore());
            Console.SetCursorPosition(origCol + 0, origRow + 20);
        }
        bool UpdateCards2()
        {
            if (GetScore2() > 21)
            {
                for (int i = 0; i < Hand2.Cards.Count; i++)
                {
                    if (Hand2.Cards[i].Cost == 11)
                    {
                        Hand2.Cards[i].Cost = 1;
                        if (GetScore2() < 22)
                        {
                            break;
                        }
                    }
                }
            }
            Thread.Sleep(600);
            Console.SetCursorPosition(origCol + 43, origRow + 7);
            Hand2.ShowDeck();
            Console.SetCursorPosition(origCol + 40, origRow + 6);
            Console.WriteLine(" Карты Игрока:\tСчёт руки #2: " + GetScore2());
            Console.SetCursorPosition(origCol + 41, origRow + 2);
            Console.Write("Ваша ставка #2: " + Bet2);
            Console.SetCursorPosition(origCol + 0, origRow + 18);
            return GetScore2() > 21;
        }
        void Split()
        {
            Hand2.Cards.Add(Hand.Cards[1]);
            Hand.Cards.RemoveAt(1);
        }
    }
}
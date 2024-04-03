using CustomLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace lab12._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int answer = 0;
            MyList<Emoji>? current = null;

            while (true)
            {
                Console.WriteLine("Данная программа демонстрирует работу с собственной Generic коллекцией типа двунаправленный список.\n\nВыберете одно из предложенных дествий:");
                Console.WriteLine("1) Выполнить действие над существующим листом");
                Console.WriteLine("2) Создать новый лист");

                answer = ChooseAnswer(1, 2);
                switch (answer)
                {
                    case 1:
                        if (MyList<Emoji>.lists.Count != 0)
                        {
                            Console.WriteLine("Выберете один из листов:\n");

                            int k = 0;
                            foreach(MyList<Emoji> e in MyList<Emoji>.lists)
                            {
                                Console.WriteLine($"{k+1}) Лист #{e.Id}");
                                k++;
                            }
                            k = 0;

                            answer = ChooseAnswer(1, MyList<Emoji>.lists.Count);
                            current = MyList<Emoji>.lists[answer-1];
                        }
                        return; 
                    case 2:
                        return;
                    default: return;
                }
            }
        }

        static int ChooseAnswer(int a, int b)   //выбор действия из целых
        {
            int answer = 0;
            bool checkAnswer;
            do
            {
                checkAnswer = int.TryParse(Console.ReadLine(), out answer);
                if ((answer > b || answer < a) || (!checkAnswer))
                {
                    Console.WriteLine("Вы некорректно ввели число, повторите ввод еще раз. Обратите внимание на то, что именно нужно ввести.");
                }
            } while ((answer > b || answer < a) || (!checkAnswer));

            return answer;
        }
    }
}

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
                            Console.Clear();
                            Console.WriteLine("Выберете один из листов:\n");

                            int k = 1;
                            foreach(MyList<Emoji> e in MyList<Emoji>.lists)
                            {
                                Console.WriteLine($"{k}) Лист #{e.Id}");
                                k++;
                            }
                            k = 0;

                            answer = ChooseAnswer(1, MyList<Emoji>.lists.Count);
                            int curN = answer;
                            current = MyList<Emoji>.lists[answer-1];
                            Console.Clear();

                            Console.WriteLine("Выберете возможные дествия над листом:\n\n");
                            Console.WriteLine("1) Распечатать лист");
                            Console.WriteLine("2) Создать глубокую копию");
                            Console.WriteLine("3) Удалить лист");
                            Console.WriteLine("4) Удалить все объекты с заданным именем");
                            Console.WriteLine("5) Добавить х случайных элементов в начало");
                            Console.WriteLine("0) Главное меню");

                            answer = ChooseAnswer(0, 5);
                            switch (answer)
                            {
                                case 0: break;

                                case 1:
                                    Console.Clear();
                                    current.PrintList();
                                    Console.WriteLine("Нажмите, чтобы выйти");
                                    Console.ReadLine();
                                    break;
                                case 2:
                                    Console.Clear();
                                    MyList<Emoji> newList = current.Clone();
                                    Console.WriteLine("Клонирование произведено");
                                    break;
                                case 3:
                                    Console.Clear();
                                    MyList<Emoji>.lists.RemoveAt(curN - 1);
                                    current = null;
                                    Console.WriteLine("Удаление произведено");
                                    break;
                                case 4:
                                    Console.Clear();
                                    Console.WriteLine("Введите имя для удаления:");
                                    string name = Console.ReadLine();
                                    Console.Clear();
                                    try
                                    { 
                                        MyList<Emoji>.lists[curN - 1] = MyList<Emoji>.lists[curN - 1].DeleteByName(name);
                                        Console.WriteLine("Удаление было произведено");
                                    }
                                    catch { Console.WriteLine("Действие невозможно с этим типом данных"); }
                                    break ; 
                                case 5:
                                    Console.Clear();
                                    Console.WriteLine("Сколько элементов вы хотите добавить?");
                                    answer= ChooseAnswer(0, 1000);
                                    MyList<Emoji>.lists[curN - 1] = MyList<Emoji>.lists[curN - 1].AddRandomItemsToBegin(answer);
                                    Console.WriteLine("Добавление было произведено");
                                    break;
                                default: break;
                            }
                            break;
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Листов еще нет, нажмите любую клавишу, чтобы продолжить");
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        }
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Выберете действие:");
                        Console.WriteLine("1) Создать пустой лист");
                        Console.WriteLine("2) Проинициализировать лист");
                        Console.WriteLine("0) Вернуться назад");

                        answer = ChooseAnswer(0, 2);
                        switch (answer)
                        {
                            case 0:
                                break; 
                            case 1:
                                Console.Clear();
                                MyList<Emoji>.CreateEmptyMyList();
                                break;
                            case 2:
                                Console.Clear();
                                Console.WriteLine("Введите количество элементов:");
                                int number = ChooseAnswer(0, 1000);
                                Console.Clear();
                                Console.WriteLine("Вводите данные:");
                                MyList<Emoji>.InitMyList(number);
                                Console.Clear();
                                break;
                            default: break;
                        }
                        break;
                    default: break;
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

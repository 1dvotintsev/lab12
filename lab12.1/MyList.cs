using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomLibrary;

namespace lab12._1
{
    public class Id
    {
        public static int overallCount = 0;
        public int number;

        public Id()
        {
            this.number = overallCount;
            overallCount++;
        }
        public override string ToString()
        {
            return number.ToString();
        }
        public override bool Equals(object? obj)
        {
            if (obj is IdNumber em)
                return this.number == em.number;
            return false;
        }

        public override int GetHashCode()
        {
            return number.GetHashCode();
        }
    }

    public class MyList<T> where T : IInit, ICloneable, new()
    {
        public static List<MyList<T>> lists = new List<MyList<T>>(); 
        public Node<T>? beg;
        public Node<T>? end;
        protected Id id;

        public string Id
        {
            get { return id.ToString(); }
        }

        int count = 0;

        public int Count => count;

        public void AddToBegin(T item)
        {
            T newData = (T)item.Clone();
            Node<T> newItem = new Node<T>(newData);
            count++;

            if (beg != null)
            {
                beg.Prev = newItem;
                newItem.Next = beg;
                beg = newItem;
            }
            else
            {
                beg = newItem;
                end = beg;
            }
        }

        public void AddToEnd(T item)
        {
            T newData = (T)item.Clone();
            Node<T> newItem = new Node<T>(newData);
            count++;

            if (end != null)
            {
                end.Next = newItem;
                newItem.Prev = end;
                end = newItem;
            }
            else
            {
                beg = newItem;
                end = beg;
            }
        }

        public MyList() 
        {
            id = new Id();
            lists.Add(this);
            count = 0;
        }

        public MyList(int size)
        {
            if (size <= 0) throw new Exception("Невозможный размер");
            beg = Node<T>.MakeRandomData();
            end = beg;
            for(int i = 0; i < size; i++) 
            {
                T newItem = Node<T>.MakeRandomItem();
                AddToEnd(newItem);
            }
            id = new Id();
            lists.Add(this);
        }

        public MyList(params T[] collection)
        {
            if(collection == null) throw new Exception("Коллекция пуста");
            if (collection.Length == 0) throw new Exception("Коллекция пуста");
            T newData = (T)collection[0].Clone();

            beg = new Node<T> (newData);
            end = beg;

            for(int i = 0;i < collection.Length;i++)
            {
                AddToEnd(collection[i]);
            }
            id = new Id ();
            lists.Add(this);
        }

        public void PrintList()
        {
            if(count == 0)
                Console.WriteLine("Коллекция пуста");
            Node<T>? current = beg;

            while (current != null)
            {
                Console.WriteLine(current);
                current = current.Next;
            }
        }

        public MyList<T> Clone()
        {
            if (this == null) throw new Exception("Список не инициализирован");
            if (count == 0) throw new Exception("Список не инициализирован");

            MyList<T> clone = new MyList<T>();

            Node<T>? current = beg;

            while (current != null)
            {
                //T cloneData = (T)current.Data.Clone();

                clone.AddToEnd(current.Data);

                current = current.Next;
            }

            return clone;
        }

        public MyList<T>? Delete(Node<T> target)
        {
            if (this == null) throw new Exception("Список не инициализирован");
            if (count == 0) throw new Exception("Список не инициализирован");

            if(beg.Equals(target) && end.Equals(target))
            {
                count--;
                return null;
            }
            else if (beg.Equals(target))
            {
                beg = beg.Next;
                beg.Prev = null;
                count--;
                return this;
            }
            else if(end.Equals(target))
            {
                end = end.Prev;
                end.Next = null;
                count--;
                return this;
            }

            Node<T>? current = beg.Next;
            while(current != end)
            {
                if(current.Equals(target))
                {
                    current.Prev.Next = current.Next;
                    current.Next.Prev = current.Prev;
                    count--;
                    return this;
                }
                else
                    current = current.Next;
            }
            return this;
        }

        public MyList<T> DeleteByName(string name)
        {
            if (this == null) throw new Exception("Список не инициализирован");
            if (count == 0) throw new Exception("Список не инициализирован");

            if(count == 1)
            {
                //count--;
                if(beg.Data is Emoji emoji )
                {
                    if (emoji.Name == name)
                        return this.Delete(beg);
                    else
                        return this;
                }
                else throw new Exception("Тип не приводится к объекту библиотеки");
            }
           // else throw new Exception("Тип не приводится к объекту библиотеки");


            if (beg.Data is Emoji)
            {
                count--;
                Node<T>? current = beg;

                while (current != null)
                {
                    if (current.Data is Emoji e)
                    {
                        if (e.Name == name)
                        {
                            current = current.Next;
                            this.Delete(current.Prev);
                        }
                        else
                        {
                            current = current.Next;
                        }
                    }
                    else
                        throw new Exception("Тип не приводится к объекту библиотеки");
                }
                return this;
            }
            else throw new Exception("Тип не приводится к объекту библиотеки");
        }

        public MyList<T> AddRandomItemsToBegin(int number)
        {
            if (number >= 0)
            {
                for (int i = 0; i < number; i++)
                {
                    T newItem = new T();
                    newItem.RandomInit();

                    this.AddToBegin(newItem);
                }
                return this;
            }
            else throw new Exception("Добавление отрицательного количества элементов");
        }

        public static void CreateEmptyMyList()
        {
            MyList<T> newList = new MyList<T>();
        }

        public static void InitMyList(int number)
        {
            MyList<T> myList = new MyList<T>(number);
        }
    }
}

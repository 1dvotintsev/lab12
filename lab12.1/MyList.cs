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

    internal class MyList<T> where T : IInit, ICloneable, new()
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

        public Node<T> MakeRandomData()
        {
            T data = new T();
            data.RandomInit();
            return new Node<T>(data);
        }

        public T MakeRandomItem()
        {
            T data = new T();
            data.RandomInit();
            return data;
        }

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
                end.Prev = newItem;
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
        }

        public MyList(int size)
        {
            if (size <= 0) throw new Exception("Невозможный размер");
            beg = MakeRandomData();
            end = beg;
            for(int i = 1; i < size; i++) 
            {
                T newItem = MakeRandomItem();
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

            for(int i = 1;i < collection.Length;i++)
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

            for (int i = 0; current != null; i++)
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
                T cloneData = (T)current.Data.Clone();

                clone.AddToEnd(cloneData);

                current = current.Next;
            }

            return clone;
        }

        public MyList<T>? Delete(Node<T> target)
        {
            if (this == null) throw new Exception("Список не инициализирован");
            if (count == 0) throw new Exception("Список не инициализирован");

            if(beg == target && end == target)
            {
                count--;
                return null;
            }
            else if (beg == target)
            {
                beg = beg.Next;
                beg.Prev = null;
                count--;
                return this;
            }
            else if(end == target)
            {
                end = end.Prev;
                end.Next = null;
                count--;
                return this;
            }

            Node<T>? current = beg.Next;
            while(current != end)
            {
                if(current == target)
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
                if(beg.Data is Emoji emoji )
                {
                    if (emoji.Name == name)
                        this.Delete(beg);
                    else
                        return this;
                }
            }
            else throw new Exception("Тип не приводится к объекту библиотеки");


            if (beg.Data is Emoji)
            {
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

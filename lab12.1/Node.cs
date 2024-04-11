using CustomLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab12._1
{
    internal class Node<T> where T: IInit, new() 
    {
        public T? Data { get; set; }

        public Node<T>? Prev { get; set; }
        public Node<T>? Next {  get; set; }

        public Node()
        {
            this.Data = default(T);
            this.Prev = null;
            this.Next = null;
        }

        public Node(T data)
        {
            this.Data = data;
            this.Prev = null;
            this.Next = null;
        }

        public static Node<T> MakeRandomData()
        {
            T data = new T();
            data.RandomInit();
            return new Node<T>(data);
        }

        public static T MakeRandomItem()
        {
            T data = new T();
            data.RandomInit();
            return data;
        }

        public override string? ToString()
        {
            if (Data == null)
                return "Нет данных";
            else
                return Data.ToString();
        }

        public override int GetHashCode()
        {
            return Data==null?0:Data.GetHashCode();
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Node<T> otherNode = (Node<T>)obj;

            return otherNode.Prev == this.Prev && otherNode.Next == this.Next && otherNode.Data.Equals(this.Data);
        }

    }
}

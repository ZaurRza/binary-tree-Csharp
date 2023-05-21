using System;
using System.Collections.Generic;
namespace proj
{
    class Tree<T>
    where T : IComparable, IComparable<T>
    {
        public Node<T> Root { get; private set; }
        public int Count { get; private set; }
        public void Add(T data)
        {
            if (Root == null)
            {
                Root = new Node<T>(data);
                Count = 1;
                return;
            }
            Root.Add(data);
            Count++;

        }
        public List<T> Preorder()
        {

            if (Root == null)
            {
                return new List<T>();
            }
            return Preorder(Root);
        }
        private List<T> Preorder(Node<T> node)
        {
            var list = new List<T>();
            if (node != null)
            {
                list.Add(node.Data);
                if (node.Left != null)
                {
                    list.AddRange(Preorder(node.Left));

                }
                if (node.Right != null)
                {
                    list.AddRange(Preorder(node.Right));
                }
            }
            return list;
        }


    }
    class Node<T> : IComparable<T>, IComparable
    where T : IComparable, IComparable<T>
    {
        public T Data { get; set; }
        public Node<T> Left { get; private set; }
        public Node<T> Right { get; private set; }
        public Node(T data)
        {
            Data = data;
        }
        public Node(T data, Node<T> left, Node<T> right)
        {
            Data = data;
            Left = left;
            Right = right;
        }
        public void Add(T data)
        {
            var node = new Node<T>(data);

            if (node.Data.CompareTo(Data) == -1)
            {

                if (Left == null)
                {

                    Left = node;
                }
                else
                {
                    Left.Add(data);
                }

            }
            else
            {
                if (Right == null)
                {
                    Right = node;
                }
                else
                {
                    Right.Add(data);
                }
            }
        }
        public int CompareTo(object obj)
        {
            if (obj is Node<T> item)
            {
                return Data.CompareTo(item);
            }
            else
            {
                throw new Exception("Ne odin tip");
            }
        }
        public int CompareTo(T other)
        {
            return Data.CompareTo(other);
        }
        public override string ToString()
        {
            return Data.ToString();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var tree = new Tree<int>();
            tree.Add(30);
            tree.Add(20);
            tree.Add(25);
            tree.Add(33);
            tree.Add(18);
            tree.Add(23);

            Console.ReadLine();
        }
    }
}


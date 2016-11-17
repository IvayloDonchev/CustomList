using System;
using System.Collections;

namespace GenericList

{
    [Serializable]
    public class GenList<T> : ICloneable
    {
        class Node
        {
            public T key;
            public Node next;
            public Node()
            {
                key = default(T);
                next = null;
            }
            public Node(T x)
            {
                key = x;
                next = null;
            }
            public static bool operator true(Node node) => node != null;
            public static bool operator false(Node node) => node == null;

        }
        private Node first;
        private Node last;
        public GenList()
        {
            first = null;
            last = new Node();
        }
        public void PushFront(T x)
        {
            Node p = new Node(x);
            p.next = first;
            first = p;
        }
        public void PushBack(T x) // добавяне в края
        {
            Node p = new Node(x);
            if (first == null)
            {
                first = p;
                first.next = last;
            }
            else
            {
                last.key = x;
                last.next = p;
                last = p;
            }
        }
        public void Disp()
        {
            for (Node p = first; p != last; p = p.next)
                Console.Write($"{p.key} ");
            Console.WriteLine();
        }
        public IEnumerator GetEnumerator()
        {
            for (Node p = first; p != last; p = p.next)
                yield return p.key;
        }

        public object Clone()   //Дълбоко копиране (имплементиране на интерфейса ICloneable)
        {
            GenList<T> newList = new GenList<T>();
            for (Node p = first; p != last; p = p.next)
            {
                newList.PushBack(p.key);
            }
            return newList;
        }
        public T this[int k]
        {
            get
            {
                Node p = first;
                for (int i = 0; p != last && i < k; p = p.next, ++i) ;
                if (p != last) return p.key;
                else throw new IndexOutOfRangeException();
            }
            set
            {
                Node p = first;
                for (int i = 0; i < k && p != last; ++i, p = p.next) ;
                if (p != last)
                    p.key = value;
                else
                    throw new IndexOutOfRangeException();
            }
        }
        public static implicit operator ArrayList(GenList<T> l)
        {
            ArrayList resultList = new ArrayList();
            foreach (int x in l)
                resultList.Add(x);
            return resultList;
        }
            
    }
}

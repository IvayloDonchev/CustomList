using System;
using System.Collections;
using GenericList;

namespace CustomList
{
    class Program
    {
        static void Main(string[] args)
        {
            GenList<int> l = new GenList<int>();
            l.Add(1);
            l.Add(2);
            l.Add(3);
            l.Add(4);
            l.Disp();

            GenList<int> l2 = (GenList<int>) l.Clone();

            foreach (int x in l)
                Console.Write($"{x} ");
            Console.WriteLine();
            Console.WriteLine(l[2]);
            l[2] = 10;
            l.Disp();
            l2.Disp();
            ArrayList arrL = l; // implicit conversion
            foreach (var x in arrL)
                Console.Write($"{x} ");
            Console.WriteLine();

            

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.SetOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<int> f1 = new HashSet<int>();
            int num = 1;
            f1.Add(num);

            for (int i = 0; i < 50; i++)
            {
                num = 2 * num + 3;
                f1.Add(num);
            }

            HashSet<int> f2 = new HashSet<int>();
            num = 2;
            f2.Add(num);

            for (int i = 0; i < 50; i++)
            {
                num = 3 * num + 1;
                f2.Add(num);
            }

            HashSet<int> f3 = new HashSet<int>();
            num = 2;
            f3.Add(num);

            for (int i = 0; i < 50; i++)
            {
                num = 2 * num - 1;
                f3.Add(num);
            }

            // * - intersection, + - union
            HashSet<int> intersectF1F2 = new HashSet<int>(f1);
            intersectF1F2.IntersectWith(f2);
            Console.WriteLine("f1 * f2: ");
            Console.WriteLine(String.Join(',', intersectF1F2.Where(x => x >= 0 && x <= 100000)));

            HashSet<int> intersectF1F3 = new HashSet<int>(f1);
            intersectF1F3.IntersectWith(f3);
            Console.WriteLine("f1 * f3: ");
            Console.WriteLine(String.Join(',', intersectF1F3.Where(x => x >= 0 && x <= 100000)));

            HashSet<int> intersectF2F3 = new HashSet<int>(f2);
            intersectF2F3.IntersectWith(f3);
            Console.WriteLine("f2 * f3: ");
            Console.WriteLine(String.Join(',', intersectF2F3.Where(x => x >= 0 && x <= 100000)));

            HashSet<int> intersectF1F2F3 = new HashSet<int>(intersectF1F2);
            intersectF1F2F3.IntersectWith(f3);
            Console.WriteLine("f1 * f2 * f3: ");
            Console.WriteLine(String.Join(',', intersectF1F2F3.Where(x => x >= 0 && x <= 100000)));

            SortedSet<int> unionF1F2 = new SortedSet<int>(f1);
            unionF1F2.UnionWith(f2);
            Console.WriteLine("f1 + f2: ");
            Console.WriteLine(String.Join(',', unionF1F2.Where(x => x >= 0 && x <= 100000)));

            SortedSet<int> unionF1F3 = new SortedSet<int>(f1);
            unionF1F3.UnionWith(f3);
            Console.WriteLine("f1 + f3: ");
            Console.WriteLine(String.Join(',', unionF1F3.Where(x => x >= 0 && x <= 100000)));

            SortedSet<int> unionF2F3 = new SortedSet<int>(f2);
            unionF2F3.UnionWith(f3);
            Console.WriteLine("f2 + f3: ");
            Console.WriteLine(String.Join(',', unionF2F3.Where(x => x >= 0 && x <= 100000)));

            SortedSet<int> unionF1F2F3 = new SortedSet<int>(unionF1F2);
            unionF1F2F3.UnionWith(f3);
            Console.WriteLine("f1 + f2 + f3: ");
            Console.WriteLine(String.Join(',', unionF1F2F3.Where(x => x >= 0 && x <= 100000)));
        }
    }
}

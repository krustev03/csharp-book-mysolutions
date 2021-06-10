using System;
using System.Collections.Generic;

namespace _04.ConvexHull
{
    class Point : IComparable<Point>
    {
        private int x, y;

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }

        public int CompareTo(Point other)
        {
            return x.CompareTo(other.x);
        }

        public override string ToString()
        {
            return string.Format("({0}, {1})", x, y);
        }
    }

    class Program
    {
        private static List<Point> ConvexHull(List<Point> p)
        {
            if (p.Count == 0) return new List<Point>();
            p.Sort();
            List<Point> h = new List<Point>();

            // lower hull
            foreach (var pt in p)
            {
                while (h.Count >= 2 && !Ccw(h[h.Count - 2], h[h.Count - 1], pt))
                {
                    h.RemoveAt(h.Count - 1);
                }
                h.Add(pt);
            }

            // upper hull
            int t = h.Count + 1;
            for (int i = p.Count - 1; i >= 0; i--)
            {
                Point pt = p[i];
                while (h.Count >= t && !Ccw(h[h.Count - 2], h[h.Count - 1], pt))
                {
                    h.RemoveAt(h.Count - 1);
                }
                h.Add(pt);
            }

            h.RemoveAt(h.Count - 1);
            return h;
        }

        private static bool Ccw(Point a, Point b, Point c)
        {
            return ((b.X - a.X) * (c.Y - a.Y)) > ((b.Y - a.Y) * (c.X - a.X));
        }

        static void Main(string[] args)
        {
            List<Point> points = new List<Point>() {
                new Point(10, 10),
                new Point(20, 20),
                new Point(50, 20),
                new Point(80, 20),
                new Point(100, 30),

                new Point(20, 70),
                new Point(30, 70),
                new Point(30, 60),
                new Point(40, 40),
                new Point(60, 50),

                new Point(70, 80),
                new Point(90, 60),
                new Point(110, 70)
            };

            List<Point> hull = ConvexHull(points);
            Console.Write("Convex Hull: [");
            for (int i = 0; i < hull.Count; i++)
            {
                if (i > 0)
                {
                    Console.Write(", ");
                }
                Point pt = hull[i];
                Console.Write(pt);
            }
            Console.WriteLine("]");
        }
    }
}

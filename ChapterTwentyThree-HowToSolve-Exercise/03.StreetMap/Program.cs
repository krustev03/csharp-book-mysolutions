using System;

namespace _03.StreetMap
{
    class Program
    {
        public class Edge
        {
            private string crOne;
            private string crTwo;
            private int length;

            public Edge(string crOne, string crTwo, int l)
            {
                this.crOne = crOne;
                this.crTwo = crTwo;
                this.length = l;
            }

            public string CrOne
            {
                get => this.crOne;
                set => this.crOne = value;
            }

            public string CrTwo
            {
                get => this.crTwo;
                set => this.crTwo = value;
            }

            public int Length
            {
                get => this.length;
                set => this.length = value;
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}

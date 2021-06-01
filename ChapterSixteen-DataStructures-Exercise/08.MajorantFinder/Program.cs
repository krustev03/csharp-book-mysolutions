using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.MajorantFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>();
            Dictionary<string, int> dic = new Dictionary<string, int>();

            string input = Console.ReadLine();
            while (input.Trim() != "")
            {
                var inputAsInt = Convert.ToInt32(input);

                list.Add(inputAsInt);

                if (!dic.ContainsKey(input))
                {
                    dic.Add(input, 1);
                }
                else
                {
                    dic[input]++;
                }

                input = Console.ReadLine();
            }

            var majorant = dic.Where(x => x.Value >= (list.Count / 2 + 1)).FirstOrDefault().Key;

            if (majorant == null)
            {
                Console.WriteLine("The majorant does not exist!");
            }
            else
            {
                Console.WriteLine(majorant);
            }
        }
    }
}

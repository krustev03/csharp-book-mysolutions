using System;
using System.Collections.Generic;

namespace _04.BusStation
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string[]> schedule = new HashSet<string[]>();
            schedule.Add(new string[] { "08:24", "08:33" });
            schedule.Add(new string[] { "08:20", "09:00" });
            schedule.Add(new string[] { "08:32", "08:37" });
            schedule.Add(new string[] { "09:00", "09:15" });

            var result = GetValidBuses(schedule, "08:22", "09:05");

            Console.WriteLine(result);
        }

        static int GetValidBuses(HashSet<string[]> schedule, string startTime, string endTime)
        {
            var startTimeAsTime = Convert.ToDateTime(startTime);
            var endTimeAsTime = Convert.ToDateTime(endTime);

            int count = 0;

            foreach (var item in schedule)
            {
                if (startTimeAsTime <= Convert.ToDateTime(item[0]) && Convert.ToDateTime(item[1]) <= endTimeAsTime)
                {
                    count++;
                }
            }

            return count;
        }
    }
}

using System;
using System.Collections.Generic;

namespace kattis
{
    class  OddManOut {
        static void Main(string[] args)
        {
            var numTestCases = Int32.Parse(Console.ReadLine());
            
            for(int i = 1; i <= numTestCases; i++)
            {
                processCase(i);
            }
        }

        static void processCase(int caseNumber)
        {
            var numberOfGuests = Int32.Parse(Console.ReadLine());

            if(numberOfGuests % 2 == 0)
                return;

            findUniqueCode(Console.ReadLine().Split(" "), caseNumber);
        }

        static void findUniqueCode(String[] guestCodes, int caseNumber)
        {
            Dictionary<long, int> map = new Dictionary<long, int>();
            for (var i = 0; i< guestCodes.Length; i++)
            {                                
                long key = long.Parse(guestCodes[i]);

                if(map.ContainsKey(key))
                {
                    map[key]++;
                }
                else
                    map.Add(key, 1);
            }

            foreach(KeyValuePair<long, int> entry in map)
            {
                if(entry.Value == 1)
                    Console.WriteLine($"Case #{caseNumber}: {entry.Key}");
            }
        }
    }
}
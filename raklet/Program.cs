using System;
using System.Collections.Generic;
using System.Linq;

namespace raklet
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.IsNullOrEmpty())
            {
                Console.WriteLine("Please provide a parameter!");
                WaitForUser();
                return;
            }

            var parameter = args[0];

            if (string.IsNullOrEmpty(parameter))
            {
                Console.WriteLine("Paramater has not a valid value!");
            }

            var c = GetFirstNonRepeatingCharacterIfAny(parameter);

            if (!c.HasValue)
            {
                Console.WriteLine("Unable to find any non repeating character!");
                WaitForUser();
                return;
            }

            Console.WriteLine(c);

            WaitForUser();
        }

        private static void WaitForUser()
        {
            Console.WriteLine("Press a key to exit!");
            Console.ReadKey();
        }

        private static char? GetFirstNonRepeatingCharacterIfAny(string parameter)
        {
            var mappings = FindCharactersAndCount(parameter);
            var resultMaybe = mappings.Where(kvp => kvp.Value == 1).FirstOrDefault();
            return resultMaybe.Value == 1 ? resultMaybe.Key : default(char?);
        }

        private static Dictionary<char, int> FindCharactersAndCount(string parameter)
        {
            var result = new Dictionary<char, int>();
            foreach (var c in parameter)
            {
                if (result.ContainsKey(c))
                {
                    result[c] += result[c] + 1;
                }
                else
                {
                    result[c] = 1;
                }
            }

            return result;
        }
    }
}

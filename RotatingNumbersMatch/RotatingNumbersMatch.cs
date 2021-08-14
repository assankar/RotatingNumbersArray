using System;
using System.Collections.Generic;

namespace RotatingNumbersMatch
{
    class RotatingNumbersMatch
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            RotatingNumbersMatch rotatingNumbersMatch = new RotatingNumbersMatch();
            int[] test1 = { 4, 3, 2, 1 };
            int[] test2 = { 1, 3, 2, 4 };
            int[] test3 = { 3, 4, 1, 2 };

            Console.WriteLine(rotatingNumbersMatch.IsRotatingNumbersMatch(test1));
            Console.WriteLine(rotatingNumbersMatch.IsRotatingNumbersMatch(test2));
            Console.WriteLine(rotatingNumbersMatch.IsRotatingNumbersMatch(test3));
        }

        public RotatingNumbersMatch()
        {

        }

        public bool IsRotatingNumbersMatch(int [] input)
        {
            int[] identity = new int[input.Length];
            int[] reverseIdentity = new int[input.Length];
            Array.Copy(input, identity, input.Length);
            Array.Sort(identity);

            int reverseIdentityCounter = 0;
            for(int i = identity.Length-1; i >= 0; i--)
            {
                reverseIdentity[reverseIdentityCounter] = identity[i];
                reverseIdentityCounter++;
            }
            HashSet<int[]> set = new HashSet<int[]>();
            set.Add(identity);
            set.Add(reverseIdentity);

            for (int i = 0; i < input.Length; i++){
                int[] temp = new int[input.Length];
                int tempCounter = 0;
                for (int j = 1; j < input.Length; j++)
                {
                    temp[tempCounter] = input[j];
                    tempCounter++;
                }
                temp[tempCounter] = input[0];

                int isIdentityUniqueCounter = 0;
                int isReverseIdentityUniqueCounter = 0;
                for(int k = 0; k < temp.Length; k++)
                {
                    if (identity[k] == temp[k])
                    {
                        isIdentityUniqueCounter++;
                    }
                    if (reverseIdentity[k] == temp[k])
                    {
                        isReverseIdentityUniqueCounter++;
                    }
                }
                if (isIdentityUniqueCounter == input.Length  || isReverseIdentityUniqueCounter == input.Length)
                {
                    return true;
                }

                input = temp;
            }

            return false;
        }
    }
}

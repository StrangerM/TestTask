using System;
using System.Collections.Generic;
using System.Linq;

namespace TestTask
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<int> result = new List<int>();

            result = CheckNumSum(-170, 170, 8);

            if(result.Count() == 0) 
            {
                Console.WriteLine("There is no acceptable number according to the conditions of the task ");
            }
            else 
            {
               foreach(var item in result) 
               {
                 Console.WriteLine("There is acceptable number according to the conditions of the task- {0}", item);
               }
            }
            Console.ReadLine();
        }

        public static IEnumerable<int> CheckNumSum(int min, int max, int sum) 
        {
            List<int> result = new List<int>();

            for (int x = min; x <= max; x++ )
            {
                var temp = x.ToString().Select(x => x).ToList();

                if (x < 0)
                {
                    
                    temp.RemoveAt(0);
                    var intList = temp.Select(digit => int.Parse(digit.ToString())).ToList();
                    intList[0] *= -1;
                    var resultOfSum = intList.Sum(x => x);
                    if (resultOfSum == sum)
                    {
                        result.Add(x);
                    }
                }
                else
                {
                    var intList = temp.Select(digit => int.Parse(digit.ToString()));
                    var resultOfSum = intList.Sum(x => x);
                    if (resultOfSum == sum)
                    {
                        result.Add(x);
                    }
                }

            }
            return result;
        }
    }
}

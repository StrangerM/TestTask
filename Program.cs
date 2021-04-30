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
            while (true)
            {
                Console.WriteLine("Please input min value");
                var firstNumber = Console.ReadLine();
                int min, max, sum;
                if (!Validator.ConvertTo(firstNumber, out min))
                {
                    Console.WriteLine("Please input number in correct format and press enter");
                    continue;
                }
                Console.WriteLine("Please input max value and press enter");
                var secondNumber = Console.ReadLine();
                if (!Validator.ConvertTo(secondNumber, out max) || max < min)
                {
                    Console.WriteLine("Please input number in correct format or max has to be bigger than min");
                    continue;
                }
                Console.WriteLine("Please input sum value and press enter");
                var sumValuer = Console.ReadLine();
                if (!Validator.ConvertTo(sumValuer, out sum))
                {
                    Console.WriteLine("Please input number in correct format");
                    continue;
                }

                // result = CheckNumSum(min,max,sum);
                result = CheckNumSumWithoutUsingString(min, max, sum);
                if (result.Count() == 0)
                    Console.WriteLine("There is no acceptable number according to the conditions of the task ");
                else
                {
                    foreach (var item in result)
                        Console.WriteLine("There is acceptable number according to the conditions of the task- {0}", item);
                }
               
                Console.WriteLine( "To continue again press any button" );
                Console.ReadKey();
            }
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
                          result.Add(x);
                }
                else
                {
                    var intList = temp.Select(digit => int.Parse(digit.ToString())).Sum(x=>x);    
                    if (intList == sum)
                          result.Add(x);
                }
            }
            return result;
        }
        public static IEnumerable<int> SplitNumber(int someNumber)
        {
            bool minus = false;
            List<int> listOfInts = new List<int>();
            if (someNumber < 0)
            {
                someNumber *= -1;
                minus = true;
            }
            while (someNumber > 0)
            {    
                listOfInts.Add(someNumber % 10);
                someNumber /= 10;
            }
            listOfInts.Reverse();
            if (minus)
                 listOfInts[0] *= -1;

            return listOfInts;

        }
        public static IEnumerable<int> CheckNumSumWithoutUsingString(int min, int max, int sum)
        {
            List<int> result = new List<int>();

            for (int x = min; x <= max; x++)
            {
                var listInteger = SplitNumber(x);
                var sumOfInt = listInteger.Sum(x => x);
                if (sumOfInt == sum)
                    result.Add(x);
            }
            return result;

        }
    }
}

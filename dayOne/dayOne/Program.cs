using System;
using System.Collections.Generic;

namespace dayOne
{
    class Program
    {
        public static string firstGoAround(int[] numberList)
        {
            string resultString = "";

            int numberOne = 0;
            int numberTwo = 0;
            var theResult = 0;

            for (int i = 0; i < numberList.Length; i++)
            {
                for (int j = 0; j < numberList.Length; j++)
                {
                    if (numberList[i] + numberList[j] == 2020)
                    {
                        numberOne = numberList[i];
                        numberTwo = numberList[j];
                        theResult = numberOne * numberTwo;
                        break;
                    }
                }
            }

            resultString = String.Format("{0} is the result of {1} * {2}", theResult, numberOne, numberTwo);

            return resultString;
        }


        public static string slightlyBetterKo(int[] numberList)
        {
            string resultString = "";
            int numberOne = 0;
            int numberTwo = 0;
            int result = 0;

            foreach(var expense in numberList)
            {

                var lookForNumber = 2020 - expense;
                var something = Array.FindIndex(numberList, i => i == lookForNumber);

                if(something != -1)
                {
                    numberOne = expense;
                    numberTwo = lookForNumber;
                    result = numberOne * numberTwo;
                    break;
                }

            }

            resultString = String.Format("{0} is the result, numbers are {1} * {2}", result, numberOne, numberTwo);

            return resultString;
        }

        public static string PartTwo(int[] numberList)
        {
            string resultString = "";
            int numberOne = 0;
            int numberTwo = 0;
            int numberThree = 0;
            int result = 0;

            for(int i = 0; i < numberList.Length - 2; i++)
            {
                for(int j = i + 1; j < numberList.Length - 1; j++)
                {
                    for(int k = j + 1; k < numberList.Length; k++)
                    {
                        if(numberList[i] + numberList[j] + numberList[k] == 2020)
                        {
                            numberOne = numberList[i];
                            numberTwo = numberList[j];
                            numberThree = numberList[k];
                            result = numberOne * numberTwo * numberThree;

                            resultString = String.Format("Product = {0}.\n{1} * {2} * {3}", result, numberOne, numberTwo, numberThree);

                            return resultString;
                        }
                    }
                }
            }

            return resultString;
        }

        public static void Main(string[] args)
        {

            var testList = new int[] {
                1721,
                979,
                366,
                299,
                675,
                1456 };
            
            var realDeal = System.IO.File.ReadAllLines(@"C:\Projects\AdventOfCode\dayOne\expenses.txt");
            var expenses = Array.ConvertAll(realDeal, s => int.Parse(s));

            #region Part 1
            var timer1 = System.Diagnostics.Stopwatch.StartNew();
            var firstTry = firstGoAround(expenses);
            timer1.Stop();

            var timer2 = System.Diagnostics.Stopwatch.StartNew();
            var aBetterTry = slightlyBetterKo(expenses);
            timer2.Stop();


            Console.WriteLine(String.Format("first method time = {0}", timer1.Elapsed));
            Console.WriteLine(String.Format("second method time = {0}", timer2.Elapsed));

            Console.WriteLine(String.Format("result 1 = {0}, \nresult 2 = {1}", firstTry, aBetterTry));
            #endregion

            #region Part 2
            var part2Result = PartTwo(expenses);
            Console.WriteLine("part 2 results:");
            Console.WriteLine(part2Result);
            #endregion
        }
    }
}

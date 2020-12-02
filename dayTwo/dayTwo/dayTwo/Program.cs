using System;
using System.Text.RegularExpressions;

namespace dayTwo
{
    public class Program
    {
        public static int PartOneValidCount(string[] passwords)
        {
            int validPasswords = 0;

            foreach(var password in passwords)
            {
                var splitPassword = password.Split(':');
                var canidate = splitPassword[1].Trim();

                var requirements = splitPassword[0].Split(' ');
                var requirementLetter = requirements[1].Trim();
                var numbers = requirements[0].Split('-');

                var canidateLetter = Regex.Replace(canidate, @"([^" + requirementLetter + "])", "");
                var lettercount = canidateLetter.Length;

                if(lettercount >= Convert.ToInt32(numbers[0]) && lettercount <= Convert.ToInt32(numbers[1]))
                {
                    validPasswords++;
                }

                //split string on :
                //get the letter _:
                //get the valid count _-_

                //go through the password and look for character and count how many times it is.
                    //strip away everything but the letter and check the length
            }


            return validPasswords;
        }

        public static int PartTwoValidCount(string[] passwords)
        {
            int valid = 0;

            foreach(var password in passwords)
            {
                var splitPassword = password.Split(':');
                var canidate = splitPassword[1].Trim();

                var requirements = splitPassword[0].Split(' ');
                var requirementLetter = requirements[1].Trim();
                var numbers = requirements[0].Split('-');

                

                var firstPosition = Convert.ToInt32(numbers[0]) - 1;
                var secondPosition = Convert.ToInt32(numbers[1]) - 1;

                var firstLetter = canidate[firstPosition].ToString();
                var secondLetter = canidate[secondPosition].ToString();
                
                if(firstLetter == requirementLetter)
                {
                    if(secondLetter != requirementLetter)
                    {
                        valid++;
                    }
                }
                else if(secondLetter == requirementLetter)
                {
                    if(firstLetter != requirementLetter)
                    {
                        valid++;
                    }
                }
            }

            return valid;
        }

        public static void Main(string[] args)
        {
            var passwordTest = System.IO.File.ReadAllLines(@"C:\Projects\AdventOfCode\dayTwo\passwordTest.txt");
            var passwords = System.IO.File.ReadAllLines(@"C:\Projects\AdventOfCode\dayTwo\passwords.txt");

            var partOneCount = PartOneValidCount(passwords);
            Console.WriteLine(String.Format("part one valid: {0}", partOneCount));

            var partTwoCount = PartTwoValidCount(passwords);
            Console.WriteLine(String.Format("part two valid: {0}", partTwoCount));
        }
    }
}

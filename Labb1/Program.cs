using System.Security.Cryptography.X509Certificates;
using System.Numerics;
using System;

namespace Labb1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = args[0];
            RunProgram(input);
        }
        //Method used to find secret numbers in an input
        static string[] FindSecretNumbers(string input)
        {
            List<string> secretNumbersList = new List<string>();
            
            for (int i = 0; i < input.Length; i++)
            {
                char startChar = input[i];
                int startNumber;
                bool startCharIsNumber = int.TryParse(startChar.ToString(), out startNumber);
                //Console.WriteLine("new i iteration = " + i);
                if (!startCharIsNumber)
                {
                    continue;
                }
                for (int j = i + 1; j < input.Length; j++)
                {
                    char currentChar = input[j];
                    int currentNumber;
                    bool isNumber = int.TryParse(currentChar.ToString(), out currentNumber);
                    Console.WriteLine("i = " + i);
                    Console.WriteLine("j = " + j);
                    Console.WriteLine("Starnumber = " + startNumber);
                    Console.WriteLine("currentchar = " + currentChar);
                    Console.WriteLine("currentnumber = " + currentNumber);
                    if (!isNumber)
                    {
                        break;
                    }
                    if(startNumber == currentNumber)
                    {
                        int secretNumberLength = j - i + 1;
                        string secretString = input.Substring(i, secretNumberLength);
                        secretNumbersList.Add(secretString);
                        Console.WriteLine("i = " + i);
                        Console.WriteLine("j = " + j);
                        Console.WriteLine("Starnumber = " + startNumber);
                        Console.WriteLine("currentchar = " + currentChar);
                        Console.WriteLine("currentnumber = " + currentNumber);
                        Console.WriteLine("Creates secretword = " + secretString);
                        break;
                    }
                }
            }
            foreach (string secretnumber in secretNumbersList)
            {
                Console.WriteLine(secretnumber);
            }
            return secretNumbersList.ToArray();
        }
        //Method to calculate the sum of all secret numbers.
        static long CalculateSecretNumbers(string[] secretNumbers)
        {
            long[] secretNumbersAsLong = new long[secretNumbers.Length];
            for(int i = 0; i < secretNumbers.Length; i++)
            {
                secretNumbersAsLong[i] = long.Parse(secretNumbers[i]);
            }
            long sum = secretNumbersAsLong.Sum();
            return sum;
        }
        // Method to print the whole input but with the secretnumbers in a different color.
        static void PrintSecretNumbers(string input, string[] secretNumbers,long total)
        {
            if(input == null)
            {
                Console.WriteLine("input is null");
                return;
            }
            if(secretNumbers.Length == 0)
            {
                Console.WriteLine(input);
                Console.WriteLine($"No secret numbers.Therefor no sum.");
            }
            Console.WriteLine();
            Console.WriteLine($"INPUT : {input}\n");
            

            string beforeSecretNumber;
            int currentPosition = 0;
            

            foreach (string secretNumber in secretNumbers)
            {
                string leftOfInput = input.Substring(currentPosition);
                //Console.WriteLine("currentpos : " + currentPosition + " secretnum : " + secretNumber + " leftofinpput : " + leftOfInput);

                while (!leftOfInput.StartsWith(secretNumber))
                {
                    currentPosition++;
                    leftOfInput = input.Substring(currentPosition);
                }

                beforeSecretNumber = input.Substring(0, currentPosition);
                //Console.WriteLine("beforesecretnumber " + beforeSecretNumber);
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write(beforeSecretNumber);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(secretNumber);
                leftOfInput = input.Substring(currentPosition + secretNumber.Length);
                //Console.WriteLine("leftofinpput 2 " + leftOfInput); 
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write(leftOfInput);
                Console.WriteLine();
                currentPosition++;

            }
            Console.WriteLine($"\nThe sum of all Secret numbers is: {total}");

        }
        //Method to run the application
        static void RunProgram(string input)
        {
            Console.WriteLine("Welcome to the Secret number finder! Input whatever you like and I will try to find 'Secret Numbers' \n" +
                "A secret number is a number that starts with a digit and ends with the same digit, and has no characters inbetween.\nEx '3403'\n" +
                "All secret numbers found, will be highlighted in cyan.\n" +
                "I will also print the sum of all Secret numbers.\n" +
                "Please enter your input here:");
            //"4335435gh023047";//"29535123p48723487597645723645";

            string[] secretNumbers = FindSecretNumbers(input);
            long sum = CalculateSecretNumbers(secretNumbers);
            PrintSecretNumbers(input, secretNumbers, sum);
            
            
        }
    }
}
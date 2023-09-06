using System.Security.Cryptography.X509Certificates;
using System.Numerics;
using System;

namespace Labb1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RunProgram();

            Console.ReadKey();
        }
        //Method used to find secret numbers in an input
        static long[] FindSecretNumbers(string input)
        {
            List<long> secretNumbers = new List<long>();
            
            for (int i = 0; i < input.Length; i++)
            {
                char startChar = input[i];
                int startNumber;
                bool startCharIsNumber = int.TryParse(startChar.ToString(), out startNumber);
                Console.WriteLine("i = " + i);
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
                        secretNumbers.Add(long.Parse(secretString));
                        Console.WriteLine("i = " + i);
                        Console.WriteLine("j = " + j);
                        Console.WriteLine("Starnumber = " + startNumber);
                        Console.WriteLine("currentchar = " + currentChar);
                        Console.WriteLine("currentnumber = " + currentNumber);
                        break;
                    }
                }
            }
            foreach(long secretnumber in secretNumbers)
            {
                Console.WriteLine(secretnumber);
            }
            return secretNumbers.ToArray();
        }
        //Method to calculate the sum of all secret numbers.
        static long CalculateSecretNumbers(long[] secretNumbers)
        {
            long sum = secretNumbers.Sum();
            return sum;
        }
        // Method to print the whole input but with the secretnumbers in a different color.
        static void PrintSecretNumbers(string input, long[] secretNumbers)
        {
            string[] secretNumbersAsString = new string[secretNumbers.Length];

            for(int i = 0; i < secretNumbers.Length; i++)
            {
                secretNumbersAsString[i] = secretNumbers[i].ToString();
            }

            foreach (string secretNumber in secretNumbersAsString)
            {
                int currentPosition = 0;

                while (currentPosition < input.Length)
                {
                    bool foundSecretNumber = false;
                        
                    if (currentPosition + secretNumber.Length <= input.Length && input.Substring(currentPosition).StartsWith(secretNumber))
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write(secretNumber);
                        currentPosition += secretNumber.Length;
                        foundSecretNumber = true;
                    }
                        
                    if (!foundSecretNumber)
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write(input[currentPosition]);
                        currentPosition++;
                    }
                    
                }
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine();
            }
        }
        //Method to run the application
        static void RunProgram()
        {
            string input = "4335435023047";//"29535123p48723487597645723645";
            long[] secretNumbers = FindSecretNumbers(input);
            long sum = CalculateSecretNumbers(secretNumbers);
            PrintSecretNumbers(input, secretNumbers);
            Console.WriteLine();
            if(sum > 0)
            {
                Console.WriteLine("The sum of all Secretnumbers are: " + sum);
            }else
            {
                Console.WriteLine("We couldn't find any secret number :(");
            }
            
        }
    }
}
using System;
using static System.Console;
using System.Linq;

namespace PreWork1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Prompt user to input integer
            Write("Please enter a positive integer value (x > 0): ");
            string inputOne = ReadLine();

            // Validate entry to ensure an integer was entered
            while(ValidateEntry(inputOne) == 0)
            {
                Write("Invalid Entry: The value entered was not a positive integer\r\nPlease enter a positive integer value (x > 0): ");
                inputOne = ReadLine();
                ValidateEntry(inputOne);
            }
            int numberOne = ValidateEntry(inputOne);
            int lengthOne = numberOne.ToString().Count();
            
            // Prompt user to input second integer
            Write("Please enter another positive integer value (x > 0) with the same number of digits ({0}) as the first: ", lengthOne);
            string inputTwo = ReadLine();
           
            // Validate second entry to ensure integer was entered
            while(ValidateEntry(inputTwo) == 0)
            {
                Write("Invalid Entry: The value entered was not a positive integer\r\nPlease enter another positive integer value (x > 0) with the same number of digits ({0}) as the first: ", lengthOne);
                inputTwo = ReadLine();
                ValidateEntry(inputTwo);
            }
            int numberTwo = ValidateEntry(inputTwo);
            int lengthTwo = numberTwo.ToString().Count();

            // Ensure integers have the same number of digits
            while(lengthTwo != lengthOne)
            {
                Write("Invalid Entry: The integer entered did not contain the same number of digits as the first\r\nPlease enter another positive integer value (x > 0) with the same number of digits ({0}) as the first: ", lengthOne);
                inputTwo = ReadLine();
                numberTwo = ValidateEntry(inputTwo);
                lengthTwo = numberTwo.ToString().Count();
            }

            // Seperate individual digits of each integer into respective arrays
            int[] arrayOne = SeperateDigits(numberOne);
            int[] arrayTwo = SeperateDigits(numberTwo);

            // Do the computation, return true or false based on result, display results
            bool result = Compute(arrayOne, arrayTwo);
            WriteLine("Int 1 = {0}\r\nInt 2 = {1}\r\n{2}", numberOne, numberTwo, result);
            ReadLine();
        }

        // Method to parse user input, ensure integer is positive
        static int ValidateEntry(string input)
        {
            int.TryParse(input, out int number);
            if(number < 0)
            {
                return 0;
            }
            else
            {
                return number;
            }
        }
        
        // Method to convert each integer into array
        static int[] SeperateDigits(int number)
        {
            int[] digits = number.ToString().ToCharArray().Select(x => (int)Char.GetNumericValue(x)).ToArray();
            return digits;
        }

        // Method for the computation
        static bool Compute(int[] arrayOne, int[] arrayTwo)
        {
            int answer = arrayOne[0] + arrayTwo[0];

            for (int i = 1; i < arrayOne.Length; i++)
            {
                if(arrayOne[i] + arrayTwo[i] != answer)
                {
                    return false;
                }
            }

            return true;
        }
    }
}

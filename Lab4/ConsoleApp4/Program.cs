using System;

namespace ConsoleApp4
{
    class Program
    {
        public static void Main()
        {
            try
            {
                Console.WriteLine("Enter string:");
                string input = Console.ReadLine()!;
                input = input.Replace(" ", "");
                string output = PolishLook.ToPolishLook(input);
                Console.WriteLine("In Polish View: {0}", output);
                string[] inputArray = output.Split(' ');
                for (int i = 0; i < inputArray.Length; i++)
                {
                    inputArray[i] = inputArray[i].Trim();
                }
                string result = PolishLook.Calculate(inputArray);
                Console.WriteLine("Result: {0}", result);
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
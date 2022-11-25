using System.Linq;

namespace ConsoleApp4
{
    public class Symbol
    {
        public static bool IsLetter(char letter)
        {
            string letters = "abcdefghijklmnopqrstuvwxyz";
            return letters.Contains(letter);
        }

    public static bool IsOperator(string op)
    {
        string[] operators = { "+", "-", "*", "/", "|", "sqrt", "abs" };
        return operators.Contains(op);
    }

    public static bool IsNumber(string input)
    {
        string numbers = "0123456789";
        while (input.Length > 0)
        {
            if (!numbers.Contains(input[0]))
            {
                return false;
            }

            input = input.Substring(1);
        }

        return true;
    }

        public static bool IsDigit(char digit)
        {   
            string numbers = "0123456789";
            return numbers.Contains(digit);
        }
    }
}   
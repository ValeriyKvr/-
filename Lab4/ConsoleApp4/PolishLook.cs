using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp4
{
    public class PolishLook
    {
        public static string ToPolishLook(string input)
        {
            if (input == null)
            {
                return input;
            }

            string output = "";
            Stack<string> lexemas = new Stack<string>();
            string symbol = "";

            for (int i = 0; i < input.Length;)
            {
                symbol = GetSymbol(input, ref i);
                if (symbol == " ")
                {
                    continue;
                }
                if (symbol == "(")
                {
                    lexemas.Push(symbol);
                    continue;
                }
                if (symbol == ")")
                {
                    while (lexemas.Count > 0 && lexemas.Peek() != "(")
                    {
                        output += lexemas.Pop() + " ";
                    }
                    if (lexemas.Count > 0 && lexemas.Peek() != "(")
                    {
                        return "Invalid Expression";
                    }
                    else
                    {
                        lexemas.Pop();
                    }
                    continue;
                }

                if (Symbol.IsOperator(symbol))
                {
                    while (lexemas.Count > 0 && Operation.GetPriority(symbol) <= Operation.GetPriority(lexemas.Peek()))
                    {
                        output += lexemas.Pop() + " ";
                    }
                    lexemas.Push(symbol);
                    continue;
                }
                if (Symbol.IsNumber(symbol))
                {
                    output += symbol;
                }
                output += ' ';
            }
            while (lexemas.Count > 0)
            {
                output += lexemas.Pop();
                output += ' ';
            }
            output = output.Remove(output.Length - 1);
            return output;
        }

        private static string GetSymbol(string input, ref int i)
        {
            string symbol = "";
            if (Symbol.IsOperator(input[i].ToString()))
            {
                symbol += input[i];
                i++;
                return symbol;
            }
            if (input[i] == '(' || input[i] == ')')
            {
                symbol += input[i];
                i++;
                return symbol;
            }
            if (Symbol.IsDigit(input[i]))
            {
                while (i < input.Length && Symbol.IsDigit(input[i]))
                {
                    symbol += input[i];
                    i++;
                }
                return symbol;
            }
            if (Symbol.IsLetter(input[i]))
            {
                while (i < input.Length && Symbol.IsLetter(input[i]) && !(Symbol.IsOperator(symbol)))
                {
                    symbol += input[i];
                    i++;
                }
                return symbol;
            }
            return " ";

        }

        public static string Calculate(string[] input)
        {
            Stack<double> stack = new Stack<double>();

            foreach (string el in input)
            {
                if (!(double.TryParse(el, out double number)))
                {
                    if (Operation.IsOperator(el))
                    {
                        double operand2 = stack.Pop();
                        double operand1 = stack.Pop();
                        stack.Push(Operation.CalculateOperations(el, Convert.ToInt32(operand1), Convert.ToInt32(operand2)));
                    }
                    else
                    {
                        if (stack.Count == 0) 
                        {
                            throw new Exception("Stack is empty. ");
                        }
                        else 
                        {
                            double a = stack.Pop();
                            stack.Push(Operation.CountOperator(el, a));
                        }
                        
                    }
                }
                else
                {
                    stack.Push(number);
                }
            }
            return stack.Pop().ToString();
        }
    }
}
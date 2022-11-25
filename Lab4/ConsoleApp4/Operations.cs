namespace ConsoleApp4
{
    public class Operation
    {
        public static int GetPriority(string p0)
        {
            
            switch (p0) 
            {
                case "+": return 1;
                case "-": return 1;
                case "*": return 2;
                case "/": return 2;
                case "|": return 2;
                case "sqrt": return 3;
                case "abs": return 3;
            }
            return -1;
        }
        public static double CountOperator(string item, double a)
        {
            
            switch (item) 
            {
                case "sqrt": return Math.Sqrt(a);
                case "abs": return Math.Abs(a);
                default: throw new Exception("Такий оператор відсутній. ");
            }
        } 
        public static double CalculateOperations(string item, int a, int b)
        {
            switch (item) 
            {
                case "+": return a + b;
                case "-": return a - b;
                case "*": return a * b;
                case "/": return a / b;
                case "|": return a | b;
                default: return 0;
            }
        }
        public static bool IsOperator(string item)
        {
            string[] operators = { "+", "-", "*", "/", "|" };
            return operators.Contains(item);
        }
    }
}

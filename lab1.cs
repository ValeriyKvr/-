using System.Diagnostics;

class Program
{
    private static void Main()
    {
        Stopwatch sw1 = new Stopwatch();
        Stopwatch sw2 = new Stopwatch();

        Console.WriteLine("Enter the number (Fibonacci): ");
        int fibNum = Convert.ToInt32(Console.ReadLine());
        
        sw1.Start();
        double fibRec = FibRecursion(fibNum);
        sw1.Stop();
        
        sw2.Start();
        double fibBine = FibBine(fibNum);
        sw2.Stop();

        Console.WriteLine($"Function - Fibonacci Recursion. Number: {fibRec}  Time: {sw1.Elapsed}\n" +
                          $"Function - Fibonacci Bine.      Number: {fibBine} Time: {sw2.Elapsed}");*/
        
        Stopwatch sw3 = new Stopwatch();
        Stopwatch sw4 = new Stopwatch();
        
        Console.WriteLine("Enter the number (Prime): ");
        int primeNum = Convert.ToInt32(Console.ReadLine());
        
        sw3.Start();
        bool primeSqrt = IsPrimeSqrt(primeNum);
        sw3.Stop();
        
        sw4.Start();
        bool primeNoSqrt = IsPrimeNoSqrt(primeNum);
        sw4.Stop();
        
        Console.WriteLine($"Prime Sqrt.    Result: {primeSqrt} Time: {sw3.Elapsed}\n" +
                          $"Prime No Sqrt. Result: {primeNoSqrt} Time: {sw4.Elapsed}");
        
        Stopwatch sw5 = new Stopwatch();
        Stopwatch sw6 = new Stopwatch();
        
        Console.WriteLine("Enter the numbers (GCD): ");
        int firstNum = Convert.ToInt32(Console.ReadLine());
        int secNum = Convert.ToInt32(Console.ReadLine());
        
        sw5.Start();
        int enumFromMin = EnumFromMin(firstNum, secNum);
        sw5.Stop();
        
        sw6.Start();
        int algEuclid = EuclidAlgorithm(firstNum, secNum);
        sw6.Stop();
        
        Console.WriteLine($"Enum from minimal: {firstNum}, {secNum}.          GCD: {enumFromMin} Time: {sw5.Elapsed}\n" +
                          $"Euclid's Algorithm Numbers: {firstNum}, {secNum}. GCD: {algEuclid} Time: {sw6.Elapsed}");*/
    }
    //Fibonacci 
    private static double FibRecursion(int num)
    {
        if (num == 0 || num == 1) return num;
        return FibRecursion(num - 1) + FibRecursion(num - 2);
    }
    private static double FibBine(int num)
    {
        double sqrtFive = Math.Pow(5, 0.5);
        double leftNum = (1 + sqrtFive) / 2;
        double rightNum = (1 - sqrtFive) / 2;
        return Math.Round((Math.Pow(leftNum, num) - Math.Pow(rightNum, num)) / sqrtFive);
    }
    //Prime Number
    private static bool IsPrimeSqrt(int num)
    {
        double numSqrt = Math.Sqrt(num);
        for (int i = 2; i <= numSqrt; i++) {
            if (num % i == 0) return false;
        }
        return true;
    }

    private static bool IsPrimeNoSqrt(int num)
    {
        for (int i = 2; i < num; i++) {
            if (num % i == 0) return false;
        }
        return true;
    }
    //Greatest Common Divisor
    private static int EnumFromMin(int num1, int num2)
    {
        int gcd = 0;
        for (int i = Math.Min(num1, num2); i > 0; i--) {
            if (num1 % i == 0 && num2 % i == 0)
            {
                gcd =  i;
                break;
            }
        }
        return gcd;
    }
    private static int EuclidAlgorithm(int num1, int num2)
    {
        while (num1 != num2) {
            if (num1 > num2) num1 -= num2;
            else num2 -= num1;
        }
        return num1;
    }
}


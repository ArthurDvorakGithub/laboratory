using System;

namespace ConsoleApplication4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ответ = " + SqrtN(2, 5));
            Console.ReadKey();
        }

        static double SqrtN(double n, double A, double eps = 0.0000000000001)
        {
            var x0 = A / (n * 2); //начальное предположение

            var x1 = (1 / n) * ((n - 1) * x0 + A / Math.Pow(x0, (int)n - 1));

            while (Math.Abs(x1 - x0) > eps)
            {
                x0 = x1;
                x1 = (1 / n) * ((n - 1) * x0 + A / Math.Pow(x0, (int)n - 1));
            }

            return x1;
        }
    }
}
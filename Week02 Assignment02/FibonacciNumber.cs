using System;

class FibonacciNumber
{
    static void Main(string[] args)
    {
        // Loop through the first 10 numbers of the Fibonacci sequence and print them out
        for (int i = 1; i <= 10; i++)
        {
            int fibonacciNumber = Fibonacci(i);
            Console.WriteLine(fibonacciNumber);
        }
    }

    // Method to calculate the n-th number in the Fibonacci sequence using recursion
    static int Fibonacci(int n)
    {
        // Base case: if n is 1 or 2, return 1
        if (n == 1 || n == 2)
        {
            return 1;
        }
        // Recursive case: calculate the n-th number by adding the (n-1)th and (n-2)th numbers
        else
        {
            return Fibonacci(n - 1) + Fibonacci(n - 2);
        }
    }
}
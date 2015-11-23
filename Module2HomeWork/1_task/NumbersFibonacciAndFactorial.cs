namespace Module2HomeWork
{
    class NumbersFibonacciAndFactorial
    {
        internal static int Factorial(int n)
        {
            return (n == 0) ? 1 : n * Factorial(n - 1);
        }

        internal static int Fibonacci(int n)
        {
            return (n < 3) ? 1 : Fibonacci(n - 1) + Fibonacci(n - 2);
        }
    }
}

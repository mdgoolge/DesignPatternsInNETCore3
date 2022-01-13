using System;

namespace CHAPTER2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Func<int, int, int> div = (int a, int b) => a / b;
        }
    }
}

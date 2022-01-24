using System;

namespace Monostate
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
    public class ChiefExecutiveOfficer
    {
        private static string name;
        private static int age;
        public string Name
        {
            get => name;
            set => name = value;
        }
        public int Age
        {
            get => age;
            set => age = value;
        }
    }
}

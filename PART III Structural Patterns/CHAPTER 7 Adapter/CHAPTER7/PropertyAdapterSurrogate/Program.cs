using System;
using System.Collections.Generic;
using System.Linq;

namespace PropertyAdapterSurrogate
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            MyClass myClass = new MyClass();
            myClass.Capitals["1"] = "a";
            myClass.Capitals["2"] = "b";
            myClass.Capitals["3"] = "c";

            foreach (var item in myClass.CapitalsSerializable)
            {
                Console.WriteLine(item) ;
            }

            MyClass myClass1 = new MyClass();
            myClass1.CapitalsSerializable =new(string,string)[]{("11","aa"),("22", "bb") };
            foreach (var item in myClass1.CapitalsSerializable)
            {
                Console.WriteLine(item);
            }
        }


    }

    public class MyClass
    {
        public Dictionary<string, string> Capitals { get; set; } = new Dictionary<string, string>();
        public (string, string)[] CapitalsSerializable
        {
            get
            {
                return Capitals.Keys.Select(country =>
                (country, Capitals[country])).ToArray();
            }
            set
            {
                Capitals = value.ToDictionary(x => x.Item1, x => x.Item2);
            }
        }
    }
}

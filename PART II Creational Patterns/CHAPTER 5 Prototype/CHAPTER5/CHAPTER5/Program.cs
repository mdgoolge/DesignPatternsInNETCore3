using System;
using System.Collections.Generic;

namespace CHAPTER5
{
    class Program
    {
        static void Main(string[] args)
        {
            //To deep-copy a Dictionary<>, you can use its copy constructor
            var d = new Dictionary<string, int>
            {
                ["foo"] = 1,
                ["bar"] = 2
            };
            var d2 = new Dictionary<string, int>(d);
            d2["foo"] = 55;
            Console.WriteLine(d["foo"]); // prints 1
            Console.WriteLine(d2["foo"]);

            //Dictionary has no idea how to deep-copy reference types it contains
            var dd = new Dictionary<string, Address>
            {
                ["sherlock"] = new Address { HouseNumber = 221, StreetName = "Baker St" }
            };
            var dd2 = new Dictionary<string, Address>(dd);
            dd2["sherlock"].HouseNumber = 222;
            Console.WriteLine(dd["sherlock"].HouseNumber); // prints "222"
        }
    }
    public class Address
    {
        public string StreetName;
        public int HouseNumber;
        public Address()
        {

        }
        public Address(string streetName, int houseNumber)
        {
            StreetName = streetName;
            HouseNumber = houseNumber;
        }
    }
}

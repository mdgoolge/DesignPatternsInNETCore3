using System;

namespace DuplicationviaCopyConstruction
{
    class Program
    {
        static void Main(string[] args)
        {
            var john = new Person(
 "John Smith",
 new Address("London Road", 123));
            var jane = new Person(john); // copy constructor!
            jane.Name = "Jane Smith";
            jane.Address.HouseNumber = 321; // john is still at 123
        }
    }
    public class Person
    {
        public string Name { get; set; }
        public Address Address { get; set; }
        public Person(string name, Address address)
        {
            Name = name;
            Address = address;
        }
        public Person(Person other)
        {
            Name = other.Name;
            Address = new Address(other.Address); // uses a copy constructor here
        }
    }
    public class Address
    {
        public string StreetName;
        public int HouseNumber;


        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public Address(string streetName, int houseNumber)
        {
            StreetName = streetName;
            HouseNumber = houseNumber;
        }
        public Address(Address other)
        {
            StreetAddress = other.StreetAddress;
            City = other.City;
            Country = other.Country;
        }
       

    }
}

using System;

namespace CompositeBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            var pb = new PersonBuilder();
            Person person = pb
            .Lives
            .At("123 London Road")
            .In("London")
            .WithPostcode("SW12BC")
            .Works
            .At("Fabrikam")
            .AsA("Engineer")
            .Earning(123000);
            Console.WriteLine(person);
            // StreetAddress: 123 London Road, Postcode: SW12BC, City: London,
            // CompanyName: Fabrikam, Position: Engineer, AnnualIncome: 123000
        }
    }
}

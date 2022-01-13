using System;

namespace OpenClosedPrinciple
{
    class Program
    {
        static void Main(string[] args)
        {
            var apple = new Product("Apple", Color.Green, Size.Small);
            var tree = new Product("Tree", Color.Green, Size.Large);
            var house = new Product("House", Color.Blue, Size.Large);
            Product[] products = { apple, tree, house };
            var pf = new ProductFilter();
            Console.WriteLine("Green products:");
            foreach (var p in pf.FilterByColor(products, Color.Green))
                Console.WriteLine($" - {p.Name} is green");

            var bf = new BetterFilter();

            foreach (var p in bf.Filter(products,
new AndSpecification<Product>(
new ColorSpecification(Color.Green),
new SizeSpecification(Size.Large))))
            {
                Console.WriteLine($"{p.Name} is large and green");
            }

            var largeGreenSpec = new ColorSpecification(Color.Green)& new SizeSpecification(Size.Large);

            foreach (var p in bf.Filter(products, largeGreenSpec))
            {
                Console.WriteLine($"{p.Name} is large and green2");
            }

            var largeGreenSpec1 = Color.Green.And(Size.Large); 
            foreach (var p in bf.Filter(products, largeGreenSpec1))
            {
                Console.WriteLine($"{p.Name} is large and green3");
            }


        }
    }
}

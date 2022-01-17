using System;
using System.Threading.Tasks;

namespace AsynchronousFactoryMethod
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var foo = await Foo.CreateAsync();
        }
    }
    //var foo = new Foo();
    //await foo.InitAsync();
    //public class Foo
    //{ 
    //    private async Task InitAsync()
    //    {
    //        await Task.Delay(1000);
    //    }
    //}


    
    public class Foo
    {
        protected Foo() { /* init here */ }
        private async Task InitAsync()
        {
            await Task.Delay(1000);
        }
        public static async Task<Foo> CreateAsync()
        {
            var result = new Foo();
            await result.InitAsync();
            return result;
        }
    }
}

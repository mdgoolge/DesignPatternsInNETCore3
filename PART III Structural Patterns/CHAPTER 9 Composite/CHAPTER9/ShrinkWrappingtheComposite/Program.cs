using System;
using System.Collections;
using System.Collections.Generic;

namespace ShrinkWrappingtheComposite
{
    class Program
    {
        static void Main(string[] args)
        {
            var foo = new Foo();
            foreach (var x in foo)
            {
                // will yield only one value of x
                // where x == foo referentially :)
            }

            var foo1 = new Foo1();
            var scalar = foo as IScalar<Foo1>; // :(
            foreach (var f in scalar)
            {

            }
        }
    }
    public abstract class Scalar<T> : IEnumerable<T>
where T : Scalar<T>
    {
        public IEnumerator<T> GetEnumerator()
        {
            yield return (T)this;
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    public class Foo : Scalar<Foo> { }
    public interface IScalar<out T>
where T : IScalar<T>
    {
        public IEnumerator<T> GetEnumerator()
        {
            yield return (T)this;
        }
    }
    public class Foo1 : IScalar<Foo1> { }
}

using System;

namespace GenericValueAdapter
{
    class Program
    {
        static void Main(string[] args)
        {
            var v = new Vector<int, Dimensions.Two>();
            var v1 = new Vector2i();

        }
    }


    //Both the constructor initialization and the instantiation are impossible in C#.
    //public class Vector<T, D>
    //{
    //    protected T[] data; public Vector()
    //    {
    //        data = new T[D]; // impossible
    //    }
    //}
    //var v = new Vector<int, 2>(); // impossible


    public interface IInteger
    {
        int Value { get; }
    }
    public static class Dimensions
    {
        public class Two : IInteger
        {
            public int Value => 2;
        }
        public class Three : IInteger
        {
            public int Value => 3;
        }
    }
    public class Vector<T, D> where D : IInteger, new()
    {
        protected T[] data;
        public Vector()
        {
            data = new T[new D().Value];
        }
    }

    // defining inheriting types and then
    public class Vector2i : Vector<int, Dimensions.Two> { }




}

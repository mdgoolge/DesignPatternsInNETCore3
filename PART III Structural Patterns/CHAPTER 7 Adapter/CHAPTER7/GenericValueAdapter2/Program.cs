using System;
using System.Linq;

namespace GenericValueAdapter2
{
    class Program
    {
        static void Main(string[] args)
        {
            var v = new Vector2i(2, 3);
            var vv = new Vector2i(3, 2);
            var result = v + vv;

            Console.WriteLine(result) ;
        }
    }
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

        public Vector(params T[] values)
        {
            var requiredSize = new D().Value;
            data = new T[requiredSize];
            var providedSize = values.Length;
            for (int i = 0; i < Math.Min(requiredSize, providedSize); ++i)
                data[i] = values[i];
        }
       
    }

    public class VectorOfInt<D> : Vector<int, D>
where D : IInteger, new()
    {
        public VectorOfInt() { }
        public VectorOfInt(params int[] values) : base(values) { }
        public static VectorOfInt<D> operator +
        (VectorOfInt<D> lhs, VectorOfInt<D> rhs)
        {
            var result = new VectorOfInt<D>();
            var dim = new D().Value;
            for (int i = 0; i < dim; i++)
            {
                result[i] = lhs[i] + rhs[i];
            }
            return result;
        }


        public int this[int i]
        {
            get { return data[i]; }
            set { data[i] = value; }
        }

        public override string ToString()
        {
            return string.Join("-", data.Select(s => s.ToString()).ToArray());
        }
    }
    public class Vector2i : VectorOfInt<Dimensions.Two>
    {
        public Vector2i(params int[] values) : base(values)
        {
        }
    }
}

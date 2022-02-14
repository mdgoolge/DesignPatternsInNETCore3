using System;
using System.Linq;

namespace GenericValueAdapter3
{
    class Program
    {
        static void Main(string[] args)
        {
            var coord = Vector3f.Create(3.5f, 2.2f, 1); 
            var coord1 = Vector3f.Create(0.5f, 2.8f, 2);
            var result = coord + coord1;
            Console.WriteLine(result);
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
    public abstract class Vector<TSelf, T, D>
 where D : IInteger, new()
 where TSelf : Vector<TSelf, T, D>, new()
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

        public static TSelf Create(params T[] values)
        {
            var result = new TSelf();
            var requiredSize = new D().Value;
            result.data = new T[requiredSize];
            var providedSize = values.Length;
            for (int i = 0; i < Math.Min(requiredSize, providedSize); ++i)
                result.data[i] = values[i];
            return result;
        }
    }

    public class VectorOfFloat<TSelf, D> : Vector<TSelf, float, D>
where D : IInteger, new() where TSelf : Vector<TSelf, float, D>, new()
    {
        public VectorOfFloat() { }
        public VectorOfFloat(params float[] values) : base(values) { }
        public static VectorOfFloat<TSelf, D> operator +
        (VectorOfFloat<TSelf, D> lhs, VectorOfFloat<TSelf, D> rhs)
        {
            var result = new VectorOfFloat<TSelf, D>();
            var dim = new D().Value;
            for (int i = 0; i < dim; i++)
            {
                result[i] = lhs[i] + rhs[i];
            }
            return result;
        }


        public float this[int i]
        {
            get { return data[i]; }
            set { data[i] = value; }
        }

        public override string ToString()
        {
            return string.Join("-", data.Select(s => s.ToString()).ToArray());
        }
    }
    public class Vector3f
: VectorOfFloat<Vector3f, Dimensions.Three>
    {
        // empty again
    }
}

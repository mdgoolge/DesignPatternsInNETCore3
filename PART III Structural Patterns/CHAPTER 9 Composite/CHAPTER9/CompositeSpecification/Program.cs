using System;
using System.Linq;

namespace CompositeSpecification
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
    public abstract class ISpecification<T>
    {
        public abstract bool IsSatisfied(T p);
        //运算符重载需要静态方法
        public static ISpecification<T> operator &(ISpecification<T> first, ISpecification<T> second)
        {
            return new AndSpecification<T>(first, second);
        }
    }
    //public class AndSpecification<T> : ISpecification<T>
    //{
    //    private readonly ISpecification<T> first, second;
    //    public AndSpecification(ISpecification<T> first, ISpecification<T> second)
    //    {
    //        this.first = first;
    //        this.second = second;
    //    }
    //    public override bool IsSatisfied(T t)
    //    {
    //        return first.IsSatisfied(t) && second.IsSatisfied(t);
    //    }
    //}
    public class AndSpecification<T> : CompositeSpecification<T>
    {
        public AndSpecification(params ISpecification<T>[] items) : base(items)
        {
        }
        public override bool IsSatisfied(T t)
        {
            return items.All(i => i.IsSatisfied(t));
        }
    }
    public abstract class CompositeSpecification<T> : ISpecification<T>
    {
        protected readonly ISpecification<T>[] items;
        public CompositeSpecification(params ISpecification<T>[] items)
        {
            this.items = items;
        }
    }
}

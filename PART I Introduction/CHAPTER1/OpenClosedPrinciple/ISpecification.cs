using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenClosedPrinciple
{
    //public interface ISpecification<T>
    //{
    //    bool IsSatisfied(T item);
    //}
    public abstract class ISpecification<T>
    {
        public abstract bool IsSatisfied(T p);
        //运算符重载需要静态方法
        public static ISpecification<T> operator &(
        ISpecification<T> first, ISpecification<T> second)
        {
            return new AndSpecification<T>(first, second);
        }
    }
}

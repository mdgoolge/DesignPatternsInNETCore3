using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenClosedPrinciple
{
    public static class CriteriaExtensions
    {
        public static AndSpecification<Product> And(this Color color, Size size)
        {
            return new AndSpecification<Product>(
            new ColorSpecification(color),
            new SizeSpecification(size));
        }
    }
}

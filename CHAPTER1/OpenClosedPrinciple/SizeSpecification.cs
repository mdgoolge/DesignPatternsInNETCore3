﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenClosedPrinciple
{
    public class SizeSpecification : ISpecification<Product>
    {
        private Size   size;
        public SizeSpecification(Size  size)
        {
            this.size = size;
        }
        public override bool IsSatisfied(Product p)
        {
            return p.Size == size;
        }
    }
}

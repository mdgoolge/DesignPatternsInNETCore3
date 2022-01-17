using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositeBuilder
{
    public class Person
    {
        // address
        public string StreetAddress, Postcode, City;
        // employment info
        public string CompanyName, Position;
        public int AnnualIncome;

        public override string ToString()
        {
            string s = $"StreetAddress:{StreetAddress},Postcode:{Postcode},City:{City};";
            s += System.Environment.NewLine;
            s+= $"CompanyName:{CompanyName},Position:{Position},AnnualIncome:{AnnualIncome};";
            return s;
        }
    }
}

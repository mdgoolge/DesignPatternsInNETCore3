using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderParameter
{
    public class EmailBuilder
    {
        private readonly Email email;
        public EmailBuilder(Email email) => this.email = email;

        

        public EmailBuilder From(string from)
        {
            email.From = from;
            return this;
        }
        // other fluent members here
        
        public EmailBuilder To(string v)
        {
            email.To = v;
            return this;
        }
        public EmailBuilder Body(string v)
        {
            email.Body = v;
            return this;
        }
    }
}

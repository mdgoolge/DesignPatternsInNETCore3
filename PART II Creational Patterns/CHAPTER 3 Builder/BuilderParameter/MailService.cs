using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderParameter
{
    public class MailService
    {
        private void SendEmailInternal(Email email) { }
        public void SendEmail(Action<EmailBuilder> builder)
        {
            var email = new Email();
            builder(new EmailBuilder(email));
            SendEmailInternal(email);
        }
    }
}

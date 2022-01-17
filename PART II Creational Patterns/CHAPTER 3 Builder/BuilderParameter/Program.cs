using System;

namespace BuilderParameter
{
    class Program
    {
        static void Main(string[] args)
        {
            var ms = new MailService();
            ms.SendEmail(eb => eb.From("foo@bar.com")
            .To("bar@baz.com")
            .Body("Hello, how are you?"));
        }
    }
}

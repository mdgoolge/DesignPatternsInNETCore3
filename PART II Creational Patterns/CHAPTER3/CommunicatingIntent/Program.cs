using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace CommunicatingIntent
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = HtmlElement.Create("ul");
            builder.AddChildFluent("li", "hello")
            .AddChildFluent("li", "world");
            Console.WriteLine(builder);

            HtmlElement root = HtmlElement
.Create("ul")
.AddChildFluent("li", "hello")
.AddChildFluent("li", "world");
            Console.WriteLine(root);
        }
    }
    class HtmlElement
    {
        protected string Name, Text;
        protected List<HtmlElement> Elements = new List<HtmlElement>();
        protected const int indentSize = 2;
        // hide the constructors!
        protected HtmlElement() { }
        protected HtmlElement(string name, string text)
        {
            Name = name;
            Text = text;
        }
        public override string ToString()
        {
            string sub = string.Join("", Elements.Select(s => s.ToString()));
            return @$"<{Name}>{Text}{sub}</{Name}>";
        }


        // factory method
        public static HtmlBuilder Create(string name) => new HtmlBuilder(name);

        public class HtmlBuilder
        {
            protected readonly string rootName;
            protected HtmlElement root = new HtmlElement();
            public HtmlBuilder(string rootName)
            {
                this.rootName = rootName;
                root.Name = rootName;
            }

            public static implicit operator HtmlElement(HtmlBuilder builder)
            {
                return builder.root;
            }
            public HtmlBuilder AddChildFluent(string childName, string childText)
            {
                var e = new HtmlElement(childName, childText);
                root.Elements.Add(e);
                return this;
            }
            public override string ToString() => root.ToString();
        }
    }

}

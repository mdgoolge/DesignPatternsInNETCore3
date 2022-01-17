using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Linq;

namespace CHAPTER3
{
    class Program
    {
        static void Main(string[] args)
        {
            var sb = new StringBuilder();
            var words = new[] { "hello", "world" };
            sb.Append("<ul>");
            foreach (var word in words)
            {
                sb.AppendFormat("<li>{0}</li>", word);
            }
            sb.Append("</ul>");
            Console.WriteLine(sb);

            Console.WriteLine("---------------");

            //var words = new[] { "hello", "world" };
            var tag = new HtmlElement("ul", null);
            foreach (var word in words)
                tag.Elements.Add(new HtmlElement("li", word));
            Console. WriteLine(tag); // calls tag.ToString()


            Console.WriteLine("--Simple Builder-------------");
            var builder = new HtmlBuilder("ul");
            builder.AddChild1("li", "hello");
            builder.AddChild1("li", "world");
            Console.WriteLine(builder.ToString());

            Console.WriteLine("--Fluent Builder-------------");
            var builder2 = new HtmlBuilder("ul");
            builder2.AddChild2("li", "hello").AddChild2("li", "world");
            Console.WriteLine(builder2.ToString());
        }
    }
    class HtmlElement
    {
        public string Name, Text;
        public List<HtmlElement> Elements = new List<HtmlElement>();
        private const int indentSize = 2;
        public HtmlElement() { }
        public HtmlElement(string name, string text)
        {
            Name = name;
            Text = text;
        }
        public override string ToString()
        {
            string sub = string.Join("", Elements.Select(s => s.ToString()));
            return @$"<{Name}>{Text}{sub}</{Name}>";
        }
    }
    class HtmlBuilder
    {
        protected readonly string rootName;
        protected HtmlElement root = new HtmlElement();
        public HtmlBuilder(string rootName)
        {
            this.rootName = rootName;
            root.Name = rootName;
        }

        /// <summary>
        /// Simple Builder
        /// </summary>
        /// <param name="childName"></param>
        /// <param name="childText"></param>
        public void AddChild1(string childName, string childText)
        {
            var e = new HtmlElement(childName, childText);
            root.Elements.Add(e);
        }
        /// <summary>
        /// Fluent Builder
        /// </summary>
        /// <param name="childName"></param>
        /// <param name="childText"></param>
        public HtmlBuilder AddChild2(string childName, string childText)
        {
            var e = new HtmlElement(childName, childText);
            root.Elements.Add(e);
            return this;
        }
        public override string ToString() => root.ToString();
    }
}

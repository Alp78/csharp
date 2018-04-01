/*
Builder: provides an API to construct objects step-by-step
--> avoid too mnay constructor arguments
ex. StringBuilder()
*/


using System;
using System.Collections.Generic;
using System.Text;

namespace DP_Builder
{
    // HtmlElement represents a single tag
    public class HtmlElement
    {
        public string Name, Text;

        // a list of child elements can be defined for each tag
        public List<HtmlElement> Elements = new List<HtmlElement>();

        // indentation constant
        private const int indentSize = 2;

        // ctor initializing empty declaration
        public HtmlElement()
        {
            
        }

        // ctor initializing name and text fields
        public HtmlElement(string name, string text)
        {
            Name = name ?? throw new ArgumentNullException(paramName: nameof(name));
            Text = text ?? throw new ArgumentNullException(paramName: nameof(text));
        }

        // implementation of ToString()
        private string ToStringImpl(int indent)
        {
            var sb = new StringBuilder();

            // indentation variable
            // indent for root element will be 0, but 2 for child elements
            var i = new string(' ', indentSize * indent);

            // inserting the element in StringBuilder
            
            sb.AppendLine($"{i}<{Name}>");

            // if text is not empty, append
            if (!string.IsNullOrWhiteSpace(Text))
            {
                sb.Append(new string(' ', indentSize * (indent + 1)));
                sb.AppendLine(Text);
            }

            foreach (var e in Elements)
            {
                // recursive call for all child elements with an ident -> nesting of elements
                sb.AppendLine(e.ToStringImpl(indent + 1));
            }

            // closing tag
            sb.Append($"{i}</{Name}>");

            return sb.ToString();
        }

        public override string ToString()
        {
            // return ToStringImpl with an indentation of 0 (root element)
            return ToStringImpl(0);
        }

    }

    public class HtmlBuilder
    {
        private readonly string rootName;
        HtmlElement root = new HtmlElement();

        public HtmlBuilder(string rootName)
        {
            this.rootName = rootName;
            root.Name = rootName;
        }

        // fluent interface: returns a HtmlBuilder object so calls to the method can be concatenated
        public HtmlBuilder AddChild(string childName, string childText)
        {
            var e = new HtmlElement(childName, childText);
            root.Elements.Add(e);
            return this;
        }

        public override string ToString()
        {
            return root.ToString();
        }

        public void Clear()
        {
            root = new HtmlElement { Name = rootName };
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            var hello = "hello";
            var sb = new StringBuilder();
            sb.Append("<p>");
            sb.Append(hello);
            sb.Append("</p>");

            Console.WriteLine(sb);

            Console.WriteLine("");

            var words = new[] { "hello", "world" };
            sb.Clear();
            sb.Append("<ul>");
            foreach (var word in words)
            {
                sb.Append($"<li>{word}</li>");
            }
            sb.Append("</ul>");
            Console.WriteLine(sb);

            Console.WriteLine("");

            var htmlBuilder = new HtmlBuilder("ul");

            // fluent interface: append the calls of methods that return the class type of this method
            htmlBuilder.AddChild("li", "hello").AddChild("li", "world");

            Console.WriteLine(htmlBuilder);

            Console.ReadKey();

        }
    }
}

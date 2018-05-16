using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace clCrawler
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.Write("Enter a city: ");
            var city = Console.ReadLine();

            Console.Write("Enter a category: ");
            var category = Console.ReadLine();

            var xmlNode = $"http://{city}.craigslist.org/search/sss?format=rss&query={category}";

            

            var xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlNode);

            List<string> xNode = new List<string>();
            foreach (XmlNode node in xmlDoc.DocumentElement.ChildNodes)
            {
                xNode.Add(node.InnerText);
            }

            var start = "http";
            var end = "html";

            foreach (var item in xNode)
            {

                if ((item.Contains(start)) && (item.Contains(end)))
                {
                    int Start = item.IndexOf(start, 0) + start.Length;
                    int End = item.IndexOf(end, 0);
                    Console.WriteLine($"{start}{item.Substring(Start, End - Start)}{end}");
                }
            }

            Console.ReadKey();

        }
    }
}

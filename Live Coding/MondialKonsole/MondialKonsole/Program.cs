using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MondialKonsole
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\tmp\treubuch\Data\mondial.xml";
            XDocument document = XDocument.Load(path);

            var qLaender = document.Root.Descendants()
                                        .Where(xe => xe.Name == "country")
                                        .Select(xe => new
                                        {
                                            Name = xe.Elements()
                                                        .Where(el => el.Name == "name")
                                                        .Select(el => el.Value).FirstOrDefault(),
                                            Population = Convert.ToInt32(xe.Elements()
                                                            .Where(el => el.Name == "population")
                                                            .Select(el => el.Value).LastOrDefault())
                                        }
                                         );

            foreach (var item in qLaender)
            {
                Console.WriteLine($"{item.Name}: {item.Population:#,##0}");
            }

            Console.ReadKey();
        }
    }
}

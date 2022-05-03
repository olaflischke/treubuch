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
                                         ).OrderByDescending(land => land.Population);

            Console.WriteLine();
            Console.WriteLine("LÄNDER nach Größe:");
            Console.WriteLine("------------------");


            foreach (var item in qLaender)
            {
                Console.WriteLine($"{item.Name}: {item.Population:#,##0}");
            }

            var qBerge = document.Root.Descendants()
                                    .Where(xe => xe.Name == "mountain")
                                    .Select(xe => new
                                    {
                                        Name = xe.Elements()
                                                        .Where(el => el.Name == "name")
                                                        .Select(el => el.Value).FirstOrDefault(),
                                        Elevation = Convert.ToInt32(xe.Elements()
                                                                        .Where(el => el.Name == "elevation")
                                                                        .Select(el => el.Value).FirstOrDefault())
                                    })
                                    .OrderByDescending(berg => berg.Elevation)
                                    .Take(10);

            Console.WriteLine();
            Console.WriteLine("10 höchste BERGE:");
            Console.WriteLine("-----------------");


            foreach (var item in qBerge)
            {
                Console.WriteLine($"{item.Name}: {item.Elevation:#,##0}");
            }

            var qCapitalsMitB = document.Root.Descendants()
                            .Where(xe => xe.Name == "country")
                            .Select(country => new
                            {
                                Name = country.Elements()
                                            .Where(el => el.Name == "name")
                                            .Select(el => el.Value).FirstOrDefault(),
                                Capital = country.Descendants("city")
                                                .Where(cty => cty.Attribute("id").Value == country.Attribute("capital")?.Value)
                                                //.Where(cty => country.Attributes().Any(at => at.Name=="capital") && cty.Attribute("id").Value == country.Attribute("capital").Value)
                                                .FirstOrDefault()?
                                                .Elements("name").FirstOrDefault().Value ?? ""
                            })
                            .Where(ct => ct.Capital.StartsWith("A"));



            Console.WriteLine();
            Console.WriteLine("Alle Hauptstädte mit B:");
            Console.WriteLine("-----------------");

            foreach (var item in qCapitalsMitB)
            {
                Console.WriteLine($"{item.Name}: {item.Capital}");
            }

            Console.ReadKey();
        }
    }
}

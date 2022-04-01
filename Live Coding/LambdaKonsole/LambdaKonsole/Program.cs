using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaKonsole
{
    class Program
    {
        static void Main(string[] args)
        {
            IList<int> numbers = Enumerable.Range(100, 999).ToList();

            // C# 2
            //Predicate<int> predicate = DividableByNine;

            // C# 3
            //Predicate<int> predicate = delegate (int element)
            //                             {
            //                                 return element % 9 == 0;
            //                             };

            // C# 4: Lambda!
            Predicate<int> predicate = element => element % 9 == 0;
            // Oder ausführlicher:
            //Predicate<int> predicate = element => {
            //                                            if (element > 0)
            //                                                return element % 9 == 0;
            //                                            else
            //                                                return false;
            //                                        };

            IList<int> result = ListHelper.Filter(numbers, predicate);

            //IList<int> result = ListHelper.Filter(numbers, element => element % 9 == 0);

            foreach (int item in result)
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();
        }

        // Implentierung des Delegaten
        public static bool DividableByNine(int element)
        {
            return element % 9 == 0;
        }
    }

    public static class ListHelper
    {
        public static IList<T> Filter<T>(IList<T> source, Predicate<T> filterCondition)
        {
            IList<T> resultList = new List<T>();

            foreach (T item in source)
            {
                if (filterCondition(item) == true)
                {
                    resultList.Add(item);
                }
            }


            return resultList;
        }
    }
}

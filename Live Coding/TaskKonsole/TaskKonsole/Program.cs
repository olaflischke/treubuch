using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskKonsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Task[] tasks = new Task[3];

            tasks[0] = Task.Run(() => Wurzelsumme(1e9));
            tasks[1] = Task.Run(() => Wurzelsumme(2e9));
            tasks[2] = Task.Run(() =>
            {
                Wurzelsumme(1e9);
                Wurzelsumme(2e9);
            });

            try
            {
                //int index = Task.WaitAny(tasks);
                //Console.WriteLine($"Task #{tasks[index].Id} ist Erster!\n");
                Task.WaitAll(tasks);
                Console.WriteLine("Status:");
                foreach (var t in tasks)
                    Console.WriteLine("   Task #{0}: {1}", t.Id, t.Status);
            }
            catch (AggregateException ex)
            {
                Console.WriteLine("Irgendwas ging schief.");

                foreach (Exception exception in ex.InnerExceptions)
                {
                    Console.WriteLine($"{exception.Message}");
                }
            }
            Console.ReadKey();


        }

        private static double Wurzelsumme(double max)
        {
            double result = 0;

            for (int i = 0; i < max; i++)
            {
                result += Math.Sqrt(i);
                if (i>1e9)
                {
                    throw new Exception("Zahl zu groß!");
                }
            }

            return result;
        }

    }
}

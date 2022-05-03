using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelForKonsole
{
    class Program
    {
        static void Main(string[] args)
        {
            // Array deklarieren
            double[] array = new double[200 * 1000 * 1000];

            // Array füllen
            for (int i = 0; i < array.Length; i++)
                array[i] = 1;

            for (int i = 0; i < 5; i++)
            {
                Stopwatch sw = Stopwatch.StartNew();
                Serial(array, 2);
                Console.WriteLine($"Serial: {sw.Elapsed.TotalSeconds:f2} s");

                sw = Stopwatch.StartNew();
                ParallelFor(array, 2);
                Console.WriteLine($"Parallel.For: {sw.Elapsed.TotalSeconds:f2} s");

                sw = Stopwatch.StartNew();
                ParallelForDegreeOfParallelism(array, 2);
                Console.WriteLine($"Parallel.For (degree of parallelism): {sw.Elapsed.TotalSeconds:f2} s" );

                sw = Stopwatch.StartNew();
                CustomParallel(array, 2);
                Console.WriteLine("Custom parallel: {0:f2} s", sw.Elapsed.TotalSeconds);

                sw = Stopwatch.StartNew();
                MultiplicateArrayPartitioned(array, 2);
                Console.WriteLine("Partitioned: {0:f2} s", sw.Elapsed.TotalSeconds);

            }

            Console.ReadKey();
        }


        static void Serial(double[] array, double factor)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = array[i] * factor;
            }
        }

        static void ParallelFor(double[] array, double factor)
        {
            Parallel.For(
                0, array.Length, i => { array[i] = array[i] * factor; });
        }

        static void ParallelForDegreeOfParallelism(double[] array, double factor)
        {
            Parallel.For(
                0, 
                array.Length, 
                new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount },
                i => { array[i] = array[i] * factor; });
        }

        static void CustomParallel(double[] array, double factor)
        {
            var degreeOfParallelism = Environment.ProcessorCount;

            var tasks = new Task[degreeOfParallelism];

            for (int taskNumber = 0; taskNumber < degreeOfParallelism; taskNumber++)
            {
                // capturing taskNumber in lambda wouldn't work correctly
                int taskNumberCopy = taskNumber;

                tasks[taskNumber] = Task.Factory.StartNew(
                    () =>
                    {
                        for (int i = array.Length * taskNumberCopy / degreeOfParallelism;
                            i < array.Length * (taskNumberCopy + 1) / degreeOfParallelism;
                            i++)
                        {
                            array[i] = array[i] * factor;
                        }
                    });
            }

            Task.WaitAll(tasks);
        }

        public static void MultiplicateArrayPartitioned(double[] array, double factor)
        {
            var rangePartitioner = Partitioner.Create(0, array.Length);

            Parallel.ForEach(rangePartitioner, range =>
            {
                for (int i = range.Item1; i < range.Item2; i++)
                {
                    array[i] = array[i] * factor;
                }
            });
        }

    }
}

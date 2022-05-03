using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskFactoryKonsole
{
    class CustomData
    {
        public long CreationTime;
        public int Name;
        public int ThreadNum;
    }


    class Program
    {
        static void Main(string[] args)
        {
            Task[] taskArray = new Task[10];

            for (int i = 0; i < taskArray.Length; i++)
            {
                taskArray[i] = Task.Factory.StartNew((Object obj) => {
                                                                        CustomData data = obj as CustomData;
                                                                        if (data == null)
                                                                            return;

                                                                        data.ThreadNum = Thread.CurrentThread.ManagedThreadId;
                                                                     },
                                                                     new CustomData() { Name = i, CreationTime = DateTime.Now.Ticks });
            }

            Task.WaitAll(taskArray);

            

            foreach (Task task in taskArray)
            {
                CustomData data = task.AsyncState as CustomData;
                if (data != null)
                    Console.WriteLine($"Task #{ data.Name} created at {data.CreationTime}, ran on thread #{data.ThreadNum}.");
                else
                    Console.WriteLine($"No data for {task.Id}");
            }

            Console.ReadKey();
        }
    }
}

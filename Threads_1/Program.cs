using System;
using System.Threading;

namespace Threads_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread t1 = new Thread(new ThreadStart(Method2));
            t1.Name = "FirstThread";
            t1.Start();

            Thread t2 = new Thread(new ThreadStart(Method));
            t2.Name = "SecondThread";
            t2.Start();

            Console.ReadKey();
        }

        static void Method()
        {
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine($"{i} ");
                Thread.Sleep(1500);
            }
        }

        static void Method2()
        {
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine($"Vitaliy {i} ");
                Thread.Sleep(1500);
            }
        }
    }
}

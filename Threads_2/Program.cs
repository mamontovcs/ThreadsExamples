using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Threads_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Params pm = new Params(50, 50);

            Thread thread = new Thread(new ParameterizedThreadStart(Add));

            thread.Start(pm);

            Console.ReadKey();

        }

        static void Add(object obj)
        {
            if (obj is Params)
            {
                Console.WriteLine((obj as Params).A + (obj as Params).B);
            }

        }
    }

    class Params
    {
        public int A, B;

        public Params(int a, int b)
        {
            A = a;
            B = b;
        }
    }
}

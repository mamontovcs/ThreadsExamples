using System;
using System.Threading;

namespace Threads_3
{
    /*
     * Простой и безопасный к потокам способ заставить 
     * один поток ожидать завершения другого потока, предусматривает использование класса AutoResetEvent. 
     * В потоке, который должен ждать (таком как поток метода Main()), 
     * создадим экземпляр этого класса и передадим конструктору false, 
     * указав, что уведомления пока не было. В точке, где требуется ожидать, вызовем метод WaitOne(). 
     */
    class Program
    {
        private static AutoResetEvent autoResetEvent = new AutoResetEvent(false);

        static void Main(string[] args)
        {
            Console.WriteLine("Главный поток. ID: " + Thread.CurrentThread.ManagedThreadId);

            Params pm = new Params(10, 10);
            Thread t = new Thread(new ParameterizedThreadStart(Add));
            t.Start(pm);

            autoResetEvent.WaitOne();
            Console.WriteLine("Все потоки завершились");

            Console.ReadLine();
        }

        static void Add(object obj)
        {
            if (obj is Params)
            {
                Console.WriteLine("ID потока метода Add(): " + Thread.CurrentThread.ManagedThreadId);
                Params pr = (Params)obj;
                Console.WriteLine("{0} + {1} = {2}", pr.a, pr.b, pr.a + pr.b);

                // Сообщить другому потоку о завершении работы
                Thread.Sleep(3000);
                autoResetEvent.Set();
            }
        }
    }

    public class Params
    {
        public int a, b;
        public Params(int a, int b)
        {
            this.a = a;
            this.b = b;
        }
    }
}

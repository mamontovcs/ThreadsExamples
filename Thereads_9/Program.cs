using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Threads_9
{
    class Program
    {
        static void Main()
        {
            int CountofWorkThreads; // Переменная для хранения значения максимального количества потоков в пуле.
            int CountofImputOutputThreads; // Переменная для хранения количества потоков ввода-вывода в пуле.
            ThreadPool.GetMaxThreads(out CountofWorkThreads, out CountofImputOutputThreads); // Инициируем переменные.
            Console.WriteLine("Максимальное количество потоков: " + CountofWorkThreads + "\nКоличество потоков ввода-вывода: " + CountofImputOutputThreads); // Выводим значения на консоль.
            for (int i = 0; i < 5; i++)
                ThreadPool.QueueUserWorkItem(DoSomethinginThread); // Добавляем в пул потоков метод.
            Thread.Sleep(3000);

            Console.ReadLine();
        }

        static void DoSomethinginThread(object state) // Метод, который будет добавлен в поток.
        {
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"выполнение внутри потока из пула {0}", $"на этапе{1}", Thread.CurrentThread.ManagedThreadId, i);
                Thread.Sleep(50);
            }
        }
    }
}

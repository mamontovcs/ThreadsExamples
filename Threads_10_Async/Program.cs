using System;
using System.Threading;
using System.Threading.Tasks;

namespace Threads_10_Async
{
    class Program
    {
        static void Main(string[] args)
        {
            FactorialAsync();   // вызов асинхронного метода

            for (int i = 0; i < 20; i++)
            {
                Console.Write('|');
                Thread.Sleep(200);
            }

            Console.Read();
        }

        static void Factorial()
        {
            int result = 1;
            for (int i = 1; i <= 6; i++)
            {
                result *= i;
            }
            Thread.Sleep(5000);
            Console.WriteLine($"\nФакториал равен {result}");
        }
        // определение асинхронного метода
        static async void FactorialAsync()
        {
            Console.WriteLine("Начало метода FactorialAsync"); // выполняется синхронно
            await Task.Run(() => Factorial());                // выполняется асинхронно
            Console.WriteLine("Конец метода FactorialAsync");
        }
    }
}

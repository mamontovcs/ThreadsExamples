using System.Threading;
using System.Diagnostics;
using System.Threading.Tasks;
using System;

namespace ConsoleApplication1
{
    /*
     Например, если один поток только что выполнил оператор if (state == 5), 
     планировщик может вытеснить его и запустить еще один поток. 
     Второй поток попадет в тело if и, поскольку в переменной состояния по-прежнему содержится значение 5, 
     оно будет инкрементировано до 6. После этого снова настанет черед выполнения первого потока, в результате чего 
     в следующем операторе значение переменной состояния будет увеличено до 7. 
     Именно здесь и возникает состязание за ресурсы с выводом соответствующего сообщения
     */
    public class StateObject
    {
        private object threadLock = new object(); // СИНХРОНИЗИРУЕМЫЙ ОБЪЕКТ
        private int state = 5;
        public void ChangeState(int loop)
        {
            lock (threadLock) // СИНХРОНИЗАЦИЯ
            {
                if (state == 5)
                {
                    state++;
                    Console.WriteLine(state);
                    Trace.Assert(state == 6, "Состязание за ресурсы возникло после " + loop + " циклов");
                }
                state = 5;
            }
        }
    }

    public class SampleThread
    {
        public void RaceCondition(object obj)
        {
            Trace.Assert(obj is StateObject, "obj должен иметь тип StateObject");
            StateObject state = obj as StateObject;
            int i = 0;
            while (true)
                state.ChangeState(i++);
        }
    }

    class Program
    {
        /*
         * Избежать возникновения данной проблемы можно, заблокировав разделяемый объект. 
         * Это делается с помощью оператора lock. 
         * Внутрь блока кода, отвечающего за блокировку объекта состояния, может попадать только один поток. 
         * Из-за того, что этот объект разделяется среди всех потоков, в случае, если какой-то один из потоков уже заблокировал его, 
         * другой поток при достижении отвечающего за блокировку блока кода должен остановиться и ожидать своей очереди.
         * При получении блокировки поток вступает во владение ею и снимает ее при достижении конца отвечающего за
         * блокировку блока кода. Когда каждый поток, изменяющий объект, на который ссылается переменная состояния,
         * использует блокировку, проблема с состязанием за ресурсы больше не возникает.
         */
        static void Main()
        {
            var state = new StateObject();
            for (int i = 0; i < 20; i++)
                new Task(new SampleThread().RaceCondition, state).Start();
            Thread.Sleep(1000);
            Console.ReadKey();
        }
    }
}
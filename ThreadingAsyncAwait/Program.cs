using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using System.Threading;

namespace ThreadingAsyncAwait
{
    class Program
    {
        static int a = 0;
        static object _lock = new object();
        static int _currThreadID;

        static async Task<object> input()
        {
            var result = 0;

            await Task.Factory.StartNew(() =>
            {

            });

            return result;
        }

        static void Main(string[] args)
        {

            Console.WriteLine($"Main thread({Thread.CurrentThread.ManagedThreadId}) started");

            Thread thread = new Thread(() =>
            {
                ConsoleKeyInfo cki = new ConsoleKeyInfo();

                while (cki.Key != ConsoleKey.E)
                {
                    if (Console.KeyAvailable)
                    {
                        cki = Console.ReadKey(true);
                        Console.Write(cki.Key.ToString());   
                    }
                }

            });
            thread.Start();

            Console.WriteLine($"Main thread({Thread.CurrentThread.ManagedThreadId}) is over");
            thread.Join();

            //for (int i = 0; i < 10; ++i)
            //{
            //    Thread _thread = new Thread(() =>
            //    {
            //        if (Thread.CurrentThread.ManagedThreadId != _currThreadID)
            //        {
            //            _currThreadID = Thread.CurrentThread.ManagedThreadId;
            //            Console.WriteLine($"Поток({Thread.CurrentThread.ManagedThreadId}) ждёт очереди");
            //        }

            //        lock (_lock)
            //        {
            //            Console.WriteLine($"Побочный поток({Thread.CurrentThread.ManagedThreadId}) начал работать с переменной А...");
            //            for (int _i = 0; _i < 5; ++_i)
            //            {
            //                a = _i;
            //                Console.WriteLine($"A({Thread.CurrentThread.ManagedThreadId }) is: {a}");
            //                Thread.Sleep(1000);
            //            }
            //            Console.WriteLine($"Побочный поток({Thread.CurrentThread.ManagedThreadId}) перестал работать с переменной А.");

            //            Console.WriteLine($"A is {a}");
            //        }

            //        Console.WriteLine("\n");
            //    });

            //    _thread.Start();
            //}
        }
    }
}

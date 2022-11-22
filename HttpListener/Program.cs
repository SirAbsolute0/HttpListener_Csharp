using System;
using System.Threading;
using System.Net;

namespace Test
{
    class Program
    {
        static void Main()
        {
            Thread thread1 = new Thread(http_listener.SimpleListenerExample);
            thread1.Start();
            
            for (int i = 0; i < 9999; i++)
            {
                Console.WriteLine("In main.");
                Thread.Sleep(100);

            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Component.PolarReader
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting Polar reader...");
            var listener = new AsynchronousSocketListener();
            Task.Run(() => listener.StartListening());
            Console.WriteLine("Polar reader is running...");
            Console.Read();
        }
    }
}

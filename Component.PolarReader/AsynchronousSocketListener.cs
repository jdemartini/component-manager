using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Component.PolarReader
{
    public class AsynchronousSocketListener
    {
        public async Task StartListening()
        {
            var listeningIP = IPAddress.Any;
            var listeningPort = 11002;

            var listener = new TcpListener(listeningIP, listeningPort);

            try
            {
                listener.Start();
                
                Console.WriteLine(String.Format("Starting listening: {0}:{1}", listeningIP, listeningPort));
                
                while (true)
                {
                    await AcceptClientsAsync(listener);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("-------ERROR--------");
                Console.WriteLine(e.Message);
                Console.WriteLine("--------------------\n");
            }
            finally
            {
                Console.WriteLine("Stoping polar listener...");
                listener.Stop();
                Console.WriteLine("Polar listener stoped.");
            }
            Console.Read();
        }

        async Task AcceptClientsAsync(TcpListener listener)
        {
            TcpClient client = await listener.AcceptTcpClientAsync().ConfigureAwait(false);
            try
            {
                await ReceiveAsync(client);
            }
            catch (Exception e)
            {
                Console.WriteLine("-------ERROR--------");
                Console.WriteLine(e.Message);
                Console.WriteLine("--------------------\n");
            }
            finally
            {
                Console.WriteLine("Closing tcp client...");
                client.Close();
                Console.WriteLine("TCP closed.");
            }
        }

        async Task ReceiveAsync(TcpClient client)
        {
            using (client)
            {
                var buffer = new byte[1024];
                var stream = client.GetStream();
                var timeout = Task.Delay(TimeSpan.FromSeconds(10));
                var readTask = stream.ReadAsync(buffer, 0, buffer.Length);
                var completedTask = await Task.WhenAny(timeout, readTask).ConfigureAwait(false);
                if (completedTask == timeout)
                    return;
                var command = Encoding.UTF8.GetString(buffer, 0, readTask.Result);
                var response = HandleRead.Process(command);
                Console.WriteLine("Command received: {0}", command);
                await SendAsync(stream, response);
            }
        }

        async Task SendAsync(NetworkStream stream, string data)
        {
            var buffer = Encoding.UTF8.GetBytes(data);
            Console.WriteLine("Sending data:");
            Console.WriteLine(data);
            await stream.WriteAsync(buffer, 0, buffer.Length).ConfigureAwait(false);
            stream.Close(1000);
        }
    }
}

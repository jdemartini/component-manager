using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Threading;
using System.Diagnostics;

namespace ComponentManagerWCF.Handlers
{
    public class ServiceReader
    {
        
        private int endPointPort;
        private string command;
        //const int END_POINT_PORT = 11002;
        //string COMMAND = "CM-READ";
        private IPEndPoint endPoint;
        private TcpClient client;
   
        public ServiceReader(int endPointPort, string command)
        {
            this.endPointPort = endPointPort;
            this.command = command;
            this.endPoint = new IPEndPoint(IPAddress.Loopback, this.endPointPort);
            this.client = new TcpClient(new IPEndPoint(IPAddress.Any, 11103));
            connect();

        }

        async Task<string> ReceiveAsync(TcpClient client)
        {
            using (client)
            {
                var buffer = new byte[1024];
                var stream = client.GetStream();
                var timeout = Task.Delay(TimeSpan.FromSeconds(10));
                var result = await stream.ReadAsync(buffer, 0, buffer.Length);
                var response = Encoding.UTF8.GetString(buffer, 0, result);
                Console.WriteLine("Data received:");
                Console.WriteLine(response);
                return response;
            }
        }

        public async Task<string> RequestDataAsync()
        {
            
            try
            {
                Debug.WriteLine(string.Format("WCF Requesting to {0}:{1}", endPoint.Address, endPoint.Port), "Info");
                connect();
                var stream = client.GetStream();
                Debug.WriteLine(string.Format("Command {0}", command), "WCF Info");
                await stream.WriteAsync(Encoding.UTF8.GetBytes(command), 0, command.Length);
                var result = await ReceiveAsync(client);
                await stream.FlushAsync();
                stream.Dispose();
                
                return result;
                
            }
            catch (Exception e)
            {
                Debug.WriteLine(e, "WCF Error");
                //throw e;
            }
            finally
            {
                Debug.WriteLine("Closing tcp client...", "WCF Info");
                
                Debug.WriteLine("TCP closed.", "WCF Info");
            }
            return "";
        }

        private async void connect()
        {
            if (this.client.Connected == false && this.client.Available == 0)
                await client.ConnectAsync(endPoint.Address, endPoint.Port);

        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace chatP2P
{
    static class MessageManager
    {
        static private string IP_ADDRESS = "10.5.43.52";
        static private int PORT = 13;
        static private IPEndPoint ipEndPoint = new(IPAddress.Parse(IP_ADDRESS), PORT);
        static private TcpClient client = null;

        static async void Connect()
        {

            //var ipEndPoint = new IPEndPoint(ipAddress, 13);
            if(client == null)
            {
                client = new();
                bool rep = false;
                while (!rep)
                {
                    try
                    {
                        await client.ConnectAsync(ipEndPoint);
                        rep = true;
                    }
                    catch (Exception ex)
                    {
                        rep = false;
                    }

                }
            }
        }
        static public async void SendMessage(string message)
        {
            

            await using NetworkStream stream = client.GetStream();

            var buffer = Encoding.UTF8.GetBytes(message);
            await stream.WriteAsync(buffer);

            
        }
    }
}

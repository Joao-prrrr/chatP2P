using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace chatP2P
{
    static class MessageManager
    {
        static private string IP_ADDRESS = "10.5.53.39";
        static private int PORT = 13;
        static private IPEndPoint ipEndPoint = new(IPAddress.Parse(IP_ADDRESS), PORT);
        static private TcpClient client = null;

        public static async void Connect()
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
        public static async void SendMessage(string message)
        {
            while (true)
            {
                try
                {
                    await using NetworkStream stream = client.GetStream();

                    var buffer = Encoding.UTF8.GetBytes(message);
                    await stream.WriteAsync(buffer);
                    break;
                }
                catch
                {
                    // no need to code here
                }
            }
        }

        public static async Task<string> receiveMsg()
        {
            while (true)
            {
                var ipEndPoint = new IPEndPoint(IPAddress.Any, 13);
                TcpListener listener = new(ipEndPoint);

                bool rep = false;
                while (!rep)
                {
                    try
                    {
                        listener.Start();

                        using TcpClient handler = await listener.AcceptTcpClientAsync();
                        await using NetworkStream stream = handler.GetStream();

                        //var message = $"📅 {DateTime.Now} 🕛";
                        // var dateTimeBytes = Encoding.UTF8.GetBytes(message);
                        // await stream.WriteAsync(dateTimeBytes);

                        byte[] buffer = new byte[1024];

                        var received = stream.Read(buffer);
                        var message = Encoding.UTF8.GetString(buffer.AsSpan(0, received));
                        // Sample output:
                        //     Sent message: "📅 8/22/2022 9:07:17 AM 🕛"
                        rep = true;
                        return message;
                    }
                    finally
                    {
                        listener.Stop();
                    }
                }
            }
        }
    }
}

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
    class MessageManager
    {
        static private string IP_ADDRESS = "10.5.43.52";
        static private int PORT = 13;
        static private IPEndPoint ipEndPoint = new(IPAddress.Parse(IP_ADDRESS), PORT);

        static private MessageManager singleton = null;
        private TcpClient client = null;
        private TcpListener listener = null;

        private MessageManager()
        {
            client = new TcpClient();
            listener = new(new IPEndPoint(IPAddress.Any, PORT));

            Connect();

        }

        public static MessageManager GetInstance()
        {
            if(singleton == null)
            {
                singleton = new MessageManager();
            }
            return singleton;
        }

        private async void Connect()
        {
            bool rep = false;
            while (!rep)
            {
                try
                {
                    await client.ConnectAsync(ipEndPoint);
                    rep = true;
                }
                catch
                {
                }

            }
        }

        public async void SendMessage(string message)
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
                catch { }
            }
        }

        public async Task<string> ReceiveMsg()
        {
            while (true)
            {
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
                    catch
                    {
                        listener.Stop();
                    }
                }
            }
        }
    }
}

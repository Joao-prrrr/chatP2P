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
        static async void SendMessage()
        {
            //IPHostEntry ipHostInfo = await Dns.GetHostEntryAsync("10.5.43.52");
            //IPAddress ipAddress = ipHostInfo.AddressList[0];

            IPEndPoint ipEndPoint = new(IPAddress.Parse("10.5.43.52"), 13);

            //var ipEndPoint = new IPEndPoint(ipAddress, 13);

            using TcpClient client = new();
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

            await using NetworkStream stream = client.GetStream();

            var buffer = Encoding.UTF8.GetBytes("Ta mere la choiun 2");
            await stream.WriteAsync(buffer);

            //var message = Encoding.UTF8.GetString(buffer, 0, received);
            //Console.WriteLine($"Ta mere -- Message received: \"{message}\"");
            // Sample output:
            //     Message received: "📅 8/22/2022 9:07:17 AM 🕛"
        }

        static async Task<string> receiveMsg()
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

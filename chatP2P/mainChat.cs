﻿using System.Net;
using System.Net.Sockets;
using System.Text;

namespace chatP2P
{
    public partial class mainChat : Form
    {
        public mainChat()
        {
            InitializeComponent();
            test();
        }



        async void test()
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
                }catch (Exception ex)
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
    }
}
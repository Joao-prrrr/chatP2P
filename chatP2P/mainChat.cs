using System.Net;
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
                        label1.Text = message;
                        // Sample output:
                        //     Sent message: "📅 8/22/2022 9:07:17 AM 🕛"
                        rep = true;
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
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
            //IPHostEntry ipHostInfo = await Dns.GetHostEntryAsync("10.5.43.52");
            //IPAddress ipAddress = ipHostInfo.AddressList[0];

            IPEndPoint ipEndPoint = new(IPAddress.Parse("10.5.43.52"), 11_000);

            using Socket client = new(
            ipEndPoint.AddressFamily,
            SocketType.Stream,
            ProtocolType.Tcp);

            bool response = false;
            while(!response)
            {
                try
                {
                    await client.ConnectAsync(ipEndPoint);
                    response = true;
                }
                catch (Exception ex)
                {
                    response = false;
                }
                Thread.Sleep(5000);
            }

            while (true)
            {
                // Send message.
                var message = "Hi friends 👋!<|EOM|>";
                var messageBytes = Encoding.UTF8.GetBytes(message);
                _ = await client.SendAsync(messageBytes, SocketFlags.None);
                Console.WriteLine($"Socket client sent message: \"{message}\"");

                /*// Receive ack.
                var buffer = new byte[1_024];
                var received = await client.ReceiveAsync(buffer, SocketFlags.None);
                var response = Encoding.UTF8.GetString(buffer, 0, received);
                if (response == "<|ACK|>")
                {
                    Console.WriteLine(
                        $"Socket client received acknowledgment: \"{response}\"");
                    break;
                }*/
                // Sample output:
                //     Socket client sent message: "Hi friends 👋!<|EOM|>"
                //     Socket client received acknowledgment: "<|ACK|>"
            }

            client.Shutdown(SocketShutdown.Both);
        }
    }
}
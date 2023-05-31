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
        }

        private async void mainChat_Shown(object sender, EventArgs e)
        {
            MessageManager instance = MessageManager.GetInstance();
            instance.DefineAsListner();
            await instance.Connect();

            //instance.SendMessage("ma bite");
            var msg = await instance.ReceiveMsg();
            label1.Text = msg;
            
        }
    }
}
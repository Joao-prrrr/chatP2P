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
            MessageManager.Connect();
            MessageManager.SendMessage("Bakau Ballin' Three big dick ass niggers");
        }
    }
}
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;

namespace chatP2P
{
    public partial class mainChat : Form
    {
        MessageManager instance = MessageManager.GetInstance();

        public mainChat()
        {
            InitializeComponent();
            btnSend.Enabled = false;

            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Interval = 1000;
            timer.Elapsed += timer_Elapsed;
            timer.Start();
        }

        private async void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            var msg = await instance.ReceiveMsg();

            Font font = new Font("Arial", 9, FontStyle.Bold);
            richTextBox1.SelectionFont = font;
            richTextBox1.SelectionColor = Color.Red;
            richTextBox1.SelectedText = Environment.NewLine + "Other :  " + textBox1.Text;
        }

        private async void mainChat_Shown(object sender, EventArgs e)
        {
            /*//MessageManager.Connect();
            MessageManager instance = MessageManager.GetInstance();
            //instance.SendMessage("ma bite");
            var msg = await instance.ReceiveMsg();*/
        }

        private async void btnSend_Click(object sender, EventArgs e)
        {
            Font font = new Font("Arial", 9, FontStyle.Bold);
            richTextBox1.SelectionFont = font;
            richTextBox1.SelectionColor = Color.Green;
            richTextBox1.SelectedText = Environment.NewLine + "You :    " + textBox1.Text;

            textBox1.Text = "";

            /*
            instance.SendMessage(textBox1.Text);*/
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "")
            {
                btnSend.Enabled = false;
            }
            else
            {
                btnSend.Enabled = true;
            }
        }
    }
}
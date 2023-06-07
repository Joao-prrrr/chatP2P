using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace chatP2P
{
    public partial class mainChat : Form
    {
        MessageManager instance = MessageManager.GetInstance();

        public mainChat()
        {
            InitializeComponent();
            btnSend.Enabled = false;
            textBox1.Enabled = false;

            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Interval = 1000;
            timer.Elapsed += timer_Elapsed;
            timer.Start();
        }

        private async void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (/*instance.verifConnection().Result*/ true)
            {
                lblConnect.ForeColor = Color.Green;
                string txt = "Connected";
                lblConnect.Invoke((MethodInvoker)delegate {
                    lblConnect.Text = txt;
                });

                //var msg = await instance.Receive();

                Font msgFont = new Font("Arial", 9, FontStyle.Bold);
                /*richTextBox1.SelectionFont = msgFont;
                richTextBox1.SelectionColor = Color.Red;
                richTextBox1.SelectedText = Environment.NewLine + "Other :  " + textBox1.Text;

                textBox1.Invoke((MethodInvoker)delegate {
                    textBox1.Enabled = true;
                });

                btnSend.Invoke((MethodInvoker)delegate {
                    btnSend.Enabled = true;
                });*/
            }
            else
            {
                lblConnect.ForeColor = Color.Red;
                string txt = "Disonnected - Unable to communicate with";
                lblConnect.Invoke((MethodInvoker)delegate {
                    lblConnect.Text = txt;
                });

                textBox1.Invoke((MethodInvoker)delegate { 
                    textBox1.Enabled = false;
                });

                btnSend.Invoke((MethodInvoker)delegate {
                    btnSend.Enabled = false;
                });
            }
        }

        private async void mainChat_Shown(object sender, EventArgs e)
        {
            instance.DefineAsListner();

            bool connected = false;
            while(!connected)
            {
                connected = await instance.Connect();
            }
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
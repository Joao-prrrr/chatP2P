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
        }

        private void mainChat_Shown(object sender, EventArgs e)
        {
<<<<<<< HEAD
            //MessageManager.Connect();
            MessageManager instance = MessageManager.GetInstance();
            instance.SendMessage("ma bite");

            //label1.Text = message.Result;
            // MessageManager.Connect();
            // MessageManager.SendMessage("Hello \r\n \r\n \r\n \r\n \r\n \r\n Nigga");
            //var txt = MessageManager.ReceiveMsg();
           //label1.Text = txt.Result;
=======
            // MessageManager.Connect();
            // MessageManager.SendMessage("Hello \r\n \r\n \r\n \r\n \r\n \r\n Nigga");
            var txt = MessageManager.ReceiveMsg();
           label1.Text = txt.Result;
>>>>>>> 05520c6163fca9613d86b6f871702c942f702dcf
        }
    }
}
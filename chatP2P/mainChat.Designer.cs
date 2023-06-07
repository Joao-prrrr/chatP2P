namespace chatP2P
{
    partial class mainChat
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBox1 = new TextBox();
            btnSend = new Button();
            richTextBox1 = new RichTextBox();
            lblConnect = new Label();
            txtIP = new TextBox();
            btnConnect = new Button();
            lblIP = new Label();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(184, 511);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(868, 23);
            textBox1.TabIndex = 0;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // btnSend
            // 
            btnSend.BackColor = SystemColors.Control;
            btnSend.Location = new Point(1058, 511);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(90, 23);
            btnSend.TabIndex = 1;
            btnSend.Text = "Envoyer";
            btnSend.UseVisualStyleBackColor = false;
            btnSend.Click += btnSend_Click;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(184, 32);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.ReadOnly = true;
            richTextBox1.ScrollBars = RichTextBoxScrollBars.Vertical;
            richTextBox1.Size = new Size(964, 473);
            richTextBox1.TabIndex = 2;
            richTextBox1.Text = "";
            // 
            // lblConnect
            // 
            lblConnect.AutoSize = true;
            lblConnect.Font = new Font("Arial Narrow", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblConnect.ForeColor = Color.Black;
            lblConnect.Location = new Point(184, 9);
            lblConnect.Name = "lblConnect";
            lblConnect.Size = new Size(0, 20);
            lblConnect.TabIndex = 3;
            // 
            // txtIP
            // 
            txtIP.Location = new Point(12, 32);
            txtIP.Name = "txtIP";
            txtIP.Size = new Size(166, 23);
            txtIP.TabIndex = 4;
            // 
            // btnConnect
            // 
            btnConnect.Location = new Point(12, 61);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(166, 23);
            btnConnect.TabIndex = 5;
            btnConnect.Text = "Connect";
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Click += btnConnect_Click;
            // 
            // lblIP
            // 
            lblIP.AutoSize = true;
            lblIP.Location = new Point(12, 9);
            lblIP.Name = "lblIP";
            lblIP.Size = new Size(62, 15);
            lblIP.TabIndex = 6;
            lblIP.Text = "Contact IP";
            // 
            // mainChat
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1160, 546);
            Controls.Add(lblIP);
            Controls.Add(btnConnect);
            Controls.Add(txtIP);
            Controls.Add(lblConnect);
            Controls.Add(richTextBox1);
            Controls.Add(btnSend);
            Controls.Add(textBox1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "mainChat";
            Text = "Chat P2P";
            Shown += mainChat_Shown;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private Button btnSend;
        private RichTextBox richTextBox1;
        private Label lblConnect;
        private TextBox txtIP;
        private Button btnConnect;
        private Label lblIP;
    }
}
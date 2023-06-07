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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.lblConnect = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 511);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(868, 23);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // btnSend
            // 
            this.btnSend.BackColor = System.Drawing.SystemColors.Control;
            this.btnSend.Location = new System.Drawing.Point(886, 511);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(90, 23);
            this.btnSend.TabIndex = 1;
            this.btnSend.Text = "Envoyer";
            this.btnSend.UseVisualStyleBackColor = false;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 32);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.richTextBox1.Size = new System.Drawing.Size(964, 473);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "";
            // 
            // lblConnect
            // 
            this.lblConnect.AutoSize = true;
            this.lblConnect.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblConnect.ForeColor = System.Drawing.Color.Black;
            this.lblConnect.Location = new System.Drawing.Point(12, 9);
            this.lblConnect.Name = "lblConnect";
            this.lblConnect.Size = new System.Drawing.Size(0, 20);
            this.lblConnect.TabIndex = 3;
            // 
            // mainChat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(988, 546);
            this.Controls.Add(this.lblConnect);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.textBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "mainChat";
            this.Text = "Chat P2P";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox textBox1;
        private Button btnSend;
        private RichTextBox richTextBox1;
        private Label lblConnect;
    }
}
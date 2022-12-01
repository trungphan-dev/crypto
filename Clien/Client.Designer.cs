
namespace Clien
{
    partial class Client
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.btDoc = new System.Windows.Forms.Button();
            this.btMHGM = new System.Windows.Forms.Button();
            this.btGhi = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.btChat = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(0, 82);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(320, 363);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // btDoc
            // 
            this.btDoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btDoc.Location = new System.Drawing.Point(344, 96);
            this.btDoc.Name = "btDoc";
            this.btDoc.Size = new System.Drawing.Size(113, 57);
            this.btDoc.TabIndex = 1;
            this.btDoc.Text = "Doc";
            this.btDoc.UseVisualStyleBackColor = true;
            this.btDoc.Click += new System.EventHandler(this.btDoc_Click);
            // 
            // btMHGM
            // 
            this.btMHGM.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btMHGM.Location = new System.Drawing.Point(344, 231);
            this.btMHGM.Name = "btMHGM";
            this.btMHGM.Size = new System.Drawing.Size(113, 55);
            this.btMHGM.TabIndex = 2;
            this.btMHGM.Text = "MH-GM\r\n";
            this.btMHGM.UseVisualStyleBackColor = true;
            this.btMHGM.Click += new System.EventHandler(this.btMHGM_Click);
            // 
            // btGhi
            // 
            this.btGhi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btGhi.Location = new System.Drawing.Point(344, 359);
            this.btGhi.Name = "btGhi";
            this.btGhi.Size = new System.Drawing.Size(113, 49);
            this.btGhi.TabIndex = 3;
            this.btGhi.Text = "Ghi";
            this.btGhi.UseVisualStyleBackColor = true;
            this.btGhi.Click += new System.EventHandler(this.btGhi_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(136, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(387, 26);
            this.textBox1.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(38, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 25);
            this.label1.TabIndex = 6;
            this.label1.Text = "DiaChi";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(17, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 26);
            this.label2.TabIndex = 7;
            this.label2.Text = "Mat Khau";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(136, 38);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(387, 26);
            this.textBox2.TabIndex = 8;
            // 
            // listView1
            // 
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(496, 82);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(292, 250);
            this.listView1.TabIndex = 9;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.List;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(496, 338);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(292, 26);
            this.textBox3.TabIndex = 10;
            // 
            // btChat
            // 
            this.btChat.Location = new System.Drawing.Point(641, 390);
            this.btChat.Name = "btChat";
            this.btChat.Size = new System.Drawing.Size(147, 48);
            this.btChat.TabIndex = 11;
            this.btChat.Text = "Chat";
            this.btChat.UseVisualStyleBackColor = true;
            this.btChat.Click += new System.EventHandler(this.btChat_Click);
            // 
            // Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btChat);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btGhi);
            this.Controls.Add(this.btMHGM);
            this.Controls.Add(this.btDoc);
            this.Controls.Add(this.richTextBox1);
            this.Name = "Client";
            this.Text = "Client";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Client_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button btDoc;
        private System.Windows.Forms.Button btMHGM;
        private System.Windows.Forms.Button btGhi;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button btChat;
    }
}


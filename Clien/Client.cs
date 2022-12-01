using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Clien
{
    public partial class Client : Form
    {
        public Client()
        {
            InitializeComponent();
        }
        IPEndPoint ipep;
        Socket client;
        private void Form1_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            Connected();
        }

        private void Client_FormClosed(object sender, FormClosedEventArgs e)
        {
            Ngat();
        }

        void Connected()
        {
            ipep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8080);
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                client.Connect(ipep);
            }
            catch
            {
                MessageBox.Show("Khong the ket noi toi server!", "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Thread listen = new Thread(Received);
            listen.IsBackground = true;
            listen.Start();
        }
        void Send()
        {

            if (textBox2.Text != string.Empty)
            {
                ThongTin tt = new ThongTin();
                tt.passWord = textBox2.Text;
                tt.content = richTextBox1.Text;
                client.Send(Serialize(tt));
            }
            else
            {
                MessageBox.Show("Chua Nhap Mat Khau", "Thong Bao", MessageBoxButtons.OK);
            }    
        }

        void Chat()
        {
            if(textBox3.Text!=string.Empty)
            {
                string content = "Client: " + textBox3.Text;
                listView1.Items.Add(new ListViewItem(content));
                client.Send(Serialize(textBox3.Text));
                textBox3.Clear();
            }
            else
            {
                MessageBox.Show("Vui long nhap tin nhan", "Thong Bao", MessageBoxButtons.OK);
            }
        }


        void Received()
        {
            try
            {
                while (true)
                {
                    byte[] data = new byte[1024 * 5000];
                    client.Receive(data);
                    string text = (string)Deserialize(data);
                    if (text.StartsWith("0"))
                    {
                        text = text.Substring(1);
                        string content = "Server: " + text;
                        listView1.Items.Add(new ListViewItem(content));
                    }
                    else
                    {
                        text = text.Substring(1);
                        richTextBox1.Text = text;
                    }
                }
            }
            catch
            {
                Ngat();
            }
        }

        void Ngat()
        {
            client.Close();
        }

        byte[] Serialize(object obj)
        {
            MemoryStream mmStream = new MemoryStream();
            BinaryFormatter bnrFormatter = new BinaryFormatter();
            bnrFormatter.Serialize(mmStream, obj);
            return mmStream.ToArray();
        }

        object Deserialize(byte[] data)
        {
            MemoryStream mmStream = new MemoryStream(data);
            BinaryFormatter bnrFormatter = new BinaryFormatter();
            return bnrFormatter.Deserialize(mmStream);

        }


        private void btChat_Click(object sender, EventArgs e)
        {
            Chat();
        }

        private void btDoc_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();
            FileStream fs = new FileStream(ofd.FileName, FileMode.OpenOrCreate);
            StreamReader sr = new StreamReader(fs);
            textBox1.Text = ofd.FileName.ToString();
            string content = sr.ReadToEnd();
            richTextBox1.Text = content;
            fs.Close();
        }

        private void btMHGM_Click(object sender, EventArgs e)
        {
            Send();
        }

        private void btGhi_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.ShowDialog();
            FileStream fs = new FileStream(sfd.FileName, FileMode.OpenOrCreate);
            StreamWriter sw = new StreamWriter(fs);
            string content = richTextBox1.Text;
            sw.Write(content);
            sw.Close();
        }
    }
}

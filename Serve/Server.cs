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
using Clien;
using System.Security.Cryptography;

namespace Serve
{
    public partial class Server : Form
    {
        public Server()
        {
            InitializeComponent();
        }
        const int Keysize = 128;
        const int DerivationIterations = 1000;
        IPEndPoint ipep;
        Socket server;
        Socket client;
        string passWord="";
        
        private void Form1_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            Thread t1 = new Thread(new ThreadStart(Connected));
            t1.Start();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Ngat();
        }
        void Received()
        {
            try
            {
                while (true)
                {
                    byte[] data = new byte[1024 * 5000];
                    client.Receive(data);
                    try
                    {
                        ThongTin tt = (ThongTin)Deserialize(data);
                        richTextBox1.Text = tt.content;
                        passWord = tt.passWord;
                    }
                    catch
                    {
                        string content = "Client: ";
                        content+=(string)Deserialize(data);
                        listView1.Items.Add(new ListViewItem(content));
                    }
                    
                }
            }
            catch
            {
                Ngat();
            }
        }

        void Connected()
        {
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            ipep = new IPEndPoint(IPAddress.Any, 8080);

            server.Bind(ipep);

            server.Listen(-1);
            client = server.Accept();
            Thread received = new Thread(Received);
            received.IsBackground = true;
            received.Start();
        }

        void Send()
        {
            string text = "1";
            text+=richTextBox1.Text;
            client.Send(Serialize(text));
        }

        void Ngat()
        {
            
            server.Close();
            
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

        private void button1_Click(object sender, EventArgs e)
        {
            string s = Encrypt(richTextBox1.Text, passWord);
            richTextBox1.Text = s;
            Send();
        }

        byte[] Generate128BitsOfEntropy()
        {
            var randomBytes = new byte[16]; 
            string s = "asdfghjklqwertyi";
            randomBytes = Encoding.ASCII.GetBytes(s);
            return randomBytes;
        }

        string Encrypt(string plainText, string passPhrase)
        {
            
            var saltStringBytes = Generate128BitsOfEntropy();
            var ivStringBytes = Generate128BitsOfEntropy();
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            using (var password = new Rfc2898DeriveBytes(passPhrase, saltStringBytes, DerivationIterations))
            {
                var keyBytes = password.GetBytes(Keysize / 8);
                using (var symmetricKey = new RijndaelManaged())
                {
                    symmetricKey.BlockSize = 128;
                    symmetricKey.Mode = CipherMode.CBC;
                    symmetricKey.Padding = PaddingMode.PKCS7;
                    using (var encryptor = symmetricKey.CreateEncryptor(keyBytes, ivStringBytes))
                    {
                        using (var memoryStream = new MemoryStream())
                        {
                            using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                            {
                                cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                                cryptoStream.FlushFinalBlock();
                                var cipherTextBytes = saltStringBytes;
                                cipherTextBytes = cipherTextBytes.Concat(ivStringBytes).ToArray();
                                cipherTextBytes = cipherTextBytes.Concat(memoryStream.ToArray()).ToArray();
                                memoryStream.Close();
                                cryptoStream.Close();
                                return Convert.ToBase64String(cipherTextBytes);
                            }
                        }
                    }
                }
            }
        }


        string Decrypt(string cipherText, string passPhrase)
        {
            try
            {
                var cipherTextBytesWithSaltAndIv = Convert.FromBase64String(cipherText);
                var saltStringBytes = cipherTextBytesWithSaltAndIv.Take(Keysize / 8).ToArray();
                var ivStringBytes = cipherTextBytesWithSaltAndIv.Skip(Keysize / 8).Take(Keysize / 8).ToArray();
                var cipherTextBytes = cipherTextBytesWithSaltAndIv.Skip((Keysize / 8) * 2).Take(cipherTextBytesWithSaltAndIv.Length - ((Keysize / 8) * 2)).ToArray();
                using (var password = new Rfc2898DeriveBytes(passPhrase, saltStringBytes, DerivationIterations))
                {
                    var keyBytes = password.GetBytes(Keysize / 8);
                    using (var symmetricKey = new RijndaelManaged())
                    {
                        symmetricKey.BlockSize = 128;
                        symmetricKey.Mode = CipherMode.CBC;
                        symmetricKey.Padding = PaddingMode.PKCS7;
                        using (var decryptor = symmetricKey.CreateDecryptor(keyBytes, ivStringBytes))
                        {
                            using (var memoryStream = new MemoryStream(cipherTextBytes))
                            {
                                using (var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                                {
                                    var plainTextBytes = new byte[cipherTextBytes.Length];
                                    var decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
                                    memoryStream.Close();
                                    cryptoStream.Close();
                                    return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
                                }
                            }
                        }
                    }
                }
            }catch
            {
                MessageBox.Show("Sai Mat Khau","Canh Bao",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return cipherText;
            }
        }

      

        private void btChat_Click(object sender, EventArgs e)
        {
            Chat();
        }

        void Chat()
        {
            if(textBox1.Text!=string.Empty)
            {
                string content = "Server: " + textBox1.Text;
                string text = "0";
                text+=textBox1.Text;
                client.Send(Serialize(text));
                listView1.Items.Add(new ListViewItem(content));
                textBox1.Clear();
            }
            else
            {
                MessageBox.Show("Vui long nhap tin nhan", "Thong Bao", MessageBoxButtons.OK);
            }
        }

        private void btEncrypt_Click(object sender, EventArgs e)
        {
            string s = Encrypt(richTextBox1.Text, passWord);
            richTextBox1.Text = s;
            Send();
        }

        

        private void btDecrypt_Click(object sender, EventArgs e)
        {
            string s = Decrypt(richTextBox1.Text, passWord);
            richTextBox1.Text = s;
            Send();
        }
    }
}

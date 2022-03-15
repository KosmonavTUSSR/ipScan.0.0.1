using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ipScan
{

    public partial class Form1 : Form
    {
        //public string pathip = @"C:\Users\bnico\Desktop\d\1.txt";
        //public string tempFile = @"C:\Users\bnico\Desktop\d\temp.txt";
        //public string pathip = @"C:\Users\KosmonavT\Desktop\d\1.txt";
        //public string tempFile = @"C:\Users\KosmonavT\Desktop\d\temp.txt";
        public string pathip = Path.GetTempFileName();
        public string tempFile = Path.GetTempFileName();
        private string ipList;
        private string TempipList;
        //char[] ipChars;

        public Form1()
        {
            InitializeComponent();
        }
        public void start()
        {
            Process.Start("cmd", $"/K arp -a > {pathip} && exit").WaitForExit();
            ipList = File.ReadAllText(pathip, Encoding.GetEncoding(866));
            button2.Enabled = true; //Scam+
           
        }
        public void ClearCash()
        {
            if (checkBox1.Checked)
            {
                Process.Start("cmd", "/K netsh interface ip delete arpcache && exit");
            }
            if (checkBox2.Checked)
            {
                textBox1.Text = "";
            }
            if (checkBox3.Checked)
            {
                textBox2.Text = "";
            }
            comparison();
        }

        public void SaveStart()
        {
            Process.Start("cmd", $"/K arp -a > {tempFile} && exit").WaitForExit();
            if (File.Exists(tempFile))
            {
                TempipList = File.ReadAllText(tempFile, Encoding.GetEncoding(866));
            }
        }
        public void Clear()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            button2.Enabled = false;
        }
        public void comparison()
        {
            if (textBox1.Text == textBox2.Text)
            {
                label2.ForeColor = Color.LimeGreen;
                label2.Text = "Изменений не обнаружено";
            }
            else if (textBox2.Text == "")
            {
                label2.Text = "";
            }
            else
            {
                label2.ForeColor = Color.Red;
                label2.Text = "Данные не совпадают!";
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
           if(File.Exists(pathip)) {
            File.Delete(pathip);
           }
           if(File.Exists(tempFile)) {
                File.Delete(tempFile);

            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            start();
            button3.Enabled = true; //Clear
            button4.Visible = true; //RIPCash
            textBox1.Text = ipList;
            if (File.Exists(tempFile))
            {
                comparison();
            }
            else
            { 
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            SaveStart();
            textBox2.Text = TempipList;
            if (File.Exists(tempFile))
            {
                comparison();
            }
            else
            {
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Clear();
            label2.Text = "";
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void button4_Click(object sender, EventArgs e)
        {
            ClearCash();
        }
    }
}

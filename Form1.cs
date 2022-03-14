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
        public string pathip = @"C:\Users\bnico\Desktop\d\1.txt";
        public string tempFile = @"C:\Users\bnico\Desktop\d\temp.txt";
        //public string pathip = @"C:\Users\KosmonavT\Desktop\d\1.txt";
        //public string tempFile = @"C:\Users\bnico\Desktop\d\temp.txt";
        private string ipList;
        private string TempipList;

        public Form1()
        {
            InitializeComponent();
        }
        public void start()
        {
            Process.Start("cmd", "/K netsh interface ip delete arpcache && exit");
            Process.Start("cmd", $"/K arp -a > {pathip} && exit && echo Список устройств > {pathip}");
            ipList = File.ReadAllText(pathip, Encoding.GetEncoding(866));
        }
        public void SaveStart()
        {
            Process.Start("cmd", $"/K arp -a > {tempFile} && exit");
            TempipList = File.ReadAllText(tempFile, Encoding.GetEncoding(866));
        }
        public void Clear()
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }
        private void Form1_Load(object sender, EventArgs e)
        {
           // if(File.Exists(pathip)) {
           //
           //     File.Delete(pathip);
           //
           // }
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            start();
            button2.Visible = true;
            button3.Enabled = true;
            textBox1.Text = ipList;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveStart();
            textBox2.Text = TempipList;
          
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Clear();
        }
    }
}

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
        //public string pathip = Path.GetTempFileName();
        public string tempFile = Path.GetTempFileName();
        public string ipList;
        private string ipListSec;

        public Form1()
        {
            InitializeComponent();
        }
        public void start()
        {
            Process scan = new Process();
            scan.StartInfo.FileName = "arp";
            scan.StartInfo.Arguments = "-a";
            scan.StartInfo.RedirectStandardOutput = true;
            scan.StartInfo.UseShellExecute = false;
            scan.StartInfo.StandardOutputEncoding = Encoding.GetEncoding(866);
            scan.Start();
            ipList = scan.StandardOutput.ReadToEnd();

            button2.Enabled = true; //Scam+
        }
        public void ClearCash()
        {
            if (checkBox1.Checked)
            {
                Process clear = new Process();
                clear.StartInfo.FileName = "netsh";
                clear.StartInfo.UseShellExecute = false;
                clear.StartInfo.Arguments = "interface ip delete arpcache";
                clear.Start();
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
            Process process = new Process();
            process.StartInfo.FileName = "arp";
            process.StartInfo.Arguments = "-a";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.StandardOutputEncoding = Encoding.GetEncoding(866);
            process.StartInfo.RedirectStandardOutput = true;
            process.Start();
            ipListSec = process.StandardOutput.ReadToEnd();
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
        private void button1_Click(object sender, EventArgs e)
        {
            start();
            button3.Enabled = true; //Clear
            button4.Visible = true; //RIPCash
            textBox1.Text = ipList;
            comparison();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            SaveStart();
            textBox2.Text = ipListSec;
            comparison();
           
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Clear();
            label2.Text = "Данные удалены";
        }
        private void button4_Click(object sender, EventArgs e)
        {
            ClearCash();
        }
        // Cкролбары
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Size sz = TextRenderer.MeasureText(textBox1.Text, Font);
            if (sz.Height > textBox1.Height)
            {
                textBox1.ScrollBars = ScrollBars.Vertical;
            }else
            {
                textBox1.ScrollBars = ScrollBars.None;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            Size sz = TextRenderer.MeasureText(textBox2.Text, Font);
            if (sz.Height > textBox1.Height)
            {
                textBox2.ScrollBars = ScrollBars.Vertical;
            }
            else
            {
                textBox2.ScrollBars = ScrollBars.None;
            }
        }
       
        private void TextBox1_DragDrop(object sender, DragEventArgs e)
        {
            {
                if (e.Data.GetDataPresent(DataFormats.Text))
                    e.Effect = DragDropEffects.Copy;
                else
                    e.Effect = DragDropEffects.None;
            }
        }
    }
}

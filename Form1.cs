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
            textBox1.Text = ipList;
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
            textBox2.Text = ipListSec;
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
            comparison();
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            SaveStart();
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
        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                DialogResult result = MessageBox.Show("Ваш результат будет сохранен в файл", "Сохранение",
                    MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    File.Exists($@"C:\Users\{Environment.UserName}\Desktop\ipList.txt");
                    if (File.Exists($@"C:\Users\{Environment.UserName}\Desktop\ipList.txt"))
                    {
                        DialogResult result2 = MessageBox.Show("ipList.txt уже существует \n Заменить?", "Сохранение",
                             MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (result2 == DialogResult.Yes)
                        {
                            File.WriteAllText($@"C:\Users\{Environment.UserName}\Desktop\ipList.txt", textBox1.Text + textBox2.Text);
                        }
                        else { }
                    }
                    else
                    {
                        File.WriteAllText($@"C:\Users\{Environment.UserName}\Desktop\ipList.txt", textBox1.Text + textBox2.Text);
                    }
                }
                
            }
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

        private void Form1_Load(object sender, EventArgs e)
        {
            start();
        }
    }
}

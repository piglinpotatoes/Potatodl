using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Potatodl
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var billy = new OpenFileDialog();
            billy.ShowDialog();
            if (File.Exists(billy.FileName))
                textBox1.Text = File.ReadAllText(billy.FileName);
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.headers = textBox1.Text;
            Properties.Settings.Default.Save();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            textBox1.Text = Properties.Settings.Default.headers;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedItem)
            {
                case "Google Chrome on Windows":
                    textBox1.Text = "";
                    textBox1.AppendText("User-Agent: Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/109.0.0.0 Safari/537.36\nAccept:text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9");
                    break;
                case "Firefox on Windows":
                    textBox1.Text = "User-Agent: Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:108.0) Gecko/20100101 Firefox/108.0\n";
                    break;
            }
        }
    }
}

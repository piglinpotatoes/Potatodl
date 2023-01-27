using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Potatodl
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static string bfhbf;

        private void button1_Click(object sender, EventArgs e)
        {
            var Webs = new System.Net.WebClient();
            if (Properties.Settings.Default.headers.Contains("\n"))
            {
                foreach (string xz in Properties.Settings.Default.headers.Split('\n'))
                {
                    if (!string.IsNullOrWhiteSpace(xz))
                        Webs.Headers.Add(xz);
                }
            }

            try 
            {
                File.WriteAllBytes(textBox2.Text, Webs.DownloadData(textBox1.Text));
                DialogResult blbl;
                if (checkBox1.Checked)
                    blbl = DialogResult.Yes;
                else
                    blbl = MessageBox.Show($"{textBox1.Text}'s contents have been saved to {textBox2.Text}. Open the file?", "Complete", MessageBoxButtons.YesNo);

                if (blbl == DialogResult.Yes)
                    Process.Start("cmd.exe", "/c \"" + textBox2.Text + "\"");
            }
            catch (Exception Ex)
            {
                MessageBox.Show("oh no, " + Ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var Debs = new SaveFileDialog();
            Debs.Title = "Download to";
            Debs.Filter = "html files (*.html)|*.html|txt files (*.txt)|*.txt|png files (*.png)|*.png|other files (*.*)|*.*";
            Debs.ShowDialog();
            textBox2.Text = Debs.FileName;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bfhbf = textBox1.Text;
            new Form2().Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new Form3().Show();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.always = checkBox1.Checked;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            checkBox1.Checked = Properties.Settings.Default.always;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Save();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            bfhbf = textBox1.Text;
            new Form4().Show();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new Form5().Show();
        }
    }
}

using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using Microsoft.Toolkit.Uwp.Notifications;

namespace Potatodl
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        Thread childThread;

        private void Form4_Load(object sender, EventArgs e)
        {
            label2.Text = "Download " + Form1.bfhbf + "\nto:";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var Debs = new SaveFileDialog();
            Debs.Title = "Download to";
            Debs.Filter = "html files (*.html)|*.html|txt files (*.txt)|*.txt|png files (*.png)|*.png|other files (*.*)|*.*";
            Debs.ShowDialog();
            textBox1.Text = Debs.FileName;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (numericUpDown1.Value == 0)
                MessageBox.Show("Must happen more than every 0 minutes");
            else if (button4.Text == "Stop")
            {
                childThread.Abort();
                button4.Text = "Start!";
                button4.BackgroundImage = Properties.Resources._5rtt;
            }
            else
            {
                var childref = new ThreadStart(Downloard);
                childThread = new Thread(childref);
                childThread.Start();
                button4.Text = "Stop";
                button4.BackgroundImage = Properties.Resources._6rrt;
            }
        }

        private void Downloard()
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
            var hting = 0;
            string folder;
            string fileName;
            string extension;
            for (; ; )
            {
                try
                {
                    if (!checkBox1.Checked)
                    {
                        File.WriteAllBytes(textBox1.Text, Webs.DownloadData(Form1.bfhbf));
                        new ToastContentBuilder()
                            .AddText($"Downloaded {Form1.bfhbf} to {textBox1.Text}")
                            .AddAttributionText("via Potatodownload")
                            .Show();
                    }
                    else
                    {
                        folder = Path.GetDirectoryName(textBox1.Text);
                        fileName = Path.GetFileNameWithoutExtension(textBox1.Text);
                        extension = Path.GetExtension(textBox1.Text);
                        File.WriteAllBytes(Path.Combine(folder, $"{fileName}{hting++}{extension}"), Webs.DownloadData(Form1.bfhbf));
                        new ToastContentBuilder()
                            .AddText("Downloaded " + Form1.bfhbf + " to " + Path.Combine(folder, $"{fileName}{hting}{extension}"))
                            .AddAttributionText("via Potatodownload")
                            .Show();
                    }
                    Thread.Sleep(Convert.ToInt32(numericUpDown1.Value) * 60000);
                }
                catch (Exception Ex)
                {
                    MessageBox.Show("oh no, " + Ex.Message);
                    return;
                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new Form5().Show();
        }
    }
}

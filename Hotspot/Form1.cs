/*
    Developer : Gurbaksh Singh Gabbi
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Hotspot
{
    public partial class Form1 : Form
    {
        string c="start";
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string t1 = textBox1.Text;
            string t2 = textBox2.Text;
            if(t1==null||t1.Length==0||t1=="")
            {
                label3.Text="Please Specify Hotspot Name";
            }
            else if (t2.Length < 8)
            {
                label3.Text = "Password length must be greater than 8";
            }
            else
            {
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                startInfo.FileName = "cmd.exe";
                startInfo.Arguments = "/C netsh wlan set hostednetwork mode=allow ssid="+t1+" key="+t2+" & netsh wlan "+c+" hostednetwork";
                startInfo.Verb = "runas";
                process.StartInfo = startInfo;
                process.Start();
                
                if (c.Equals("start"))
                {
                    button1.Text = "Stop Hotspot";
                    label3.Text = "Hotspot Started";
                    c = "stop";
                }
                else
                {
                    button1.Text = "Start Hotspot";
                    label3.Text = "Hotspot Stopped";
                    c = "start";
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SerialPortConverter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Thread t;
        bool ozan = true;
        private void button1_Click(object sender, EventArgs e)
        {
            
            ComSettings.PortName = "COM4";
            ComSettings.Open();
            //t = new Thread(thread01);
            //t.Start();
            listBox1.Items.Add("Açıldı");

        }

        void thread01()
        {
            while (ozan)
            {
                try
                {
                    System.IO.FileStream fs = new System.IO.FileStream(@"C:\GameData.txt",System.IO.FileMode.Append);
                    
                    
                }
                catch (Exception)
                {


                }
                ComSettings.DataList.Clear();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            //t.Abort();
            ComSettings.Close();
            listBox1.Items.Add("Kapatıldı");
            ozan = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ComSettings.DataList.Clear();
        }
    }
}

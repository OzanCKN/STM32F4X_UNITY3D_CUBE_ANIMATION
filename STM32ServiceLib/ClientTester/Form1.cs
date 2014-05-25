using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClientTester.GameService;
namespace ClientTester
{
    public partial class Form1 : Form
    {
        GameService.Service1Client sc = new GameService.Service1Client();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bağlanıldı");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (sc.OpenCom())
            {
                listBox2.Items.Add("Seri Port okuması aktifleştirildi");
            }
            else
                listBox2.Items.Add("Seriport okuma başlatılamadı");
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (sc.CloseCom())
            {
                listBox2.Items.Add("Seri Port okuması kapatıldı..");
            }
            else
                listBox2.Items.Add("Seriport okuma kapatılamadı..");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (sc.ClearData())
            {
                listBox2.Items.Add("Seri Port dataları temizlendi.");
            }
            else
                listBox2.Items.Add("Seriport dataları temizlenemedi..");

        }

        private void button5_Click(object sender, EventArgs e)
        {
            //List<string> list = sc.GetData().ToList<string>();
            //foreach (string item in list)
            //{
            //    listBox1.Items.Add(item);
            //}
            string[] s = sc.GetData();
            System.IO.File.WriteAllLines(@"C:\GameData.txt", s);
        }
    }
}

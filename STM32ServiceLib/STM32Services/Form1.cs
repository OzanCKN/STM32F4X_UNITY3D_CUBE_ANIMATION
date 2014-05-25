using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using STM32ServiceLib;
using System.ServiceModel;
using System.Configuration;
namespace STM32Services
{
    public partial class Form1 : Form
    {

        ServiceHost hizmetSunucusu;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (comboBox1.Text != string.Empty)
            {
                STM32ServiceLib.ComSettings.PortName = comboBox1.Text;
                hizmetSunucusu = new ServiceHost(typeof(Service1));
                hizmetSunucusu.Opening += hizmetSunucusu_Opening;
                hizmetSunucusu.Opened += hizmetSunucusu_Opened;
                hizmetSunucusu.Closing += hizmetSunucusu_Closing;
                hizmetSunucusu.Closed += hizmetSunucusu_Closed;
                hizmetSunucusu.Open();
                
                listBox1.Items.Add("Oyun Servisi Şuan Açıldı");
            }
            else
                MessageBox.Show("Port seç !");
        }

        void hizmetSunucusu_Closed(object sender, EventArgs e)
        {
            listBox1.Items.Add("Oyun servisi kapatıldı.");
        }

        void hizmetSunucusu_Closing(object sender, EventArgs e)
        {
            listBox1.Items.Add("Servis Kapatılıyor...");
        }

        void hizmetSunucusu_Opened(object sender, EventArgs e)
        {
            listBox1.Items.Add("Oyun Sunucusu Aktif");
            textBox1.Text = "http://localhost:8733/GameServices/";

        }

        void hizmetSunucusu_Opening(object sender, EventArgs e)
        {
            listBox1.Items.Add("Servis açılıyor...");
        }

        void FillComPorts()
        {
            comboBox1.Items.Clear();
            string[] portlar = SerialPort.GetPortNames();  // portları dizi halinde aldık
            foreach (string port in portlar)
            {
                comboBox1.Items.Add(port.ToString()); // Portlarımızı combobox ın içine aldık.
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FillComPorts();
            CheckForIllegalCrossThreadCalls = false; //çapraz çalışmaya izin veriyoruz

        }

        private void button2_Click(object sender, EventArgs e)
        {
            hizmetSunucusu.Close();
        }

        private void comboBox1_MouseClick(object sender, MouseEventArgs e)
        {
            FillComPorts();
        }


    }
}

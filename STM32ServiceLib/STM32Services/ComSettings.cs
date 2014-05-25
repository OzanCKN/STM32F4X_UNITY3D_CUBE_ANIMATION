using System;
using System.Collections.Generic;
using System.Text;
using System.IO.Ports;

namespace STM32ServiceLib
{
    public static class ComSettings
    {
        public static SerialPort serialPort1 { get; set; }
        public static string PortName { get; set; }
        public static List<string> DataList = new List<string>();
        public static bool ClearDataList()
        {
            DataList = new List<string>();
            return true;
        }
        public static bool Open()
        {
            if (serialPort1 == null)
                serialPort1 = new SerialPort();


            if (!serialPort1.IsOpen)
            {
                serialPort1.BaudRate = int.Parse("9600");
                serialPort1.DataBits = int.Parse("8");
                serialPort1.StopBits = System.IO.Ports.StopBits.One;
                serialPort1.Parity = Parity.None;
                serialPort1.PortName = PortName;
                serialPort1.Open();
                serialPort1.DataReceived += DReceived;
                return true;
            }
            else
                return false;
        }

        static void DReceived(object sender, SerialDataReceivedEventArgs e)
        {
            byte[] buffer;
            buffer = new byte[10];  // 

            string mesaj = serialPort1.ReadLine();
            DataList.Add(mesaj);
        }

        public static bool Close()
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.Close();
                return true;
            }


            return false;

        }
    }
}

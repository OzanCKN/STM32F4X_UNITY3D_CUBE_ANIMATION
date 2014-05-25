using System;
using System.Collections.Generic;

using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.IO.Ports;
namespace STM32ServiceLib
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
        SerialPort serialPort1 = new SerialPort();

        public List<string> GetData()
        {
            STM32Services.Form1.listBox2.Items.Add(string.Format("Data Gönderildi {0}", ComSettings.DataList.Count));
            return ComSettings.DataList;
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }


        public bool OpenCom()
        {
            if (ComSettings.Open())
                return true;

            return false;

        }

        public bool ClearData()
        {
            if (ComSettings.ClearDataList())
                return true;

            return false;

        }

        public bool CloseCom()
        {
            if (ComSettings.Close())
            {
                return true;
            }
            return false;
        }
    }
}

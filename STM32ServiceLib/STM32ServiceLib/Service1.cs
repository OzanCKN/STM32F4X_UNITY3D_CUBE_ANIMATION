using System;
using System.Collections.Generic;
using System.Linq;
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

        public string GetData(int value)
        {
            if (serialPort1.IsOpen)
            {
                return null;
            }
            else
            {
                try
                {
                    serialPort1.BaudRate = int.Parse("9600");
                    serialPort1.DataBits = int.Parse("8");
                    serialPort1.StopBits = System.IO.Ports.StopBits.One;
                    serialPort1.Parity = Parity.None;
                    serialPort1.PortName = ComSettings.PortName;
                    serialPort1.Open();

                    return "";
                }
                catch (Exception)
                {
                    return null;
                }
            }

            return string.Format("You entered: {0}", value);
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
    }
}

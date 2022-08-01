using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WcfTcpClient.ServiceReference1;
using System.ServiceModel;

namespace WcfTcpClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Service1Client wcfClient =
        new Service1Client(
                              new NetTcpBinding(SecurityMode.None),
                              new EndpointAddress(
                                     "net.tcp://localhost:8000/Service1"
                                        ));
            var retstr = wcfClient.GetData(456);
            Console.WriteLine("GetData returns: " + retstr);
            CompositeType obj = new CompositeType();
            obj.BoolValue = true;
            obj.StringValue = "Hello WCF TCP client!";
            CompositeType objret = wcfClient.GetDataUsingDataContract(obj);
            Console.WriteLine("GetDataUsingDataContract returns: " + objret.StringValue);
            Console.ReadLine();
            wcfClient.Close();
        }
    }
}
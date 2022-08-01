// See https://aka.ms/new-console-template for more information
using ServiceReference2;

class Program
{
    static void Main(string[] args)
    {
        // For production apps, you can load the binding information from config
        // For this demo, we have defined the binding in code
        ServiceClient wcfClient1 =
                            new ServiceClient(ServiceClient.EndpointConfiguration.BasicHttpBinding_IService);

        // Invoke async operation on the service
        var retstr = wcfClient1.GetDataAsyncAsync(456);

        Console.WriteLine("GetData returns: " + retstr.Result.ToString());

        //Invoke operation passing in a composite type
        CompositeType obj = new CompositeType();
        obj.BoolValue = true;
        obj.StringValue = "Hello WCF TCP client!";

        var objret = wcfClient1.GetDataUsingDataContractAsync(obj).Result;

        Console.WriteLine("GetDataUsingDataContract returns: " + objret.StringValue);

        Console.ReadLine();


    }
}
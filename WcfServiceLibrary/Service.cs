using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using CoreWCF;

namespace WcfServiceLibrary
{
    
    public class Service : IService
    {
        public async Task<string> logData(string message)
        {
            var logger = await CloudWatchLogger.GetLoggerAsync("/dotnet/corewcfdemo");
           
            await logger.LogMessageAsync(string.Format("Core WCF Message {0}", message));
           
            return "Successfully created cloudwatch log";
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }

            if (composite.BoolValue)
            {
                composite.StringValue += "from WCF service hosted in Windows container";
            }

            return composite;
        }

        string IService.GetDataAsync(int value)
        {
            try
            {
                _ = logData("Entering GetDataAsync method").Result;

                return string.Format("You entered: {0}", value);
            }
            catch (Exception ex)
            {
                _ = logData(ex.Message.ToString());

                return null;
            }
        }

    }
}
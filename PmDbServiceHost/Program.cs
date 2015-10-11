using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace PmDbServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost dbServiceHost = null;
            try
            {
                //Base Address for StudentService
                Uri httpBaseAddress = new Uri("http://localhost:8733/Design_Time_Addresses/PMDbService");
                
                //Instantiate ServiceHost
                dbServiceHost = new ServiceHost(typeof(PMDbService.PmDbServiceImpl),
                    httpBaseAddress);
 
                //Add Endpoint to Host
                dbServiceHost.AddServiceEndpoint(typeof(PMDbService.IUserService), 
                                                        new WSHttpBinding(), "");            
 
                //Metadata Exchange
                ServiceMetadataBehavior serviceBehavior = new ServiceMetadataBehavior();
                serviceBehavior.HttpGetEnabled = true;
                dbServiceHost.Description.Behaviors.Add(serviceBehavior);

                //Open
                dbServiceHost.Open();
                Console.WriteLine("Service is live now at : {0}", httpBaseAddress);
                Console.ReadKey();                
            }

            catch (Exception ex)
            {
                dbServiceHost = null;
                Console.WriteLine("There is an issue with StudentService" + ex.Message);
            }
        }
    }
}

using Cookie_listener.Services;
using System.ServiceProcess;
using System.Threading;
using System.Threading.Tasks;

namespace Cookie_listener
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
       
     
        static void Main()
        {
            ServiceBase[] ServicesToRun = new ServiceBase[]
            {
                new Cookies_Listener()            
            };
            ServiceBase.Run(ServicesToRun);                      
        }
    }
}

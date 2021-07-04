using System;
using System.Diagnostics;
using System.ServiceProcess;
using System.Threading;
using System.Threading.Tasks;

namespace Cookie_listener
{
    partial class Service_fo_Opera : ServiceBase
    {
        Logger_fo_Opera _logger;
        public Service_fo_Opera()
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
                    _logger = new Logger_fo_Opera();
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

using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management;
using System.ServiceProcess;
using System.Threading;
using System.Threading.Tasks;

namespace Cookie_listener
{
    partial class Service_fo_Opera : ServiceBase
    {
        private FileSystemWatcher _watcher;
        private bool _enabled;
        public Service_fo_Opera()
        {
            InitializeComponent();
            CanStop = true;
            CanShutdown = true;
            CanPauseAndContinue = true;
            AutoLog = true;
        }

        protected override void OnStart(string[] args) => Task.Run(() => Go());
        public void Go()
        {
            lock (this)
            {
                try
                {
                    string _path_to_cookie = $@"C:\Users\{Get_User_Name()}\AppData\Roaming\Opera Software\Opera Stable";
                  
                     _watcher = new FileSystemWatcher(_path_to_cookie); // тут мы укажем то за чем мы следим   
                     _enabled = true;
                    EventLog.WriteEntry(_path_to_cookie);
                    _watcher.Deleted += Watcher_Deleted;
                    _watcher.Created += Watcher_Created;
                    _watcher.Changed += Watcher_Changed;
                    _watcher.Renamed += Watcher_Renamed;
                    try
                    {
                        _watcher.EnableRaisingEvents = true;
                        while (_enabled)
                        {
                            Thread.Sleep(1000);
                        }
                    }
                    catch (Exception ex) { RecordEntry("ошибка : ", ex.Message); }

                }
                catch (Exception ex) { EventLog.WriteEntry(ex.Message); }
            }
        }


        // переименование файлов
        private void Watcher_Renamed(object sender, RenamedEventArgs e)
        {
            string fileEvent = "переименован в " + e.FullPath;
            string filePath = e.OldFullPath;
            RecordEntry(fileEvent, filePath);
        }
        // изменение файлов
        private void Watcher_Changed(object sender, FileSystemEventArgs e)
        {
            string fileEvent = "изменен";
            string filePath = e.FullPath;
            RecordEntry(fileEvent, filePath);
        }
        // создание файлов
        private void Watcher_Created(object sender, FileSystemEventArgs e)
        {
            string fileEvent = "создан";
            string filePath = e.FullPath;
            RecordEntry(fileEvent, filePath);
        }
        // удаление файлов
        private void Watcher_Deleted(object sender, FileSystemEventArgs e)
        {
            string fileEvent = "удален";
            string filePath = e.FullPath;
            RecordEntry(fileEvent, filePath);
        }

        public string Get_User_Name()
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT UserName FROM Win32_ComputerSystem");
            ManagementObjectCollection collection = searcher.Get();
            return collection.Cast<ManagementBaseObject>().First()["UserName"].ToString().Split('\\')[1].Split('-').Last();
        }

        // запись в лог
        private void RecordEntry(string fileEvent, string filePath)
        {
            string _name_log_file = @"\log_fo_Opera.txt";
            using (StreamWriter writer = new StreamWriter($@"C:\Users\{Get_User_Name()}\Desktop" + _name_log_file, true))
            {
                EventLog.WriteEntry($@"C:\Users\{Get_User_Name()}\Desktop" + _name_log_file);
                writer.WriteLine(String.Format("{0} файл {1} был {2}",
                    DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"), filePath, fileEvent));
                writer.Flush();
            }
        }

        protected override void OnStop()
        {
            _watcher.EnableRaisingEvents = false;
            _enabled = false;
        }

    }
}

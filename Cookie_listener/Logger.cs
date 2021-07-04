using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management;
using System.Threading;


namespace Cookie_listener
{
    public abstract class logger
    {
        public string _path_to_cookie;
        public string _name_log_file;
        public FileSystemWatcher _watcher;
        public object _obj;
        public bool _enabled;

        public logger()
        {          
            _watcher.Deleted += Watcher_Deleted;
            _watcher.Created += Watcher_Created;
            _watcher.Changed += Watcher_Changed;
            _watcher.Renamed += Watcher_Renamed;
        }

        public void Start()
        {
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
        public void Stop()
        {
            try
            {
            _watcher.EnableRaisingEvents = false;
            _enabled = false;
            }
            catch (Exception ex)
            {
                using (EventLog log = new EventLog())
                {
                    log.WriteEntry(ex.Message);
                }
                throw ex;
               
                

               
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
        // запись в лог
        private void RecordEntry(string fileEvent, string filePath)
        {
            lock (_obj)
            {
                using (StreamWriter writer = new StreamWriter($@"C:\Users\{Get_User_Name()}\Desktop" + _name_log_file, true))
                {

                    using (EventLog log = new EventLog())
                    {
                        log.WriteEntry($@"C:\Users\{Get_User_Name()}\Desktop" + _name_log_file);
                    }

                    writer.WriteLine(String.Format("{0} файл {1} был {2}",
                        DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"), filePath, fileEvent));
                    writer.Flush();
                }
            }
        }
        //получить имя пользователя
        public string Get_User_Name()
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT UserName FROM Win32_ComputerSystem");
            ManagementObjectCollection collection = searcher.Get();
            return  collection.Cast<ManagementBaseObject>().First()["UserName"].ToString().Split('\\')[1].Split('-').Last();
        }
    }
    public class Logger_fo_Chrome : logger
    {     
       public Logger_fo_Chrome()
        {
            _obj = new object();
            _enabled = true;
            // создаем имя и разшерение для файла лога
            _name_log_file = @"\log_fo_Chrome.txt";
            // адрес папки с куки
            _path_to_cookie += $@" C:\Users\{Get_User_Name()}\AppData\Local\Google\Chrome\User Data\Default";

            using (EventLog log = new EventLog())
            {
                log.WriteEntry(_path_to_cookie);
            }

            _watcher = new FileSystemWatcher( _path_to_cookie); // тут мы укажем то за чем мы следим           
        }       
    }
   
    public class Logger_fo_FireFoxe : logger
    {
       // C:\Users\Laptop\AppData\Roaming\
        public Logger_fo_FireFoxe()
        {
            _obj = new object();
            _enabled = true;
            // создаем имя и разшерение для файла лога
            _name_log_file = @"\log_fo_FireFoxe.txt";
            // адрес папки с куки
            _path_to_cookie += $@"C:\Users\{Get_User_Name()}\AppData\Roaming\Mozilla\Firefox\Profiles\o54idzvf.default-release";

            using (EventLog log = new EventLog())
            {
                log.WriteEntry(_path_to_cookie);
            }

            _watcher = new FileSystemWatcher(_path_to_cookie); // тут мы укажем то за чем мы следим           
        }
    }

    public class Logger_fo_Opera : logger
    {
        public Logger_fo_Opera()
        {
            _obj = new object();
            _enabled = true;
            // создаем имя и разшерение для файла лога
            _name_log_file = @"\log_fo_Opera.txt";
            // адрес папки с куки
            _path_to_cookie += $@"C:\Users\{Get_User_Name()}\AppData\Roaming\Opera Software\Opera Stable";

            using (EventLog log = new EventLog())
            {
                log.WriteEntry(_path_to_cookie);
            }
            _watcher = new FileSystemWatcher(_path_to_cookie); // тут мы укажем то за чем мы следим           
        }
    }
}

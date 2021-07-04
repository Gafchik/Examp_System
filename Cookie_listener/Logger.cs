using System;
using System.IO;
using System.Threading;

namespace Cookie_listener
{
    public abstract class logger
    {
        public string _path_to_cookie;
        public string _name_log_file;
        public FileSystemWatcher _watcher;
        public object _obj = new object();
        public bool _enabled = true;

        public logger()
        {
            _watcher.Deleted += Watcher_Deleted;
            _watcher.Created += Watcher_Created;
            _watcher.Changed += Watcher_Changed;
            _watcher.Renamed += Watcher_Renamed;
        }

        public void Start()
        {
            _watcher.EnableRaisingEvents = true;
            while (_enabled)
            {
                Thread.Sleep(1000);
            }
        }
        public void Stop()
        {
            _watcher.EnableRaisingEvents = false;
            _enabled = false;
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

        private void RecordEntry(string fileEvent, string filePath)
        {
            lock (_obj)
            {
                using (StreamWriter writer = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + _name_log_file, true))
                {
                    writer.WriteLine(String.Format("{0} файл {1} был {2}",
                        DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"), filePath, fileEvent));
                    writer.Flush();
                }
            }
        }

    }
    public class Logger_fo_Chrome : logger
    {     
       public Logger_fo_Chrome()
        {
            // создаем имя и разшерение для файла лога
            _name_log_file = "\\log_fo_Chrome.txt";
            // адрес папки с куки
            _path_to_cookie += "\\Google\\Chrome\\User Data\\Profile 39";
            _watcher = new FileSystemWatcher(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + _path_to_cookie); // тут мы укажем то за чем мы следим           
        }       
    }

    public class Logger_fo_FireFoxe : logger
    {
        public Logger_fo_FireFoxe()
        {
            // создаем имя и разшерение для файла лога
            _name_log_file = "\\log_fo_FireFoxe.txt";
            // адрес папки с куки
            _path_to_cookie += "\\Google\\Chrome\\User Data\\Profile 39";
            _watcher = new FileSystemWatcher(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + _path_to_cookie); // тут мы укажем то за чем мы следим           
        }
    }

    public class Logger_fo_Opera : logger
    {
        public Logger_fo_Opera()
        {
            // создаем имя и разшерение для файла лога
            _name_log_file = "\\log_fo_Opera.txt";
            // адрес папки с куки
            _path_to_cookie += "\\Google\\Chrome\\User Data\\Profile 39";
            _watcher = new FileSystemWatcher(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + _path_to_cookie); // тут мы укажем то за чем мы следим           
        }
    }
}

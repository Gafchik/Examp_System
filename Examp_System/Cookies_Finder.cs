using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examp_System
{
    public static class Cookies_Finder
    {
        private const int _count_path = 1;
        private static string _Chrome_cookiesDB_name = "Cookies";
        private static string _Opera_cookiesDB_name = "Cookies";
        private static string _FireFoxe_cookiesDB_name = "cookies.sqlite";

        private static string _path_to_Chrome = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Google\\Chrome\\User Data\\Default";
        private static string _path_to_Opera = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Opera Software\\Opera Stable";
        private static string _path_to_FireFoxe = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Mozilla\\Firefox\\Profiles";

        public static string Chrome_Cookies_Find()
        {          
              var _path_array=  Directory.GetFiles(_path_to_Chrome, _Chrome_cookiesDB_name, SearchOption.AllDirectories).ToList();
            if (_path_array.Count != _count_path)
                throw new Exception("Chrome : cookies not fond =(");
            return _path_array[0];
        }
        public static string FireFoxe_Cookies_Find()
        {
            var _path_array = Directory.GetFiles(_path_to_FireFoxe, _FireFoxe_cookiesDB_name, SearchOption.AllDirectories).ToList();
            if (_path_array.Count != _count_path)
                throw new Exception("FireFoxe : cookies not fond =(");
            return _path_array[0];
        }
        public static string Opera_Cookies_Find()
        {
            var _path_array = Directory.GetFiles(_path_to_Opera, _Opera_cookiesDB_name, SearchOption.AllDirectories).ToList();
            if (_path_array.Count != _count_path)
                throw new Exception("Opera : cookies not fond =(");
            return _path_array[0];
        }
    }
}

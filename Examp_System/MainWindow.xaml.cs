using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Examp_System
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string _path_fo_Opera;
        private string _path_fo_Chrome;
        private string _path_fo_FireFoxe;
        public MainWindow()
        {
            InitializeComponent();
            _path_fo_Chrome = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Google\\Chrome\\User Data\\Profile 39\\Cookies";
            _path_fo_Opera = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Opera Software\\Opera Stable\\Cookies";
            _path_fo_FireFoxe = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Mozilla\\Firefox\\Profiles\\zvivgqy3.default\\cookies.sqlite";
            _data_grid = new DataGrid();
            
        }

        private void Chrome_click(object sender, RoutedEventArgs e)
        {

        }
        private void Opera_click(object sender, RoutedEventArgs e)
        {

        }

        private void FireFox_click(object sender, RoutedEventArgs e)
        {

        }
       


    }
}

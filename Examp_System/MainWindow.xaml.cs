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
        public MainWindow()
        {
            InitializeComponent();
            _data_grid.AutoGenerateColumns = true;                                
        }

        private void Chrome_click(object sender, RoutedEventArgs e)
        {
            try { _data_grid.ItemsSource = Cookies_Finder.Table_Chrome_cookies(); }
            catch (Exception ex){ MessageBox.Show(ex.Message); }
        }
        private void Opera_click(object sender, RoutedEventArgs e)
        {
            try { _data_grid.ItemsSource = Cookies_Finder.Table_Opera_cookies(); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void FireFox_click(object sender, RoutedEventArgs e)
        {
            try { _data_grid.ItemsSource = Cookies_Finder.Table_FireFoxe_cookies(); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
       


    }
}

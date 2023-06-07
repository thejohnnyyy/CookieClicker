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
using System.Windows.Shapes;

namespace CookieClicker.Classes
{
    /// <summary>
    /// Interaction logic for MenuWindow.xaml
    /// </summary>
    public partial class MenuWindow : Window
    {
        MainWindow mainWindow;

        public MenuWindow()
        {
            InitializeComponent();
            MainWindow mainWindow = new MainWindow();
        }

        private void saveBTNMenu_Click(object sender, RoutedEventArgs e)
        {

        }

        private void loadBTNMenu_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

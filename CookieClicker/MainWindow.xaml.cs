using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Threading;

namespace CookieClicker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region INT
        int clickCntr = 0;

        int clickPower = 1;
        int ownedPower = 1;

        //INTS for Auto clicks
        int clickAuto1 = 0;
        int ownedAuto1 = 0;
        int clickAuto5 = 0;
        int ownedAuto5 = 0;
        int clickAuto10 = 0;
        int ownedAuto10 = 0;
        int clickAutoSum = 0;

        #endregion INT

        public MainWindow()
        {
            InitializeComponent();

            //Repeats Indefinetly clickAuto
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += clickAuto;
            timer.Start();
;
        }

        //Auto clicker every 1 sec
        private void clickAuto(object sender, EventArgs e)
        {
            clickAutoSum = clickAuto1 + clickAuto5 + clickAuto10;
            clickCounter.Text = clickCntr.ToString();
            clickCntr += clickAutoSum;

            Debug.WriteLine(clickCntr + "+" + clickAutoSum + "+" + clickPower);
        }

        //Cookie clicks
        private void imageBtn_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {

            clickCntr += clickPower;
            clickCounter.Text = clickCntr.ToString();

            //makes button bigger after making it smaller
            imageBtn.Width = 300;
            imageBtn.Height = 300;


        }
        //Makes button smaller for animation
        private void imageBtn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            imageBtn.Width = 270;
            imageBtn.Height = 270;

        }

        #region Upgrade 
        //Upgrades the power of a click, when clicking the cookie 
        private void powerUpgrade_Click(object sender, RoutedEventArgs e)
        {
            clickPower += 1;
            ownedPower++;
            ownerPower.Text = ownedPower.ToString();
        }

        //Idle clicking, gives clicks automaticly
        //P1 gives +1 to auto clicking. Same applies to all the AutoP# upgrades
        private void powerAutoP1_Click(object sender, RoutedEventArgs e)
        {
            clickAuto1++;
            ownedAuto1++;
            ownedP1.Text = ownedAuto1.ToString();
        }

        private void powerAutoP5_Click(object sender, RoutedEventArgs e)
        {
            clickAuto5 += 5;
            ownedAuto5++;
            ownedP5.Text = ownedAuto5.ToString();
        }

        private void powerAutoP10_Click(object sender, RoutedEventArgs e)
        {
            clickAuto10 += 10;
            ownedAuto10++;
            ownedP10.Text = ownedAuto10.ToString();
        }

        #endregion Upgrade

        #region Expander
        private void upgExp_Collapsed(object sender, RoutedEventArgs e)
        {
            upgExp.Background = new SolidColorBrush(Colors.Wheat);
            upgExp.BorderBrush.Opacity = 0;
        }

        private void upgExp_Expanded(object sender, RoutedEventArgs e)
        {
            upgExp.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFE6BF77"));
            upgExp.BorderBrush = new SolidColorBrush(Colors.Black);
        }


        #endregion Expander


    }
}

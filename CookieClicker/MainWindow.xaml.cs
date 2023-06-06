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
        
        int clickAutoSum = 0;

        #endregion INT

        Variables variables;

        public MainWindow()
        {
            InitializeComponent();
            variables = new Variables();

            //Repeats Indefinetly clickAuto every 1 sec
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += clickAuto;
            timer.Start();
;
        }

        //Auto clicker every 1 sec
        private void clickAuto(object sender, EventArgs e)
        {
            clickAutoSum = variables.ClickAuto1 + variables.ClickAuto5 + variables.ClickAuto10;
            clickCounter.Text = variables.ClickCntr.ToString();
            variables.ClickCntr += clickAutoSum;

            Debug.WriteLine(variables.ClickCntr + "+" + clickAutoSum + "+" + variables.ClickPower);
        }

        //Cookie clicks
        private void imageBtn_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {

            variables.ClickCntr += variables.ClickPower;
            clickCounter.Text = variables.ClickCntr.ToString();

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
            variables.ClickPower += 1;
            variables.OwnedPower++;
            ownerPower.Text = variables.OwnedPower.ToString();
        }

        //Idle clicking, gives clicks automaticly
        //P1 gives +1 to auto clicking. Same applies to all the AutoP# upgrades
        private void powerAutoP1_Click(object sender, RoutedEventArgs e)
        {
            variables.ClickAuto1++;
            variables.OwnedAuto1++;
            ownedP1.Text = variables.OwnedAuto1.ToString();
        }

        private void powerAutoP5_Click(object sender, RoutedEventArgs e)
        {
            variables.ClickAuto5 += 5;
            variables.OwnedAuto5++;
            ownedP5.Text = variables.OwnedAuto5.ToString();
        }

        private void powerAutoP10_Click(object sender, RoutedEventArgs e)
        {
            variables.ClickAuto10 += 10;
            variables.OwnedAuto10++;
            ownedP10.Text = variables.OwnedAuto10.ToString();
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

        public class Variables
        {
            private int clickCntr = 0;
            private int clickPower = 1;
            //Variables for Upgrades
            //ownedAuto is for text in xaml
            //clickAuto is for code
            private int ownedPower = 1;
            private int clickAuto1 = 0;
            private int ownedAuto1 = 0;
            private int clickAuto5 = 0;
            private int ownedAuto5 = 0;
            private int clickAuto10 = 0;
            private int ownedAuto10 = 0;

            public int ClickCntr { get { return clickCntr; } set { clickCntr = value; } }
            public int ClickPower { get { return clickPower;  } set { clickPower = value; } }

            public int OwnedPower { get => ownedPower; set => ownedPower = value; }
            public int ClickAuto1 { get => clickAuto1; set => clickAuto1 = value; }
            public int OwnedAuto1 { get => ownedAuto1; set => ownedAuto1 = value; }
            public int ClickAuto5 { get => clickAuto5; set => clickAuto5 = value; }
            public int OwnedAuto5 { get => ownedAuto5; set => ownedAuto5 = value; }
            public int ClickAuto10 { get => clickAuto10; set => clickAuto10 = value; }
            public int OwnedAuto10 { get => ownedAuto10; set => ownedAuto10 = value; }
        }
    }
}

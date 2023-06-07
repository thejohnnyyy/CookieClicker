using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
using System.Xml.Serialization;
using System.Xml;

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

        //cesta pro save
        string cesta = "saveFile.xml";

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


            if (variables.CostPower <= variables.ClickCntr)
            {
                variables.ClickCntr -= variables.CostPower;

                variables.CostPower *= 2;
                variables.ClickPower += 1;
                variables.OwnedPower++;
                costPower.Text = variables.CostPower.ToString();
                ownerPower.Text = variables.OwnedPower.ToString();
            }
            else { MessageBox.Show("nemuzes si dovolit upgrade", "Upgrade"); }
        }

        //Idle clicking, gives clicks automaticly
        //Px gives +x to auto clicking. Same applies to all the AutoP# upgrades
        private void powerAutoP1_Click(object sender, RoutedEventArgs e)
        {

            if (variables.CostAuto1 <= variables.ClickCntr)
            {
                variables.ClickCntr -= variables.CostAuto1;

                variables.ClickAuto1++;
                variables.OwnedAuto1++;
                variables.CostAuto1 *= 3;
                costP1.Text = variables.CostAuto1.ToString();
                ownedP1.Text = variables.OwnedAuto1.ToString();

                
            }
            else { MessageBox.Show("nemuzes si dovolit upgrade", "Upgrade"); } 
        }

        private void powerAutoP5_Click(object sender, RoutedEventArgs e)
        {

                if (variables.CostAuto5 <= variables.ClickCntr)
                {
                    variables.ClickCntr -= variables.CostAuto5;
                    variables.CostAuto5 *= 4;

                    variables.ClickAuto5 += 5;
                    variables.OwnedAuto5++;
                    ownedP5.Text = variables.OwnedAuto5.ToString();
                    costP5.Text = variables.CostAuto5.ToString();
                }
                else { MessageBox.Show("nemuzes si dovolit upgrade", "Upgrade"); }
        }

        private void powerAutoP10_Click(object sender, RoutedEventArgs e)
        {



            if (variables.CostAuto10 <= variables.ClickCntr)
            {
                variables.ClickCntr -= variables.CostAuto10;
                variables.CostAuto10 *= 5;

                variables.ClickAuto10 += 10;
                variables.OwnedAuto10++;
                ownedP10.Text = variables.OwnedAuto10.ToString();
                costP10.Text = variables.CostAuto10.ToString();
            }
            else { MessageBox.Show("Nemuzes si dovolit upgrade", "Upgrade"); }
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
            private Int64 clickCntr = 0;
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
            //cost
            private int costPower = 50;
            private int costAuto1 = 100;
            private int costAuto5 = 250;
            private int costAuto10 = 500;

            public Int64 ClickCntr { get => clickCntr; set => clickCntr = value; }
            public int ClickPower { get { return clickPower;  } set { clickPower = value; } }
            
            public int OwnedPower { get => ownedPower; set => ownedPower = value; }
            public int ClickAuto1 { get => clickAuto1; set => clickAuto1 = value; }
            public int OwnedAuto1 { get => ownedAuto1; set => ownedAuto1 = value; }
            public int ClickAuto5 { get => clickAuto5; set => clickAuto5 = value; }
            public int OwnedAuto5 { get => ownedAuto5; set => ownedAuto5 = value; }
            public int ClickAuto10 { get => clickAuto10; set => clickAuto10 = value; }
            public int OwnedAuto10 { get => ownedAuto10; set => ownedAuto10 = value; }
            //cost
            public int CostPower { get => costPower; set => costPower = value; }
            public int CostAuto1 { get => costAuto1; set => costAuto1 = value; }
            public int CostAuto5 { get => costAuto5; set => costAuto5 = value; }
            public int CostAuto10 { get => costAuto10; set => costAuto10 = value; }
        }

        #region SaveLoad
        //saving
        public void saveBTN_Click(object sender, RoutedEventArgs e)
        {
            UlozData();
            void UlozData()
            {
                XmlSerializer serializer = new XmlSerializer(variables.GetType());
                using (StreamWriter sw = new StreamWriter(cesta))
                {
                    serializer.Serialize(sw, variables);
                }
            }
        }

        //loading
        private void loadBTN_Click(object sender, RoutedEventArgs e)
        {
            NactiData();
            void NactiData()
            {
                XmlSerializer serializer = new XmlSerializer(variables.GetType());
                if (File.Exists(cesta))
                {
                    using (StreamReader sr = new StreamReader(cesta))
                    {
                        variables = (Variables)serializer.Deserialize(sr);
                    }

                    ownedP1.Text = variables.OwnedAuto1.ToString();
                    ownedP5.Text = variables.OwnedAuto5.ToString();
                    ownedP10.Text = variables.OwnedAuto10.ToString();

                }
                //error message, no saveFile.xml detected
                else
                {
                    MessageBox.Show("cesta nelze najit", "Error");
                }
            }
        }
        #endregion SaveLoad
    }
}

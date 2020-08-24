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

namespace Basic_Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private float ans, numb;
        private int type;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Click_1(object sender, RoutedEventArgs e)
        {
            textboxx.Text += "1";
        }

        private void Click_2(object sender, RoutedEventArgs e)
        {
            textboxx.Text += "2";
        }

        private void Click_3(object sender, RoutedEventArgs e)
        {
            textboxx.Text += "3";
        }

        private void Click_4(object sender, RoutedEventArgs e)
        {
            textboxx.Text += "4";
        }

        private void Click_5(object sender, RoutedEventArgs e)
        {
            textboxx.Text += "5";
        }

        private void Click_6(object sender, RoutedEventArgs e)
        {
            textboxx.Text += "6";
        }

        private void Click_7(object sender, RoutedEventArgs e)
        {
            textboxx.Text += "7";
        }

        private void Click_8(object sender, RoutedEventArgs e)
        {
            textboxx.Text += "8";
        }

        private void Click_9(object sender, RoutedEventArgs e)
        {
            textboxx.Text += "9";
        }

        private void Click_0(object sender, RoutedEventArgs e)
        {
            textboxx.Text += "0";
        }
        private void Click_dot(object sender, RoutedEventArgs e)
        {
            textboxx.Text += ".";
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            textboxx.Text = "";
        }


        private void Addition(object sender, RoutedEventArgs e)
        {
            numb = float.Parse(textboxx.Text);
            textboxx.Clear();
            textboxx.Focus();
            type = 1;
        }

        private void Subraction(object sender, RoutedEventArgs e)
        {
            numb = float.Parse(textboxx.Text);
            textboxx.Clear();
            textboxx.Focus();
            type = 2;
        }

        private void Multiply(object sender, RoutedEventArgs e)
        {
            numb = float.Parse(textboxx.Text);
            textboxx.Clear();
            textboxx.Focus();
            type = 3;
        }
        private void divison(object sender, RoutedEventArgs e)
        {
            numb = float.Parse(textboxx.Text);
            textboxx.Clear();
            textboxx.Focus();
            type = 4;
        }

        private void Equal(object sender, EventArgs e)
        {
            Compute(type);
        }
        public void Compute(int i)
        {
            switch (i)
            {
                case 1:
                    ans = numb + float.Parse(textboxx.Text);
                    textboxx.Text = ans.ToString();
                    break;
                case 2:
                    ans = numb - float.Parse(textboxx.Text);
                    textboxx.Text = ans.ToString();
                    break;
                case 3:
                    ans = numb * float.Parse(textboxx.Text);
                    textboxx.Text = ans.ToString();
                    break;
                case 4:
                    ans = numb / float.Parse(textboxx.Text);
                    textboxx.Text = ans.ToString();
                    break;
                default:
                    break;
            }
        }
    }
}

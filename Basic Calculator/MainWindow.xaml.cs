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
        public MainWindow()
        {
            InitializeComponent();
        }
        public bool operAtTheEnd = false;
        private float num1 = 0, num2 = 0, result;
        private int numOp = 0;
        private string CrOp;

        private void Draggable(object sender, RoutedEventArgs e) => this.DragMove();
        private void Close(object sender, RoutedEventArgs e) => this.Close();

        private void Btn_num(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            if (boxResult.Text.Length == 1 && boxResult.Text.IndexOf("0") == 0)
            {
                boxResult.Text = btn.Content.ToString();
            }
            else
            {
                boxResult.Text += btn.Content.ToString();
            }

            //test
            /*
            if(num1 == 0)
            {
                num1 = int.Parse(btn.Content.ToString());
            }
            else if (boxResult.Text.Contains("."))
            {
                num1 = num1 + 0.1F;
            }
            else
            {
                num1 = (num1 * 10) + int.Parse(btn.Content.ToString());
            }
            */
        }
        private void Btn_dot(object sender, RoutedEventArgs e)
        {
            if (!boxResult.Text.Contains("."))
            {
                boxResult.Text += ".";
            }
            
        }

        private void Operator(object sender, RoutedEventArgs e)
        {
            numOp += 1;
            Button oper = (Button)sender;
            OperAtEnd(oper.Content.ToString());
            if (numOp >= 2 && num2 == 0)
            {
                num2 = float.Parse(boxResult.Text);
            }
            if (num1 == 0)
            {
                num1 = float.Parse(boxResult.Text);
                CrOp = oper.Content.ToString();
            }
            
            if(numOp >= 2)
            {
                num1 = cal(num1, CrOp, num2);
                boxResult.Text = $"{num1}";
            }
        }

        private float cal(float x, string a, float y)
        {
            switch (a)
            {
                case "+":
                    result = x + y;
                    break;
                case "-":
                    result = x - y;
                    break;
                case "x":
                    result = x * y;
                    break;
                case "/":
                    result = x / y;
                    break;
                default:
                    break;
            }
            return result;
        }
        private void OperAtEnd(string x)
        {
            if(boxMain.Text == "" && boxResult.Text == "0")
            {

            }
            else if ((boxMain.Text.EndsWith("+") || boxMain.Text.EndsWith("-") || boxMain.Text.EndsWith("x") || boxMain.Text.EndsWith("/")) && boxResult.Text == "0")
            {
                boxMain.Text = boxMain.Text.Substring(0, boxMain.Text.Length - 1) + x;
            }
            else
            {
                boxMain.Text += $" {boxResult.Text} {x}";
               // boxResult.Text = "0";
            }
        }
        private void Btn_equal(object sender, RoutedEventArgs e)
        {
            boxMain.Text += boxResult.Text;
            /*
            int si = boxMain.Text.IndexOf("+");
            string a = boxMain.Text.Substring(0, si - 2);
            string o = boxMain.Text.Substring(si,si+1);
            string b = boxMain.Text.Substring(si + 3,si+4);

            switch (o)
            {
                case "+ " :
                    boxResult.Text = $"{float.Parse(a) + float.Parse(b)}";
                    break;
                case " -" :
                    boxResult.Text = $"{float.Parse(a) - float.Parse(b)}";
                    break;
                case " x":
                    boxResult.Text = $"{float.Parse(a) * float.Parse(b)}";
                    break;
                case " /":
                    boxResult.Text = $"{float.Parse(a) / float.Parse(b)}";
                    break;
                default:
                    boxResult.Text = "Error";
                    break;
            }
            */
        }

        private void Clear(object sender, RoutedEventArgs e)
        {
            num1 = 0;
            num2 = 0;
            result = 0;
            boxMain.Text = "";
            boxResult.Text = "0";
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            if (boxResult.Text.Length > 1)
            {
                boxResult.Text = boxResult.Text.Substring(0, boxResult.Text.Length - 1);
            }
            else
            {
                boxResult.Text = "0";
            }
        }

    }
}

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
        private int numOp = 0;
        private float TheResult = 0;
        private List<string> operStore = new List<string>();

        public MainWindow()
        {
            InitializeComponent();
        }

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
        }
        private void Btn_dot(object sender, RoutedEventArgs e)
        {
            if (!boxResult.Text.Contains("."))
            {
                boxResult.Text += ".";
            }
            
        }

        //Calculation logic
        private void Operator(object sender, RoutedEventArgs e)
        {
            Button oper = (Button)sender;
            string operClick = oper.Content.ToString();
            operStore.Add(operClick);
            OperAtEnd(operClick);

            if(numOp == 0)
            {
                TheResult = float.Parse(boxResult.Text);
            }

            if (numOp >= 1)
            {
                float num1 = float.Parse(boxResult.Text);
                TheResult = Cal(TheResult, operStore[numOp - 1], num1);
                boxResult.Text = $"{TheResult}";
            }
            numOp += 1;
        }
        private float Cal(float x, string a, float y)
        {
            float resu = 0;
            switch (a)
            {
                case "+":
                    resu = x + y;
                    break;
                case "-":
                    resu = x - y;
                    break;
                case "x":
                    resu = x * y;
                    break;
                case "/":
                    resu = x / y;
                    break;
                default:
                    boxResult.Text = "Error";
                    break;
            }
            return resu;
        }
        private void OperAtEnd(string x)
        {
            if (boxMain.Text == "" && boxResult.Text == "0")
            {

            }
            else if ((boxMain.Text.EndsWith("+") || boxMain.Text.EndsWith("-") || boxMain.Text.EndsWith("x") || boxMain.Text.EndsWith("/")) && boxResult.Text == "0")
            {
                boxMain.Text = boxMain.Text.Substring(0, boxMain.Text.Length - 1) + x;

            }
            else if (boxMain.Text.EndsWith(" "))
            {
                boxMain.Text = $"{TheResult} {x}";
            }
            else
            {
                boxMain.Text += $" {boxResult.Text} {x}";
            }
        }

        private void Btn_equal(object sender, RoutedEventArgs e)
        {
            float num1 = float.Parse(boxResult.Text);
            boxMain.Text += $" {boxResult.Text} ";
            TheResult = Cal(TheResult, operStore[numOp - 1], num1);
            boxResult.Text = $"{TheResult}";
        }

        private void Clear(object sender, RoutedEventArgs e)
        {
            numOp = 0;
            TheResult = 0;
            boxMain.Text = "";
            boxResult.Text = "0";
            operStore.Clear();
            InitializeComponent();
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

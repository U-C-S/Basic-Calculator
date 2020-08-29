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
                numOp -= 1;
                operStore[numOp] = x;
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
            if(numOp > 0)
            {
                float num1 = float.Parse(boxResult.Text);
                boxMain.Text += $" {boxResult.Text} ";
                TheResult = Cal(TheResult, operStore[numOp - 1], num1);
                boxResult.Text = $"{TheResult}";
            }
            else
            {
                boxResult.Text = boxResult.Text;
            }

            numOp = 0;
            TheResult = 0;
            boxMain.Text = "";
            operStore.Clear();
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



        /*
        private void UserLoad(object sender, RoutedEventArgs e)
        {
            var window = Window.GetWindow(this);
            window.KeyDown += Num1;
        }*/

        private void Num1(object sender, KeyEventArgs e)
        {
            switch(e.Key)
            {
                case Key.NumPad1:
                    PressedKey_Num("1");
                    break;
                case Key.NumPad2:
                    PressedKey_Num("2");
                    break;
                case Key.NumPad3:
                    PressedKey_Num("3");
                    break;
                case Key.NumPad4:
                    PressedKey_Num("4");
                    break;
                case Key.NumPad5:
                    PressedKey_Num("5");
                    break;
                case Key.NumPad6:
                    PressedKey_Num("6");
                    break;
                case Key.NumPad7:
                    PressedKey_Num("7");
                    break;
                case Key.NumPad8:
                    PressedKey_Num("8");
                    break;
                case Key.NumPad9:
                    PressedKey_Num("9");
                    break;
                case Key.NumPad0:
                    PressedKey_Num("0");
                    break;
                case Key.Decimal:
                    PressedKey_dot();
                    break;

                case Key.Back:
                    PressedKey_back();
                    break;
                case Key.X:
                    PressedKey_Clear();
                    break;
                case Key.Add:
                    PressedKey_Oper("+");
                    break;
                case Key.Subtract:
                    PressedKey_Oper("-");
                    break;
                case Key.Multiply:
                    PressedKey_Oper("*");
                    break;
                case Key.Divide:
                    PressedKey_Oper("+");
                    break;

            }
        }
        private void PressedKey_Num(string x)
        {
            if (boxResult.Text.Length == 1 && boxResult.Text.IndexOf("0") == 0)
            {
                boxResult.Text = x;
            }
            else
            {
                boxResult.Text += x;
            }
        }
        private void PressedKey_back()
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
        private void PressedKey_Clear()
        {
            numOp = 0;
            TheResult = 0;
            boxMain.Text = "";
            boxResult.Text = "0";
            operStore.Clear();
            InitializeComponent();
        }
        private void PressedKey_dot()
        {
            if (!boxResult.Text.Contains("."))
            {
                boxResult.Text += ".";
            }
        }
        private void PressedKey_Oper(string x)
        {
            operStore.Add(x);
            OperAtEnd(x);

            if (numOp == 0)
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
    }
}

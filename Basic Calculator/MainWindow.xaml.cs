using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Basic_Calculator
{
    public partial class MainWindow : Window
    {
        public MainWindow() => InitializeComponent();

        int numOp = 0;
        float TheResult = 0;
        List<string> operStore = new List<string>();
        bool resultShowing = false;

        //UI Events
        void Draggable(object sender, RoutedEventArgs e) => DragMove();
        void Close(object sender, RoutedEventArgs e) => Close();
        void Btn_num(object sender, RoutedEventArgs e) => NumberFunc((sender as Button).Content.ToString());
        void Btn_dot(object sender, RoutedEventArgs e) => DotCheck();
        void Operator(object sender, RoutedEventArgs e) => CheckandCal((sender as Button).Content.ToString());
        void Btn_equal(object sender, RoutedEventArgs e) => TheEnterKey();
        void Clear(object sender, RoutedEventArgs e) => ClearEverything();
        void Back(object sender, RoutedEventArgs e) => BackSpace();
        void Keyboard_press(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.NumPad1:
                case Key.D1:
                    NumberFunc("1"); break;
                case Key.NumPad2:
                case Key.D2:
                    NumberFunc("2"); break;
                case Key.NumPad3:
                case Key.D3:
                    NumberFunc("3"); break;
                case Key.NumPad4:
                case Key.D4:
                    NumberFunc("4"); break;
                case Key.NumPad5:
                case Key.D5:
                    NumberFunc("5"); break;
                case Key.NumPad6:
                case Key.D6:
                    NumberFunc("6"); break;
                case Key.NumPad7:
                case Key.D7:
                    NumberFunc("7"); break;
                case Key.NumPad8:
                case Key.D8:
                    NumberFunc("8"); break;
                case Key.NumPad9:
                case Key.D9:
                    NumberFunc("9"); break;
                case Key.NumPad0:
                case Key.D0:
                    NumberFunc("0"); break;

                case Key.Decimal: DotCheck(); break;
                case Key.Enter: TheEnterKey(); break;
                case Key.Back: BackSpace(); break;
                case Key.X: ClearEverything(); break;

                case Key.Add: CheckandCal("+"); break;
                case Key.Subtract: CheckandCal("-"); break;
                case Key.Multiply: CheckandCal("x"); break;
                case Key.Divide: CheckandCal("/"); break;
            }
        }

        //Calculation logic--
        void NumberFunc(string i)
        {
            if (boxResult.Text.Length == 1 && boxResult.Text.IndexOf("0") == 0)
                boxResult.Text = i;
            else if (resultShowing)
                boxResult.Text = i;
            else
                boxResult.Text += i;

            resultShowing = false;
        }

        void DotCheck()
        {
            if (!boxResult.Text.Contains(".")) { boxResult.Text += "."; }
        }

        void CheckandCal(string x)
        {
            if (resultShowing && boxMain.Text != "")
            {
                boxMain.Text = boxMain.Text.Substring(0, boxMain.Text.Length - 1) + x;
                operStore[numOp - 1] = x;
            }
            else
            {
                boxMain.Text += $" {boxResult.Text} {x}";
                operStore.Add(x);
                numOp += 1;
            }

            if (numOp == 1)
            {
                TheResult = float.Parse(boxMain.Text.Substring(0, boxMain.Text.Length - 2));
                resultShowing = true;
            }
            else if (numOp > 1 && !resultShowing)
            {
                TheResult = Calu(TheResult, operStore[numOp - 2], float.Parse(boxResult.Text));
                boxResult.Text = $"{TheResult}";
                resultShowing = true;
            }
        }

        float Calu(float x, string a, float y)
        {
            float resu;
            switch (a)
            {
                case "+":
                    resu = x + y; break;
                case "-":
                    resu = x - y; break;
                case "x":
                    resu = x * y; break;
                case "/":
                    resu = x / y; break;
                default: throw new Exception("Operator Error");
            }
            return resu;
        }

        void BackSpace()
        {
            if (resultShowing)
                boxResult.Text = "0";
            else if (boxResult.Text.Length > 1)
                boxResult.Text = boxResult.Text.Substring(0, boxResult.Text.Length - 1);
            else
                boxResult.Text = "0";
        }

        void TheEnterKey()
        {
            if (resultShowing)
            {
                boxResult.Text = $"{TheResult}";
            }
            else if (numOp > 0)
            {
                float num1 = float.Parse(boxResult.Text);
                TheResult = Calu(TheResult, operStore[numOp - 1], num1);
                boxResult.Text = $"{TheResult}";
                resultShowing = true;
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

        void ClearEverything()
        {
            numOp = 0;
            TheResult = 0;
            boxMain.Text = "";
            boxResult.Text = "0";
            operStore.Clear();
            resultShowing = false;
        }
    }
}
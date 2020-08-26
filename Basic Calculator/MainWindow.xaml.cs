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
        private void Operator(object sender, RoutedEventArgs e)
        {
            Button oper = (Button)sender;
            boxMain.Text += $" {boxResult.Text} {oper.Content}";
        }
        private void Clear(object sender, RoutedEventArgs e)
        {
            boxMain.Text = "";
            boxResult.Text = "0";
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            if(boxResult.Text.Length > 1)
            {
                boxResult.Text = boxResult.Text.Substring(0, boxResult.Text.Length - 1);
            }
            else{
                boxResult.Text = "0";
            }
        }

    }
}

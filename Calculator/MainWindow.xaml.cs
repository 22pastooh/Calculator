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

namespace Calculator
{
    public partial class MainWindow : Window
    {
        private string currentInput = "";
        private double firstNumber = 0;
        private string operation = "";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Number_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            currentInput += button.Content.ToString();
            InputBox.Text = currentInput;
        }

        private void Operation_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            firstNumber = double.Parse(currentInput);
            operation = button.Content.ToString();
            currentInput = "";
        }

        private void Equal_Click(object sender, RoutedEventArgs e)
        {
            double secondNumber = double.Parse(currentInput);
            double result = 0;

            switch (operation)
            {
                case "+":
                    result = firstNumber + secondNumber;
                    break;
                // Other cases for different operations (-, *, /) go here

                default:
                    break;
            }

            InputBox.Text = result.ToString();
            currentInput = result.ToString();
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            InputBox.Text = "";
            currentInput = "";
            firstNumber = 0;
            operation = "";
        }
    }
}

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
            UpdateInputText(currentInput);
        }

        private void Operation_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            if (!string.IsNullOrEmpty(currentInput))
            {
                firstNumber = double.Parse(currentInput);
                operation = button.Content.ToString();
                currentInput = "";
            }
        }

        private void Decimal_Click(object sender, RoutedEventArgs e)
        {
            if (!currentInput.Contains("."))
            {
                currentInput += ".";
                UpdateInputText(currentInput);
            }
        }

        private void Equal_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(operation) && !string.IsNullOrEmpty(currentInput))
            {
                double secondNumber = double.Parse(currentInput);
                double result = 0;

                switch (operation)
                {
                    case "+":
                        result = firstNumber + secondNumber;
                        break;
                    case "-":
                        result = firstNumber - secondNumber;
                        break;
                    case "*":
                        result = firstNumber * secondNumber;
                        break;
                    case "/":
                        if (secondNumber != 0)
                        {
                            result = firstNumber / secondNumber;
                        }
                        else
                        {
                            MessageBox.Show("Cannot divide by zero!");
                            UpdateInputText("Error");
                            currentInput = "";
                            firstNumber = 0;
                            operation = "";
                            return;
                        }
                        break;
                    default:
                        break;
                }

                UpdateInputText(result.ToString());
                currentInput = result.ToString();
                operation = "";
            }
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            UpdateInputText("");
            currentInput = "";
            firstNumber = 0;
            operation = "";
        }
        private void Comma_Click(object sender, RoutedEventArgs e)
        {
            if (!currentInput.Contains("."))
            {
                currentInput += ".";
                UpdateInputText(currentInput);
            }
        }

        private void UpdateInputText(string text)
        {
            InputText.Text = text;
            if (text.Length > 10)
            {
                InputText.FontSize = 24;
            }
            else if (text.Length > 7)
            {
                InputText.FontSize = 32;
            }
            else
            {
                InputText.FontSize = 48;
            }
        }
    }
}

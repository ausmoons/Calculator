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

namespace WpfApp1
{

    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            Subtraction.IsEnabled = false;
            Addition.IsEnabled = false;
            Division.IsEnabled = false;
            Multiplication.IsEnabled = false;
            Modulo.IsEnabled = false;
            DisplayTextbox.IsEnabled = true;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            ComboBoxItem value = (ComboBoxItem)FunctionalityDropdown.SelectedValue;
            var content = value.Content;
            var contentString = content.ToString();
            if (contentString == "Subtraction")
            {
                Subtraction.IsEnabled = true;
            }
            else if (contentString == "Addition")
            {
                Addition.IsEnabled = true;
            }
            else if (contentString == "Division")
            {
                Division.IsEnabled = true;
            }
            else if (contentString == "Multiplication")
            {
                Multiplication.IsEnabled = true;
            }
            else if (contentString == "Modulo")
            {
                Modulo.IsEnabled = true;
            }
        }


        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            ComboBoxItem value = (ComboBoxItem)RemoveFunctionalityDropdown.SelectedValue;
            var content = value.Content;
            var contentString = content.ToString();
            if (contentString == "Subtraction")
            {
                Subtraction.IsEnabled = false;
            }
            else if (contentString == "Addition")
            {
                Addition.IsEnabled = false;
            }
            else if (contentString == "Division")
            {
                Division.IsEnabled = false;
            }
            else if (contentString == "Multiplication")
            {
                Multiplication.IsEnabled = false;
            }
            else if (contentString == "Modulo")
            {
                Modulo.IsEnabled = false;
            }
        }

        private void NewNumber_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            DisplayTextbox.Text += button.Content.ToString();
        }




        private void Action_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            DisplayTextbox.Text += button.Content.ToString();
        }

        private void Calculater_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Calculate();
            }
            catch (Exception)
            {
                DisplayTextbox.Text = "There is an error. Check if all symbols are numbers or math symbols";
            }
        }

        public void Calculate()
        {
            string action = "";
            int actionPosition = 0;
            double value1 = 0;
            double value2 = 0;
            double result = 0;

            if (DisplayTextbox.Text.Contains("*"))
            {
                actionPosition = DisplayTextbox.Text.IndexOf("*");
            }
            else if (DisplayTextbox.Text.Contains("/"))
            {
                actionPosition = DisplayTextbox.Text.IndexOf("/");
            }
            else if (DisplayTextbox.Text.Contains("+"))
            {
                actionPosition = DisplayTextbox.Text.IndexOf("+");
            }
            else if (DisplayTextbox.Text.Contains("-"))
            {
                actionPosition = DisplayTextbox.Text.IndexOf("-");
            }
            else if (DisplayTextbox.Text.Contains("%"))
            {
                actionPosition = DisplayTextbox.Text.IndexOf("%");
            }

            value1 = Double.Parse(DisplayTextbox.Text.Substring(0, actionPosition));
            action = DisplayTextbox.Text.Substring(actionPosition, 1);
            value2 = Double.Parse(DisplayTextbox.Text.Substring(actionPosition + 1, DisplayTextbox.Text.Length - actionPosition - 1));

            

            if (action == "*")
            {
                result = value1 * value2;
                DisplayTextbox.Text += "= " + result.ToString();
            }
            else if (action == "/")
            {
                if (value2 == 0)
                {
                    DisplayTextbox.Text = "Cannot divide by zero!";
                }
                else
                {
                    result = value1 / value2;
                    DisplayTextbox.Text += "= " + result.ToString();
                }
            }
            else if (action == "+")
            {
                result = value1 + value2;
                DisplayTextbox.Text += "= " + result.ToString();
            }
            else if (action == "-")
            {
                result = value1 - value2;
                DisplayTextbox.Text += "= " + result.ToString();
            }
            else if (action == "%")
            {
                result = value1 % value2;
                DisplayTextbox.Text += "= " + result.ToString();
            }
        }

        private void ClearText_Click(object sender, RoutedEventArgs e)
        {
            DisplayTextbox.Clear();
        }
    }
}

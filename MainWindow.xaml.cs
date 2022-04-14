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
using System.Text.RegularExpressions;

//Srilakshmi Jay commiting to github on april 14

namespace CashRegister
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<decimal> itemPrices = new List<decimal>();

        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
        //Regex method to validate that Only one decimal point can be entered,
        //and only two numbers can be entered after the decimal point
        private bool IsDecimal(string s)
        {
            Regex r = new Regex(@"^\d+((\.\d)?\d?)?$");

            return r.IsMatch(s);
        }
        //validate add itemprices decimal object to the list
        private void buttonEnter_Click(object sender, RoutedEventArgs e)
        {
            if (IsDecimal(inputTextBox.Text) == true)
            {
                itemPrices.Add(decimal.Parse(inputTextBox.Text));
                inputTextBox.Clear();
            }

        }

        private void buttonTotal_Click(object sender, RoutedEventArgs e)
        {
            decimal result = 0;
            //Add the item prices entered
            for (int i = 0; i < itemPrices.Count; i++)
            {
                result += itemPrices[i];
            }

            //Display subtotal with only 2 digits after the decimal
            subtotalTextBox.Text = result.ToString("N");
            inputTextBox.Clear();

            //Calculate tax for the subtotal
            decimal taxCalc = result * new decimal(0.07);
            taxTextBox.Text = taxCalc.ToString("N");

            //Calculate total with tax
            decimal totalPrice = result + taxCalc;
            totalTextBox.Text = totalPrice.ToString("N");

        }
        //method delete to clear the entry
        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {
            inputTextBox.Text = String.Empty;
        }

        private void buttonClear_Click(object sender, RoutedEventArgs e)
        {
            inputTextBox.Text = String.Empty;
            subtotalTextBox.Text = String.Empty;
            taxTextBox.Text = String.Empty;
            totalTextBox.Text = String.Empty;
            itemPrices.Clear();
        }
        //getting the contents of the clicked button
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            inputTextBox.Text += btn.Content.ToString();
           
        }
    }
}

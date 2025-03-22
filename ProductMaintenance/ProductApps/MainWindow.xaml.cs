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

namespace ProductApps
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const double DELIVERY_CHARGE = 25.00;
        const double WRAP_CHARGE = 5.00;
        const double GST = 1.1;

        Product cProduct;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void calculateButton_Click(object sender, RoutedEventArgs e)
        {
            double total_charge = 0;
            
            try
            {
                cProduct = new Product(Convert.ToDecimal(priceTextBox.Text), Convert.ToInt16(quantityTextBox.Text));
                cProduct.calTotalPayment();
                totalPaymentTextBlock.Text = Convert.ToString(cProduct.TotalPayment);

            }
            catch (FormatException)
            {
                MessageBox.Show("Enter data again", "Data Entry Error");
            }

            total_charge = Convert.ToDouble(cProduct.TotalPayment) + DELIVERY_CHARGE;
            totalChargeTextBox.Text = total_charge.ToString("C");

            total_charge += WRAP_CHARGE;
            totalChargeAfterWrapTextBox.Text = total_charge.ToString("C");

            total_charge *= GST;
            totalChargeAfterGSTTextBox.Text = total_charge.ToString("C");
        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            productTextBox.Text = "";
            priceTextBox.Text = "";
            quantityTextBox.Text = "";
            totalPaymentTextBlock.Text = "";
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

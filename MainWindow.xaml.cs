using System.Windows;
using System.Windows.Input;
using System.Text.RegularExpressions;

namespace InvoicingSystem
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

        // Close MainWindow
        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        // Validate textbox (Quantity & Price), to accept integers or float numbers only
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9.]");
            e.Handled = regex.IsMatch(e.Text);
        }

        // Reset Form Data
        private void ResetForm(object sender, RoutedEventArgs e)
        {
            // Reset General Inputs
            this.ClientName.Text = this.BranchName.Text = null;

            // Reset Datepicker Input 
            this.InvoiceDate.SelectedDate = null;

            // Reset Table Inputs
            this.Item1.Text = this.Item2.Text = this.Item3.Text = this.Item4.Text = this.Item5.Text = null;
            this.Quantity1.Text = this.Quantity2.Text = this.Quantity3.Text = this.Quantity4.Text = this.Quantity5.Text = null;
            this.Price1.Text = this.Price2.Text = this.Price3.Text = this.Price4.Text = this.Price5.Text = null;

        }

        // Open Invocie Window
        private void OpenInvoice(object sender, RoutedEventArgs e)
        {
            InvoiceWindow invoice = new InvoiceWindow();

            // Maping Data from MainWindow to InvoiceWindow
            invoice = MappingData(invoice);

            invoice.Show();
        }

        // Maping Data from MainWindow to InvoiceWindow
        private InvoiceWindow MappingData(InvoiceWindow invoice) {

            float totalPrice = 0;
            float quantityParse = 0;
            float priceParse = 0;

            // Invoice general Information
            invoice.ClientName.Content = this.ClientName.Text;
            invoice.BranchName.Content = this.BranchName.Text;
            invoice.InvoiceDate.Content = this.InvoiceDate.Text;


            // Check table data for valid inputs, to avoid exceptions
            if (float.TryParse(this.Quantity1.Text, out quantityParse) && float.TryParse(this.Price1.Text, out priceParse)) {
                invoice.Item1.Content = this.Item1.Text;
                invoice.Price1.Content = this.Price1.Text;
                invoice.Quantity1.Content = this.Quantity1.Text;

                totalPrice += quantityParse * priceParse;
            }
            if (float.TryParse(this.Quantity2.Text, out quantityParse) && float.TryParse(this.Price2.Text, out priceParse))
            {
                invoice.Item2.Content = this.Item2.Text;
                invoice.Price2.Content = this.Price2.Text;
                invoice.Quantity2.Content = this.Quantity2.Text;

                totalPrice += quantityParse * priceParse;
            }
            if (float.TryParse(this.Quantity3.Text, out quantityParse) && float.TryParse(this.Price3.Text, out priceParse))
            {
                invoice.Item3.Content = this.Item3.Text;
                invoice.Price3.Content = this.Price3.Text;
                invoice.Quantity3.Content = this.Quantity3.Text;

                totalPrice += quantityParse * priceParse;
            }
            if (float.TryParse(this.Quantity4.Text, out quantityParse) && float.TryParse(this.Price4.Text, out priceParse))
            {
                invoice.Item4.Content = this.Item4.Text;
                invoice.Price4.Content = this.Price4.Text;
                invoice.Quantity4.Content = this.Quantity4.Text;

                totalPrice += quantityParse * priceParse;
            }
            if (float.TryParse(this.Quantity5.Text, out quantityParse) && float.TryParse(this.Price5.Text, out priceParse))
            {
                invoice.Item5.Content = this.Item5.Text;
                invoice.Price5.Content = this.Price5.Text;
                invoice.Quantity5.Content = this.Quantity5.Text;

                totalPrice += quantityParse * priceParse;
            }
            
            // assign total price
            invoice.Total.Content = totalPrice;

            return invoice;
        }
    }
}

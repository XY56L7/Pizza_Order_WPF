using PizzaOrderingApp.Models;
using System.Text;
using System.Windows;

namespace PizzaOrderingApp
{
    public partial class PaymentWindow : Window
    {
        private Cart OrderCart;

        public PaymentWindow(Cart cart)
        {
            InitializeComponent();
            OrderCart = cart;
            this.DataContext = OrderCart;
            DisplayOrderSummary();
        }

        private void DisplayOrderSummary()
        {
            foreach (var pizza in OrderCart.Pizzas)
            {
                OrderDetailsListBox.Items.Add(pizza.ToString());
            }
        }

        private void ConfirmPayment_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"Payment Successful!\nTotal Paid: ${OrderCart.Total:0.00}", "Payment", MessageBoxButton.OK, MessageBoxImage.Information);
            this.DialogResult = true;
            this.Close();
        }
    }
}

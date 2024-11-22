using PizzaOrderingApp.Models;
using System.Collections.ObjectModel;
using System.Windows;

namespace PizzaOrderingApp
{
    public partial class SelectPizzaWindow : Window
    {
        public Pizza SelectedPizza { get; private set; }

        public SelectPizzaWindow(ObservableCollection<Pizza> pizzas)
        {
            InitializeComponent();
            PizzaListBox.ItemsSource = pizzas;
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            SelectedPizza = PizzaListBox.SelectedItem as Pizza;
            if (SelectedPizza == null)
            {
                MessageBox.Show("Please select a pizza.", "No Selection", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            this.DialogResult = true;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}

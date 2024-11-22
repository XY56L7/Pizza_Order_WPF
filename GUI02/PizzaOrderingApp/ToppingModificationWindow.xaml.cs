using PizzaOrderingApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace PizzaOrderingApp
{
    public partial class ToppingModificationWindow : Window
    {
        public List<Topping> SelectedToppings { get; private set; }
        private List<Topping> AvailableToppings;
        private List<Topping> CurrentToppings;

        public ToppingModificationWindow(List<Topping> availableToppings, List<Topping> currentToppings)
        {
            InitializeComponent();
            AvailableToppings = availableToppings;
            CurrentToppings = currentToppings;
            PopulateToppings();
        }

        private void PopulateToppings()
        {
            foreach (var topping in AvailableToppings)
            {
                var item = new CheckBox
                {
                    Content = $"{topping.Name} (+${topping.Price})",
                    Tag = topping,
                    Margin = new Thickness(5)
                };
                if (CurrentToppings.Any(t => t.Name == topping.Name))
                {
                    item.IsChecked = true;
                }
                ToppingsListBox.Items.Add(item);
            }
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            SelectedToppings = new List<Topping>();
            foreach (CheckBox cb in ToppingsListBox.Items)
            {
                if (cb.IsChecked == true)
                {
                    SelectedToppings.Add(cb.Tag as Topping);
                }
            }
            this.DialogResult = true;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}

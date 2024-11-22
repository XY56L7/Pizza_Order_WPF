using PizzaOrderingApp.Models;
using System.Collections.Generic;
using System.Linq; 
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace PizzaOrderingApp
{
    public partial class MainWindow : Window
    {
        private List<Pizza> Pizzas;
        private List<Topping> AvailableToppings;
        private Cart CurrentCart;

        public MainWindow()
        {
            InitializeComponent();
            InitializeData();
            DisplayPizzas();
            CurrentCart = new Cart();
            this.DataContext = CurrentCart;
        }

        private void InitializeData()
        {
            AvailableToppings = new List<Topping>
            {
                new Topping("Pepperoni", 1.0m),
                new Topping("Mushrooms", 0.5m),
                new Topping("Onions", 0.5m),
                new Topping("Sausage", 1.0m),
                new Topping("Bacon", 1.0m),
                new Topping("Extra cheese", 0.75m),
                new Topping("Black olives", 0.5m),
                new Topping("Green peppers", 0.5m),
                new Topping("Pineapple", 0.75m),
                new Topping("Spinach", 0.5m)
            };

            Pizzas = new List<Pizza>
            {
                new Pizza("Margherita", 5.0m),
                new Pizza("Pepperoni", 6.0m),
                new Pizza("BBQ Chicken", 7.0m),
                new Pizza("Veggie", 6.5m)
            };
        }

        private void DisplayPizzas()
        {
            foreach (var pizza in Pizzas)
            {
                Border border = new Border
                {
                    BorderBrush = Brushes.Black,
                    BorderThickness = new Thickness(1),
                    CornerRadius = new CornerRadius(5),
                    Margin = new Thickness(10),
                    Padding = new Thickness(10),
                    Width = 200,
                    Height = 150,
                    Background = Brushes.LightYellow
                };

                StackPanel stack = new StackPanel();

                TextBlock name = new TextBlock
                {
                    Text = pizza.Name,
                    FontSize = 18,
                    FontWeight = FontWeights.Bold,
                    TextAlignment = TextAlignment.Center
                };

                TextBlock price = new TextBlock
                {
                    Text = $"Alapár: ${pizza.BasePrice}",
                    FontSize = 14,
                    TextAlignment = TextAlignment.Center,
                    Margin = new Thickness(0, 10, 0, 10)
                };

                Button addButton = new Button
                {
                    Content = "Kosárba",
                    Width = 100,
                    Height = 30,
                    Tag = pizza
                };
                addButton.Click += AddButton_Click;

                stack.Children.Add(name);
                stack.Children.Add(price);
                stack.Children.Add(addButton);

                border.Child = stack;
                PizzaWrapPanel.Children.Add(border);
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            Pizza selectedPizza = btn.Tag as Pizza;

            Pizza pizzaToAdd = new Pizza(selectedPizza.Name, selectedPizza.BasePrice);
            CurrentCart.AddPizza(pizzaToAdd);
        }

        private void ModifyToppings_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentCart.Pizzas.Count == 0)
            {
                MessageBox.Show("A kosarad üres. Kérlek adj hozzá pizzákat a toppingok módosítása előtt.", "Üres Kosár", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            SelectPizzaWindow selectPizzaWindow = new SelectPizzaWindow(CurrentCart.Pizzas);
            if (selectPizzaWindow.ShowDialog() == true)
            {
                Pizza selectedPizza = selectPizzaWindow.SelectedPizza;
                if (selectedPizza != null)
                {
                    ToppingModificationWindow toppingWindow = new ToppingModificationWindow(AvailableToppings, selectedPizza.Toppings.ToList());
                    if (toppingWindow.ShowDialog() == true)
                    {
                        selectedPizza.Toppings.Clear();
                        foreach (var topping in toppingWindow.SelectedToppings)
                        {
                            selectedPizza.Toppings.Add(topping);
                        }
                        MessageBox.Show("A toppingok sikeresen frissítve!", "Siker", MessageBoxButton.OK, MessageBoxImage.Information);
                        CartListBox.Items.Refresh();
                    }
                }
            }
        }

        private void PlaceOrder_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentCart.Pizzas.Count == 0)
            {
                MessageBox.Show("A kosarad üres. Kérlek adj hozzá pizzákat a rendelés leadása előtt.", "Üres Kosár", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            PaymentWindow paymentWindow = new PaymentWindow(CurrentCart);
            if (paymentWindow.ShowDialog() == true)
            {
                CurrentCart.Pizzas.Clear();
                MessageBox.Show("Köszönjük a rendelést!", "Rendelés Leadva", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void Checkout_Click(object sender, RoutedEventArgs e)
        {
            PlaceOrder_Click(sender, e);
        }
    }
}

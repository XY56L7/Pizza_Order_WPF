using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.Specialized;

namespace PizzaOrderingApp.Models
{
    public class Cart : INotifyPropertyChanged
    {
        public ObservableCollection<Pizza> Pizzas { get; set; }

        private decimal total;
        public decimal Total
        {
            get => total;
            set
            {
                if (total != value)
                {
                    total = value;
                    OnPropertyChanged();
                }
            }
        }

        public Cart()
        {
            Pizzas = new ObservableCollection<Pizza>();
            Pizzas.CollectionChanged += Pizzas_CollectionChanged;
        }

        private void Pizzas_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (Pizza p in e.NewItems)
                {
                    p.PropertyChanged += Pizza_PropertyChanged;
                }
            }
            if (e.OldItems != null)
            {
                foreach (Pizza p in e.OldItems)
                {
                    p.PropertyChanged -= Pizza_PropertyChanged;
                }
            }
            CalculateTotal();
        }

        private void Pizza_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Total")
            {
                CalculateTotal();
            }
        }

        public void AddPizza(Pizza pizza)
        {
            Pizzas.Add(pizza);
        }

        public void RemovePizza(Pizza pizza)
        {
            Pizzas.Remove(pizza);
        }

        private void CalculateTotal()
        {
            decimal sum = 0;
            foreach (var pizza in Pizzas)
            {
                sum += pizza.Total;
            }
            Total = sum;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}

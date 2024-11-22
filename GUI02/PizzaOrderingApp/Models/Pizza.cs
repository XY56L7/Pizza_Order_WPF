using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PizzaOrderingApp.Models
{
    public class Pizza : INotifyPropertyChanged
    {
        private string name;
        private decimal basePrice;
        private ObservableCollection<Topping> toppings;

        public Pizza(string name, decimal basePrice)
        {
            Name = name;
            BasePrice = basePrice;
            Toppings = new ObservableCollection<Topping>();
            Toppings.CollectionChanged += Toppings_CollectionChanged;
        }

        public string Name
        {
            get => name;
            set { name = value; OnPropertyChanged(); OnPropertyChanged(nameof(Total)); }
        }

        public decimal BasePrice
        {
            get => basePrice;
            set { basePrice = value; OnPropertyChanged(); OnPropertyChanged(nameof(Total)); }
        }

        public ObservableCollection<Topping> Toppings
        {
            get => toppings;
            set
            {
                if (toppings != null)
                {
                    toppings.CollectionChanged -= Toppings_CollectionChanged;
                }
                toppings = value;
                if (toppings != null)
                {
                    toppings.CollectionChanged += Toppings_CollectionChanged;
                }
                OnPropertyChanged();
                OnPropertyChanged(nameof(Total));
            }
        }

        private void Toppings_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged(nameof(Total));
        }

        public decimal Total => CalculateTotalPrice();

        public decimal CalculateTotalPrice()
        {
            decimal total = BasePrice;
            foreach (var topping in Toppings)
            {
                total += topping.Price;
            }
            return total;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public override string ToString()
        {
            return $"{Name} - ${Total:0.00}";
        }
    }
}

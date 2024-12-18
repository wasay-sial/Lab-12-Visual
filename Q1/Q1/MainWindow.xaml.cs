using System.Collections.ObjectModel;
using System.Windows;

namespace OrderManagementApp
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<Address> Addresses { get; set; }
        public Address SelectedAddress { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            Addresses = new ObservableCollection<Address>
            {
                new Address { Street = "123 Main St", City = "Anytown", State = "CA", ZipCode = "12345" },
                new Address { Street = "456 Elm St", City = "Othertown", State = "NY", ZipCode = "67890" }
            };
            DataContext = this;
        }

        private void AddUpdateAddress_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedAddress != null)
            {
                // Ask user if they want to update the existing address
                MessageBoxResult result = MessageBox.Show("Do you want to update the existing address?", "Update Address", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    // Update the selected address
                    var newAddress = NewAddressTextBox.Text.Split(',');
                    if (newAddress.Length == 4)
                    {
                        SelectedAddress.Street = newAddress[0].Trim();
                        SelectedAddress.City = newAddress[1].Trim();
                        SelectedAddress.State = newAddress[2].Trim();
                        SelectedAddress.ZipCode = newAddress[3].Trim();
                    }
                }
            }
            else
            {
                // Add a new address
                var newAddress = NewAddressTextBox.Text.Split(',');
                if (newAddress.Length == 4)
                {
                    Addresses.Add(new Address
                    {
                        Street = newAddress[0].Trim(),
                        City = newAddress[1].Trim(),
                        State = newAddress[2].Trim(),
                        ZipCode = newAddress[3].Trim()
                    });
                }
            }

            // Clear the input field
            NewAddressTextBox.Clear();
            ShippingAddressTextBlock.Text = SelectedAddress?.ToString() ?? "No shipping address selected.";
        }

        private void AddressComboBox_SelectionChanged()
        {

        }
    }
}
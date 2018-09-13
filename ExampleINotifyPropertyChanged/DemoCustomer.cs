using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ExampleINotifyPropertyChanged
{
    // This is a simple customer class that implements the IPropertyChange interface. 
    public class DemoCustomer : INotifyPropertyChanged
    {
        // These fields hold the values for the public properties.
        private string customerNameValue = string.Empty;
        private string phoneNumberValue = string.Empty;

        public event PropertyChangedEventHandler PropertyChanged;

        // This method is called by the Set accessor of each property.  
        // The CallerMemberName attribute that is applied to the optional propertyName  
        // parameter causes the property name of the caller to be substituted as an argument.
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // The constructor is private to enforce the factory pattern.
        private DemoCustomer()
        {
            customerNameValue = @"New Customer";
            phoneNumberValue = @"(000) 000-0000";
        }

        // This is the public factory method.
        public static DemoCustomer CreateNewCustomer()
        {
            return new DemoCustomer();
        }

        // This property represents an ID, suitable for use as a primary key in a database. 
        public Guid Id { get; } = Guid.NewGuid();

        public string CustomerName
        {
            get => customerNameValue;
            set
            {
                if (value != customerNameValue)
                {
                    customerNameValue = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public string PhoneNumber
        {
            get => phoneNumberValue;
            set
            {
                if (value != phoneNumberValue)
                {
                    phoneNumberValue = value;
                    NotifyPropertyChanged();
                }
            }
        }
    }
}

using System;

namespace New_Project
{
    public class Order : IComparable<Order>
    {
        public string ProductName { get; set; }
        public string DeliveryAddress { get; set; }

        public long PhoneNumber
        {
            get { return _phoneNumber; }
            set
            {
                if (value.ToString().Length == 13)
                {
                    _phoneNumber = value;
                }
                else
                {
                    Console.WriteLine("Only 13 digits allowed.");
                }
            }
        }

        private long _phoneNumber;

        public float Price
        {
            get { return _price; }
            set
            {
                if (value > 0 && value <= 1000)
                {
                    _price = value;
                }
                else
                {
                    Console.WriteLine("Price must be > 0 and <= 1000.");
                }
            }
        }

        private float _price;

        public Order(string productName, long phoneNumber, float price, string deliveryAddress)
        {
            ProductName = productName;
            PhoneNumber = phoneNumber;
            Price = price;
            DeliveryAddress = deliveryAddress;
        }

        public virtual void DisplayInformation()
        {
            Console.WriteLine($"Name of Product: {ProductName}");
            Console.WriteLine($"Phone number: {PhoneNumber}");
            Console.WriteLine($"Price: {Price}");
            Console.WriteLine($"Delivery address: {DeliveryAddress}");
        }

        public int CompareTo(Order other)
        {
            if (other == null) return 1;
            return PhoneNumber.CompareTo(other.PhoneNumber);
        }
    }
}
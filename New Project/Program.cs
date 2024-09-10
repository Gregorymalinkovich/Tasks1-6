using System;

namespace New_Project
{
    public class Order
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
                    Console.WriteLine("Only 13");
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
                    Console.WriteLine("Only > 0 and !>1000");
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
        public void DisplayInformation()
        {
            Console.WriteLine($"Name of Product: {ProductName}");
            Console.WriteLine($"Phone number: {PhoneNumber}");
            Console.WriteLine($"Price: {Price}");
            Console.WriteLine($"Delivery address: {DeliveryAddress}");    
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
           
            Order[] orders = new Order[3];
            orders[0] = new Order("Whysk", 1234567890123, 20f, "Minsk");
            orders[1] = new Order("LapTop", 3756543210123, 999f, "Grodno");
            orders[2] = new Order("Fridge", 1112223333123, 990f, "Gomel");

            
            Console.WriteLine("Orders:");
            foreach (Order order in orders)
            {
                if (order.PhoneNumber.ToString().StartsWith("375"))
                {
                    order.DisplayInformation();
                }
            }
            Console.WriteLine("Orders stasts from Whys and !>20");
            foreach (Order order in orders)
            {
                if (order.Price <= 20 && order.ProductName.StartsWith("Whys"))
                {
                    order.DisplayInformation();
                }
            }

        }
    }
}
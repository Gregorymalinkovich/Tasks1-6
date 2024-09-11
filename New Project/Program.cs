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
        public virtual void DisplayInformation()
        {
            Console.WriteLine($"Name of Product: {ProductName}");
            Console.WriteLine($"Phone number: {PhoneNumber}");
            Console.WriteLine($"Price: {Price}");
            Console.WriteLine($"Delivery address: {DeliveryAddress}");    
        }
    }

    public class VIPOrder : Order
    {
        public string Gift { get; set; }

        public VIPOrder(string productName, long phoneNumber, float price, string deliveryAddress, string gift) : base(productName, phoneNumber, price, deliveryAddress)
        {
            Gift = gift; 
        }
        public override void DisplayInformation()
        {
            base.DisplayInformation();
            Console.WriteLine($"Gift: {Gift}");
        }
    }

    public class DiscountOrder : Order
    {
        public float Discount { get; set; }
        public DiscountOrder(string productName, long phoneNumber, float price, string deliveryAddress, float discount) : base(productName, phoneNumber, price, deliveryAddress)
        {
            Discount = discount;
        }
        public override void DisplayInformation() 
        {
            base.DisplayInformation();
            Console.WriteLine($"Discount: {Discount}%");
        }
}


    public class OrdinaryOrder : Order
    {
        public OrdinaryOrder(string productName, long phoneNumber, float price, string deliveryAddress) : base(productName, phoneNumber, price, deliveryAddress)
        {

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


            Order[] newOrders = new Order[3];
            newOrders[0] = new VIPOrder("Windows", 1234567890123, 20, "Vilnus", "Free pen");
            newOrders[1] = new DiscountOrder("Mac", 3756543210123, 999, "Riga", 10f);
            newOrders[2] = new OrdinaryOrder("Camera", 1112223333123, 990, "Poznan");


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

            Console.WriteLine("NewOrders: ");
            foreach (Order order in newOrders)
            {
                Console.WriteLine($"Order Type: {order.GetType().Name}");
                order.DisplayInformation();
                Console.WriteLine();
            }

        }
    }
}
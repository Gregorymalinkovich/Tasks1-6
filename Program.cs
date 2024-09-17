using System;
using System.Collections;
using System.Collections.Generic;

namespace New_Project
{
    
    public class Node<T>
    {
        public T Data { get; set; }
        public Node<T> Next { get; set; }

        public Node(T data)
        {
            Data = data;
            Next = null;
        }
    }

   
    public class MyList<T> : IEnumerable<T>
    {
        private Node<T> _head;
        private int _count;

        public MyList()
        {
            _head = null;
            _count = 0;
        }

       
        public void AddFirst(T data)
        {
            Node<T> newNode = new Node<T>(data);
            newNode.Next = _head;
            _head = newNode;
            _count++;
        }

       
        public int IndexOf(T data)
        {
            Node<T> current = _head;
            int index = 0;
            while (current != null)
            {
                if (EqualityComparer<T>.Default.Equals(current.Data, data))
                {
                    return index;
                }
                current = current.Next;
                index++;
            }
            return -1; 
        }

        
        public int Count
        {
            get { return _count; }
        }

        
        public T Get(int position)
        {
            if (position < 0 || position >= _count)
            {
                throw new ArgumentOutOfRangeException(nameof(position), "Invalid position.");
            }

            Node<T> current = _head;
            for (int i = 0; i < position; i++)
            {
                current = current.Next;
            }
            return current.Data;
        }

        
        public void Remove(T data)
        {
            if (_head == null)
                return;

            if (EqualityComparer<T>.Default.Equals(_head.Data, data))
            {
                _head = _head.Next;
                _count--;
                return;
            }

            Node<T> current = _head;
            while (current.Next != null && !EqualityComparer<T>.Default.Equals(current.Next.Data, data))
            {
                current = current.Next;
            }

            if (current.Next != null)
            {
                current.Next = current.Next.Next;
                _count--;
            }
        }

        
        public IEnumerator<T> GetEnumerator()
        {
            Node<T> current = _head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

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
    }

    public class VIPOrder : Order
    {
        public string Gift { get; set; }

        public VIPOrder(string productName, long phoneNumber, float price, string deliveryAddress, string gift)
            : base(productName, phoneNumber, price, deliveryAddress)
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

        public DiscountOrder(string productName, long phoneNumber, float price, string deliveryAddress, float discount)
            : base(productName, phoneNumber, price, deliveryAddress)
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
        public OrdinaryOrder(string productName, long phoneNumber, float price, string deliveryAddress)
            : base(productName, phoneNumber, price, deliveryAddress)
        {

        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
           
            MyList<Order> orders = new MyList<Order>();

            orders.AddFirst(new Order("Whysk", 1234567890123, 20f, "Minsk"));
            orders.AddFirst(new Order("LapTop", 3756543210123, 999f, "Grodno"));
            orders.AddFirst(new Order("Fridge", 1112223333123, 990f, "Gomel"));

            MyList<Order> newOrders = new MyList<Order>();
            newOrders.AddFirst(new VIPOrder("Windows", 1234567890123, 20, "Vilnus", "Free pen"));
            newOrders.AddFirst(new DiscountOrder("Mac", 3756543210123, 999, "Riga", 10f));
            newOrders.AddFirst(new OrdinaryOrder("Camera", 1112223333123, 990, "Poznan"));

            
            Console.WriteLine("Orders:");
            foreach (Order order in orders)
            {
                if (order.PhoneNumber.ToString().StartsWith("375"))
                {
                    order.DisplayInformation();
                }
            }

            Console.WriteLine("Orders starting with 'Whysk' and price <= 20:");
            foreach (Order order in orders)
            {
                if (order.Price <= 20 && order.ProductName.StartsWith("Whysk"))
                {
                    order.DisplayInformation();
                }
            }

            Console.WriteLine("NewOrders:");
            foreach (Order order in newOrders)
            {
                Console.WriteLine($"Order Type: {order.GetType().Name}");
                order.DisplayInformation();
                Console.WriteLine();
            }

        }
    }
}
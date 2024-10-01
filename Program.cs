using New_Project;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace New_Project
{
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

            List<Order> orderList = new List<Order>(orders);

            orderList.Sort();
            Console.WriteLine("Sorted by Phone Number:");
            foreach (var order in orderList)
            {
                order.DisplayInformation();
                Console.WriteLine();
            }
            orderList.Sort((o1, o2) => o1.ProductName.CompareTo(o2.ProductName));
            Console.WriteLine("Sorted by Product Name:");
            foreach (var order in orderList)
            {
                order.DisplayInformation();
                Console.WriteLine();
            }
            orderList.Sort((o1, o2) => o1.Price.CompareTo(o2.Price));
            Console.WriteLine("Sorted by Price:");
            foreach (var order in orderList)
            {
                order.DisplayInformation();
                Console.WriteLine();
            }

            orderList.Sort((o1, o2) => o1.DeliveryAddress.CompareTo(o2.DeliveryAddress));
            Console.WriteLine("Sorted by Delivery Address:");
            foreach (var order in orderList)
            {
                order.DisplayInformation();
                Console.WriteLine();
            }

            Console.WriteLine("LINQ sort price:");
            var sortedByPriceLinq = orderList.OrderBy(o => o.Price);
            foreach (var order in sortedByPriceLinq)
            {
                order.DisplayInformation();
                Console.WriteLine();
            }

            Console.WriteLine("LINQ sort DeliveryAddress:");
            var sortedByAddressLinq = orderList.OrderBy(o => o.DeliveryAddress);
            foreach (var order in sortedByAddressLinq)
            {
                order.DisplayInformation();
                Console.WriteLine();
            }

            Console.WriteLine("LINQ Sorting by ProductName and then by Price:");
            var sortedByNameAndPriceLinq = orderList
                .OrderBy(o => o.ProductName)
                .ThenBy(o => o.Price);
            foreach (var order in sortedByNameAndPriceLinq)
            {

                order.DisplayInformation();
                Console.WriteLine();
            }
            
            Console.WriteLine("Most frequent product:");
            var mostFrequentProduct = orderList
                .GroupBy(o => o.ProductName)
                .OrderByDescending(g => g.Count())
                .FirstOrDefault();

            if (mostFrequentProduct != null)
            {
                Console.WriteLine($"Product Name: {mostFrequentProduct.Key}, Count: {mostFrequentProduct.Count()}");
            }
            else
            {
                Console.WriteLine("not found");
            }

        }

    }
}


namespace New_Project
{
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
}
namespace New_Project
{
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
}
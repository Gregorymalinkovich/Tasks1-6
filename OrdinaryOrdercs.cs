namespace New_Project
{
    public class OrdinaryOrder : Order
    {
        public OrdinaryOrder(string productName, long phoneNumber, float price, string deliveryAddress)
            : base(productName, phoneNumber, price, deliveryAddress)
        {

        }
    }
}
using System.Runtime.InteropServices;

namespace E_commerce.Models
{
    public class orders
    {
        public int orderID { get; set; }
        public float  TotalPrice { get; set; }
        public string orderStatus { get; set; }
        public string orderDate { get; set; }
        public int CustomerID { get; set; }
        public int SellerID { get; set; }
        public int ShippingInfoID { get; set; }
        public int PaymentID { get; set; }
    }
}

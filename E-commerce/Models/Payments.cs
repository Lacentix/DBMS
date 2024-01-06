namespace E_commerce.Models
{
    public class Payments
    {
        public int PaymentID { get; set; }
        public float Amount { get; set; }
        public string PaymentMethod { get; set; }
        public string PaymentStatus { get; set; }
        public int CustomerID { get; set; }
        public int CouponID { get; set; }

    }
}

namespace E_commerce.Models
{
    public class coupons
    {
        public int couponId { get; set; }
        public float discountPercentage { get; set; }
        public int usageLimits { get; set; }
        public string expiryDate { get; set; }
        public string type { get; set; }
        public string status { get; set; }
        public string applicableProducts { get; set; }
    }
}

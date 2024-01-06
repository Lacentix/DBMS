using E_commerce.Pages;

namespace E_commerce.Models
{
    public class reviews
    {
        public int ReviewID { get; set; }
        public int Rating { get; set; }
        public string Description { get; set; }
        public int CustomerID { get; set; }
        public int ProductID { get; set; }
}
}

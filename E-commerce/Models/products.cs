using E_commerce.Pages;
using System.Runtime.InteropServices;

namespace E_commerce.Models
{
    public class products
    {
        public int ProductID { set; get; }
        public int SellersID { set; get; }
        public string ProductName  { set; get; }
        public float Price  { set; get; }
        public string Description { set; get; }
        public int SellerID { set; get; }
        public int CategoryID { set; get; }
    }
}

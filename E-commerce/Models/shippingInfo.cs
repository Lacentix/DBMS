using System.Xml.Linq;

namespace E_commerce.Models
{
    public class shippingInfo
    {
        public int ShippingInfoID { get; set; }
        public int OrderID { get; set; }
        public string name { get; set; }
        public int custID { get; set; }
        public string Address { get; set; }
        public int floorNum { get; set; }
        public int apartmentNum { get; set; }

    }
}

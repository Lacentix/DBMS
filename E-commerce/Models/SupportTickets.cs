namespace E_commerce.Models
{
    public class SupportTickets
    {
        public int TicketID { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public int CustomerID { get; set; }
        public int EmployeeID { get; set; }

    }
}

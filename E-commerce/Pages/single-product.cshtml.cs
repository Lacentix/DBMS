using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace E_commerce.Pages;

public class single_product : PageModel
{
        [BindProperty]
        public int Quantity { get; set; }

        [BindProperty]
        public int Total { get; set; }

        public void OnGet()
        {
            // You can set an initial value for Total if needed
            Total = 0;
        }

        public void OnPost()
        {
            // Calculate total based on quantity * price (assuming price is $120)
            int pricePerItem = 120;
            Total = pricePerItem * Quantity;
        }
    }

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace E_commerce.Pages
{
    public class CartModel : PageModel
    {
        public List<CartItem> CartItems { get; set; }
        public decimal TotalPrice { get; set; }

        public void OnGet()
        {
            // Your logic to populate cart items and total price for GET requests
            // For example, you might retrieve data from a database or session.

            // Ensure CartItems is initialized to an empty list
            CartItems = new List<CartItem>(); // Initialize it with an empty list or retrieve the actual cart items

            // Example: Retrieving cart items from a service or database
            // CartItems = cartService.GetCartItems(); 

            // For demonstration purposes, let's add some sample data
            CartItems.Add(new CartItem { ProductName = "Jacket", Quantity = 1, Price = 120m });

            // Calculate total price
            TotalPrice = CalculateTotalPrice();
        }

        public IActionResult OnPostCheckout()
        {
            // Your checkout logic
            // For example, you might process the order, clear the cart, and redirect to a confirmation page.
            
            // Clear the cart after checkout (you should implement this logic)
            // ClearCart();

            return RedirectToPage("/COD");
        }

        private decimal CalculateTotalPrice()
        {
            decimal totalPrice = 0;

            // Calculate the total price based on cart items
            foreach (var item in CartItems)
            {
                totalPrice += item.Quantity * item.Price;
            }

            return totalPrice;
        }
    }

    public class CartItem
    {
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}

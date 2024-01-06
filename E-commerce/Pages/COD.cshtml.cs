using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using System.Data;

namespace E_commerce.Pages
{
    public class CODModel : PageModel
    {
        public void OnGet()
        {
        }
        [BindProperty]
        public int ZipCode { get; set; }

        [BindProperty]
        public string Address { get; set; }
        public IActionResult OnPost(string submitType)
        {
            if (submitType == "submit")
            {
                string ConString = @"Data Source=DESKTOP-0TH5VGS\SQLEXPRESS;Initial Catalog=DB project;Integrated Security=True";

                using (SqlConnection con = new SqlConnection(ConString))
                {
                    string querystring = "INSERT INTO ShippingInformation(ShippingInfoID, OrderID,ZipCode, Address)" +
                        "VALUES (@generatedID, @generatedOrder, @ZipCode, @Address);";

                    try
                    {
                        int min = 10000;
                        int max = 99999;
                        Random random = new Random();
                        int shippingInfoID = random.Next(min, max);
                        int orderID = random.Next(min, max);
                        con.Open();
                        SqlCommand cmd = new SqlCommand(querystring, con);
                        cmd.Parameters.AddWithValue("@generatedID", shippingInfoID);
                        cmd.Parameters.AddWithValue("@generatedOrder", orderID);
                        cmd.Parameters.AddWithValue("@ZipCode", ZipCode); // Assuming ZipCode and Address are properties in your class
                        cmd.Parameters.AddWithValue("@Address", Address);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            return RedirectToPage("/products");
                        }
                        else
                        {
                            // Handle insertion failure
                            return Page(); // Or return a specific error page
                        }
                    }
                    catch (SqlException ex)
                    {
                        // Handle SQL exceptions (log the error, redirect to an error page, etc.)
                        Console.WriteLine(ex.ToString());
                        return RedirectToPage("/Error"); // Redirect to an error page
                    }
                }
            }
            else if (submitType == "payByCard")
            {
                return RedirectToPage("/Payment"); // Redirect to payment page
            }
            else
            {
                return Page();
            }
        }
    }
}
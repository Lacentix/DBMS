using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Collections.Generic; // Add this namespace for List
using System.Data.SqlClient;

namespace E_commerce.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly ILogger<RegisterModel> _logger;

        public RegisterModel(ILogger<RegisterModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }

        // Add the ReturnUrl property
        [BindProperty(SupportsGet = true)]
        public string ReturnUrl { get; set; }

        // Add the ExternalLogins property
        public List<ExternalLogin> ExternalLogins { get; set; }

        public class ExternalLogin
        {
            public string Name { get; set; }
            public string DisplayName { get; set; }

            // Additional properties or methods as needed
        }

        [BindProperty]
        public string Email { get; set; }

        [BindProperty]
        public string Password { get; set; }

        [BindProperty]
        public string Role { get; set; }

        [BindProperty]
        public string name { get; set; }

        [BindProperty]
        public string phone { get; set; }

        [BindProperty]
        public string ConfirmPassword
        { get; set; }


        public IActionResult OnPost()
        {
            string ConString = @"Data Source=DESKTOP-0TH5VGS\SQLEXPRESS;Initial Catalog=DB project;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(ConString))
            {
                if (Role == "customer" && Password == ConfirmPassword)
                {
                    string querystring = "INSERT INTO Customers(CustomerID, customerName, customerEmail, password, customerContactNumber) VALUES (@generatedID, @name, @email, @password,  @phone)";

                    try
                    {
                        int min = 10000;
                        int max = 99999;
                        Random random = new Random();
                        int customerID = random.Next(min, max);
                        int orderID = random.Next(min, max);
                        con.Open();
                        SqlCommand cmd = new SqlCommand(querystring, con);
                        cmd.Parameters.AddWithValue("@generatedID", customerID);
                        cmd.Parameters.AddWithValue("@email", Email);
                        cmd.Parameters.AddWithValue("@password", Password);
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@phone", phone.ToString());

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            return RedirectToPage("/products");
                        }
                        else
                        {
                            // Handle invalid credentials or redirect to a specific page
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
                if (Role == "seller" && Password == ConfirmPassword)
                {
                    string querystring = "INSERT INTO Sellers(sellerID, sellerName, sellerEmail, passwordSeller, sellerContactNumber) VALUES (@generatedID, @name, @email, @password, @phone)";

                    try
                    {
                        int min = 10000;
                        int max = 99999;
                        Random random = new Random();
                        int sellerID = random.Next(min, max);
                        con.Open();
                        SqlCommand cmd = new SqlCommand(querystring, con);
                        cmd.Parameters.AddWithValue("@generatedID", sellerID.ToString());
                        cmd.Parameters.AddWithValue("@email", Email);
                        cmd.Parameters.AddWithValue("@password", Password);
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@phone", phone.ToString());

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            return RedirectToPage("/products");
                        }
                        else
                        {
                            // Handle invalid credentials or redirect to a specific page
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
                else
                {
                    return Page();
                }
            }
        }
    }
}
using E_commerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace E_commerce.Pages
{
    public class LoginModel : PageModel
    {
        private readonly ILogger<LoginModel> _logger;

        public LoginModel(ILogger<LoginModel> logger)
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


        public IActionResult OnPost()
        {
            string ConString = @"Data Source=DESKTOP-0TH5VGS\SQLEXPRESS;Initial Catalog=DB project;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(ConString))
            {
                if (Role == "Customer")
                {
                    string querystring = "SELECT customerEmail, password FROM Customers WHERE customerEmail = @inputEmail AND password = @inputPassword";

                    try
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand(querystring, con);
                        cmd.Parameters.AddWithValue("@inputEmail", Email);
                        cmd.Parameters.AddWithValue("@inputPassword", Password);

                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.HasRows)
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

                if (Role == "Seller")
                {
                    string querystring = "SELECT sellerEmail, passwordSeller FROM Sellers WHERE sellerEmail = @inputEmail AND passwordSeller = @inputPassword";

                    try
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand(querystring, con);
                        cmd.Parameters.AddWithValue("@inputEmail", Email);
                        cmd.Parameters.AddWithValue("@inputPassword", Password);

                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.HasRows)
                        {
                            return RedirectToPage("/Sellers");
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
                if (Role == "Employee")
                {
                    string querystring = "SELECT Email, password FROM Employee WHERE Email = @inputEmail AND password = @inputPassword";

                    try
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand(querystring, con);
                        cmd.Parameters.AddWithValue("@inputEmail", Email);
                        cmd.Parameters.AddWithValue("@inputPassword", Password);

                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.HasRows)
                        {
                            return RedirectToPage("/Employees");
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
                if (Role == "Admin")
                {
                    string querystring = "SELECT adminEmail, adminPassword FROM Administrators WHERE adminEmail = @inputEmail AND adminPassword = @inputPassword";

                    try
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand(querystring, con);
                        cmd.Parameters.AddWithValue("@inputEmail", Email);
                        cmd.Parameters.AddWithValue("@inputPassword", Password);

                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.HasRows)
                        {
                            return RedirectToPage("/Customer");
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

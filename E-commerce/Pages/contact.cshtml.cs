using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using System.Data;
using System.Numerics;

namespace E_commerce.Pages;

public class contact : PageModel
{
    [BindProperty]
    public string name { get; set; }
    [BindProperty]
    public string email { get; set; }
    [BindProperty]
    public string message { get; set; }
    public void OnGet()
    {

    }
    public IActionResult OnPost()
    {
        string ConString = @"Data Source=DESKTOP-0TH5VGS\SQLEXPRESS;Initial Catalog=DB project;Integrated Security=True";

        using (SqlConnection con = new SqlConnection(ConString))
        {
            string querystring = "INSERT INTO SupportTickets(TicketID, Description, Status, Email) VALUES (@generatedID, @message, @status,  @Email)";

            try
            {
                int min = 10000;
                int max = 99999;
                Random random = new Random();
                int ticketID = random.Next(min, max);
                con.Open();
                SqlCommand cmd = new SqlCommand(querystring, con);
                cmd.Parameters.AddWithValue("@generatedID", ticketID);
                cmd.Parameters.AddWithValue("@message", message);
                cmd.Parameters.AddWithValue("@status", "Pending");
                cmd.Parameters.AddWithValue("@Email", email);


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

    }
}
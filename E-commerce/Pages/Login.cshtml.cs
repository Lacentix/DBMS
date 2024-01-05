using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


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
    }
}
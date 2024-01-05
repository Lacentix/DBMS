using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Collections.Generic; // Add this namespace for List

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
    }
}
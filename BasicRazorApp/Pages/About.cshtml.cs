using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BasicRazorApp.Pages
{
    public class AboutModel : PageModel
    {
        public string Message { get; set; }

        public void OnGet()
        {
            Message = "Basic Restaurant Application.";
        }
    }
}
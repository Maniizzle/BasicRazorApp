using BasicRazorPage.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace BasicRazorApp.Pages.R2
{
    public class CreateModel : PageModel
    {
        private readonly BasicRazorApp.Data.BasicRazorAppDataContext _context;

        public CreateModel(BasicRazorApp.Data.BasicRazorAppDataContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Restaurant Restaurant { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Restaurants.Add(Restaurant);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
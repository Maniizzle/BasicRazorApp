using BasicRazorPage.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BasicRazorApp.Pages.R2
{
    public class DetailsModel : PageModel
    {
        private readonly BasicRazorApp.Data.BasicRazorAppDataContext _context;

        public DetailsModel(BasicRazorApp.Data.BasicRazorAppDataContext context)
        {
            _context = context;
        }

        public Restaurant Restaurant { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Restaurant = await _context.Restaurants.FirstOrDefaultAsync(m => m.Id == id);

            if (Restaurant == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
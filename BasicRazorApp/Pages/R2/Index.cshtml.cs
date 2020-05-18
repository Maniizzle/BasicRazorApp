using BasicRazorPage.Core;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BasicRazorApp.Pages.R2
{
    public class IndexModel : PageModel
    {
        private readonly BasicRazorApp.Data.BasicRazorAppDataContext _context;

        public IndexModel(BasicRazorApp.Data.BasicRazorAppDataContext context)
        {
            _context = context;
        }

        public IList<Restaurant> Restaurant { get; set; }

        public async Task OnGetAsync()
        {
            Restaurant = await _context.Restaurants.ToListAsync();
        }
    }
}
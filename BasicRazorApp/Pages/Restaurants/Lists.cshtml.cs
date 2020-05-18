using BasicRazorApp.Data;
using BasicRazorPage.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace BasicRazorApp.Pages.Shared.Restaurants
{
    public class ListsModel : PageModel
    {
        private readonly IConfiguration config;
        private readonly IRestaurantData restaurantData;
        private readonly ILogger<ListsModel> logger;

        public string Message { get; set; }
        public IEnumerable<Restaurant> Restaurants { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public ListsModel(IConfiguration config,
                         IRestaurantData restaurantData,
                         ILogger<ListsModel> logger)
        {
            this.config = config;
            this.restaurantData = restaurantData;
            this.logger = logger;
        }

        public void OnGet()
        {
            logger.LogError("Executing ListsModel");
            Message = config["Message"];
            Restaurants = restaurantData.GetRestaurantsByName(SearchTerm);
        }
    }
}
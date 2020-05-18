using BasicRazorApp.Data;
using Microsoft.AspNetCore.Mvc;

namespace BasicRazorApp.Pages.ViewComponents
{
    public class RestaurantCountViewComponent : ViewComponent
    {
        private readonly IRestaurantData restaurantData;

        public RestaurantCountViewComponent(IRestaurantData restaurantData)
        {
            this.restaurantData = restaurantData;
        }

        public IViewComponentResult Invoke()
        {
            var count = restaurantData.GetCountOfRestaurants();
            return View(count);//view is default here
            return View("count", count);//specify the count view and pass count model
        }
    }
}
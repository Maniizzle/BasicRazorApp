using BasicRazorApp.Data;
using BasicRazorApp.RazorHubs;
using BasicRazorPage.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicRazorApp.Api
{
    [Route("api/[controller]/")]
    [ApiController]
    public class RestaurantsController : ControllerBase
    {
        private readonly BasicRazorAppDataContext _context;
        private readonly IHubContext<RazorHub> hubContext;
        // private readonly IHubContext<RazorHub> coffeeHub;

        private readonly IRestaurantData restaurantData;

        public RestaurantsController(BasicRazorAppDataContext context, IHubContext<RazorHub> hubContext, IRestaurantData restaurantData)
        {
            _context = context;
            this.hubContext = hubContext;
            this.restaurantData = restaurantData;
        }

        // GET: api/Restaurants
        [HttpGet]
        public IEnumerable<Restaurant> GetRestaurants()
        {
            return _context.Restaurants;
        }

        [HttpGet("pushup")]
        public async Task<IActionResult> ActivateNote()
        {
            var res = restaurantData.GetCountOfRestaurants();
            await hubContext.Clients.All.SendAsync("RecieveRestaurant", res);

            return Accepted();
        }

        // GET: api/Restaurants/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRestaurant([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var restaurant = await _context.Restaurants.FindAsync(id);

            if (restaurant == null)
            {
                return NotFound();
            }

            return Ok(restaurant);
        }

        // PUT: api/Restaurants/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRestaurant([FromRoute] int id, [FromBody] Restaurant restaurant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != restaurant.Id)
            {
                return BadRequest();
            }

            _context.Entry(restaurant).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RestaurantExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Restaurants
        [HttpPost]
        public async Task<IActionResult> PostRestaurant([FromBody] Restaurant restaurant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Restaurants.Add(restaurant);
            await _context.SaveChangesAsync();
            var ans = _context.Restaurants.Count();
            await hubContext.Clients.All.SendAsync("RecieveRestaurant", ans);

            return CreatedAtAction("GetRestaurant", new { id = restaurant.Id }, restaurant);
        }

        // DELETE: api/Restaurants/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRestaurant([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var restaurant = await _context.Restaurants.FindAsync(id);
            if (restaurant == null)
            {
                return NotFound();
            }

            _context.Restaurants.Remove(restaurant);
            await _context.SaveChangesAsync();

            var ans = _context.Restaurants.Count();
            await hubContext.Clients.All.SendAsync("RecieveRestaurant", ans);

            return Ok(restaurant);
        }

        private bool RestaurantExists(int id)
        {
            return _context.Restaurants.Any(e => e.Id == id);
        }
    }
}
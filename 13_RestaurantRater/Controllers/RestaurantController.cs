using _13_RestaurantRater.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace _13_RestaurantRater.Controllers
{
    // API controller just deals with data
    // MVC controller (red badge) also returns views (HTML/CSS/JS)
    public class RestaurantController : ApiController
    {
        private readonly RestaurantDbContext _context = new RestaurantDbContext();

        // Create (Post)
        [HttpPost]
        public async Task<IHttpActionResult> PostRestaurant(Restaurant model)
        {
            if (ModelState.IsValid)
            {
                _context.Restaurants.Add(model);
                await _context.SaveChangesAsync();

                return Ok(); // 200
            }
            return BadRequest(ModelState); // 400
        }
        // Read (Get)
        [HttpGet]
        public async Task<IHttpActionResult> GetAllRestaurants()
        {
            List<Restaurant> restaurants = await _context.Restaurants.ToListAsync();
            List<RestaurantListItem> restaurantList =
                restaurants.Select(r => new RestaurantListItem()
                {
                    Name = r.Name,
                    Address = r.Address,
                    Rating = r.Rating,
                    Id = r.Id,
                }).ToList();

            return Ok(restaurantList);
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetRestaurantById(int id)
        {
            Restaurant restaurant = await _context.Restaurants.FindAsync(id);

            // Make a RestaurantDetail model that allows this method to work 
            // without crashing again
            if (restaurant == default)
            {
                return NotFound(); // 404
            }

            // Don't return this.
            return Ok(restaurant); // 200
        }
        // Race condition - two async tasks happening, not sure which will take longer

        // Update (Put)
        [HttpPut]
        public async Task<IHttpActionResult> UpdateRestaurant
            ([FromUri] int id, [FromBody] Restaurant model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Restaurant restaurant = await _context.Restaurants.FindAsync(id);

            if (restaurant == null)
            {
                return NotFound();
            }
            restaurant.Name = model.Name;
            restaurant.Address = model.Address;

            await _context.SaveChangesAsync();
            
            return Ok();
        }
        // Delete
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteRestaurant(int id)
        {
            Restaurant restaurant = await _context.Restaurants.FindAsync(id);
            if (restaurant == default)
            {
                return NotFound(); // 404
            }
            _context.Restaurants.Remove(restaurant);

            if (await _context.SaveChangesAsync() == 1)
            {
                return Ok();
            }
            return InternalServerError();
        }
    }
}

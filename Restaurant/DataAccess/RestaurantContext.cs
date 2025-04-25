using Microsoft.EntityFrameworkCore;

namespace Restaurant.DataAccess
{
    public class RestaurantContext : DbContext
    {
        public RestaurantContext(DbContextOptions<RestaurantContext> options) : base(options)
        {
        }
        public DbSet<Entities.Meal> Meals { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using Restaurant.DataAccess;
using Restaurant.DataAccess.Entities;

namespace Restaurant.Repositories
{
    public interface IMealRepository
    {
        Task<List<Meal>> GetAllAsync();
        Task<Meal?> GetByIdAsync(int id);
        Task AddAsync(Meal meal);
        Task UpdateAsync(Meal meal);
        Task DeleteAsync(int id);
    }
    public class MealRepository : IMealRepository
    {
        private readonly RestaurantContext _context;

        public MealRepository(RestaurantContext context)
        {
            _context = context;
        }

        public async Task<List<Meal>> GetAllAsync()
        {
            return await _context.Meals.ToListAsync();
        }

        public async Task<Meal?> GetByIdAsync(int id)
        {
            return await _context.Meals.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task AddAsync(Meal meal)
        {
            _context.Meals.Add(meal);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Meal meal)
        {
            _context.Meals.Update(meal);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var meal = await GetByIdAsync(id);
            if (meal != null)
            {
                _context.Meals.Remove(meal);
                await _context.SaveChangesAsync();
            }
        }
    }
}

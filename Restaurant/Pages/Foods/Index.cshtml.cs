using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Restaurant.DataAccess.Entities;
using Restaurant.Repositories;

namespace Restaurant.Pages.Foods
{
    public class IndexModel : PageModel
    {
        private readonly IMealRepository _repo;

        public IndexModel(IMealRepository repo)
        {
            _repo = repo;
        }

        public List<Meal> Meals { get; set; } = new();

        [BindProperty]
        public Meal NewMeal { get; set; } = new();

        public async Task OnGetAsync()
        {
            Meals = await _repo.GetAllAsync();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Meals = await _repo.GetAllAsync();
                return Page();
            }

            if (NewMeal.Id == 0)
            {
                // New meal — add it
                await _repo.AddAsync(NewMeal);
            }
            else
            {
                // Existing meal — update it
                await _repo.UpdateAsync(NewMeal);
            }

            return RedirectToPage(); // Clear the form and refresh
        }


        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            await _repo.DeleteAsync(id);
            return RedirectToPage();
        }

    }
}
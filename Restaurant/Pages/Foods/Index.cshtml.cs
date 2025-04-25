using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Restaurant.DataAccess.Entities;
using Restaurant.Repositories;

namespace Restaurant.Pages.Foods
{
    public class IndexModel : PageModel
    {
        private readonly IMealRepository _repo;
        private readonly IMapper _mapper;
        public IndexModel(IMealRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public List<MealDto> Meals { get; set; } = new();

        [BindProperty]
        public MealDto NewMeal { get; set; } = new();

        public async Task OnGetAsync()
        {
            var mealEntities = await _repo.GetAllAsync();
            Meals = _mapper.Map<List<MealDto>>(mealEntities);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                var mealEntities = await _repo.GetAllAsync();
                Meals = _mapper.Map<List<MealDto>>(mealEntities);
                return Page();
            }

            var entity = _mapper.Map<Meal>(NewMeal);

            if (entity.Id == 0)
            {
                await _repo.AddAsync(entity);
            }
            else
            {
                await _repo.UpdateAsync(entity);
            }

            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            await _repo.DeleteAsync(id);
            return RedirectToPage();
        }
    }
}

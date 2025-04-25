using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Restaurant.Pages
{
    public class SignInModel : PageModel
    {
        public IActionResult OnPost()
        {
            return RedirectToPage("/Index");
        }
    }
}

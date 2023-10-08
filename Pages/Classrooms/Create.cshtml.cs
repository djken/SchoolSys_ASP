using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolSysMo.Models;

namespace SchoolSysMo.Pages.Classrooms
{
    public class CreateModel : PageModel
    {
        private readonly SchoolSysMoContext _context;

        public CreateModel(SchoolSysMoContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public List<Classroom> Classrooms { get; set; } = new List<Classroom>() { new Classroom() };


        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            foreach (var classroom in Classrooms)
            {
                _context.Classroom.Add(classroom);
            }
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

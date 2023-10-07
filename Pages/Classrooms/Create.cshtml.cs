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

        public Classroom Classroom { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Classroom == null || Classroom == null)
            {
                return Page();
            }

            _context.Classroom.Add(Classroom);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

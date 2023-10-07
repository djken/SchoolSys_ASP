using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SchoolSysMo.Models;

namespace SchoolSysMo.Pages.Grades
{
    public class DeleteModel : PageModel
    {
        private readonly SchoolSysMoContext _context;

        public DeleteModel(SchoolSysMoContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Grade Grade { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Grade == null)
            {
                return NotFound();
            }

            var grade = await _context.Grade.FirstOrDefaultAsync(m => m.GradeId == id);

            if (grade == null)
            {
                return NotFound();
            }
            else 
            {
                Grade = grade;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Grade == null)
            {
                return NotFound();
            }
            var grade = await _context.Grade.FindAsync(id);

            if (grade != null)
            {
                Grade = grade;
                _context.Grade.Remove(Grade);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

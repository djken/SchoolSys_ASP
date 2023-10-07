using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SchoolSysMo.Models;

namespace SchoolSysMo.Pages.Classrooms
{
    public class DeleteModel : PageModel
    {
        private readonly SchoolSysMoContext _context;

        public DeleteModel(SchoolSysMoContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Classroom Classroom { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Classroom == null)
            {
                return NotFound();
            }

            var classroom = await _context.Classroom.FirstOrDefaultAsync(m => m.ClassroomId == id);

            if (classroom == null)
            {
                return NotFound();
            }
            else 
            {
                Classroom = classroom;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Classroom == null)
            {
                return NotFound();
            }
            var classroom = await _context.Classroom.FindAsync(id);

            if (classroom != null)
            {
                Classroom = classroom;
                _context.Classroom.Remove(Classroom);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

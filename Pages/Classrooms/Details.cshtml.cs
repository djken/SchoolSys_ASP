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
    public class DetailsModel : PageModel
    {
        private readonly SchoolSysMoContext _context;

        public DetailsModel(SchoolSysMoContext context)
        {
            _context = context;
        }

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
    }
}

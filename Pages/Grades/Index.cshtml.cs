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
    public class IndexModel : PageModel
    {
        private readonly SchoolSysMoContext _context;

        public IndexModel(SchoolSysMoContext context)
        {
            _context = context;
        }

        public IList<Grade> Grade { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Grade != null)
            {
                Grade = await _context.Grade
                .Include(g => g.Course).ToListAsync();
            }
        }
    }
}

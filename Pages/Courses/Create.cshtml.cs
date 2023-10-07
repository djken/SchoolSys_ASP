﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SchoolSysMo.Models;

namespace SchoolSysMo.Pages.Courses
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
            ViewData["ClassroomId"] = new SelectList(_context.Classroom, "ClassroomId", "Name");
            return Page();
        }

        [BindProperty]
        public Course Course { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Course == null || Course == null)
            {
                return Page();
            }

            _context.Course.Add(Course);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

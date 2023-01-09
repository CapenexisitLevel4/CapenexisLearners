using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CapenexisLearners.Data;
using CapenexisLearners.Models;

namespace CapenexisLearners.Pages.Level5Learner
{
    public class EditModel : PageModel
    {
        private readonly CapenexisLearners.Data.CapenexisLearnersContext _context;

        public EditModel(CapenexisLearners.Data.CapenexisLearnersContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Level5Learner Level5Learners { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Level5Learners == null)
            {
                return NotFound();
            }

            var level5learners =  await _context.Level5Learners.FirstOrDefaultAsync(m => m.Id == id);
            if (level5learners == null)
            {
                return NotFound();
            }
            Level5Learners = level5learners;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Level5Learners).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Level5LearnersExists(Level5Learners.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool Level5LearnersExists(int id)
        {
          return (_context.Level5Learners?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

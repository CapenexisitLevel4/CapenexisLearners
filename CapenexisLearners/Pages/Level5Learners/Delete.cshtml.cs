using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CapenexisLearners.Data;
using CapenexisLearners.Models;

namespace CapenexisLearners.Pages.Level5Learner
{
    public class DeleteModel : PageModel
    {
        private readonly CapenexisLearners.Data.CapenexisLearnersContext _context;

        public DeleteModel(CapenexisLearners.Data.CapenexisLearnersContext context)
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

            var level5learners = await _context.Level5Learners.FirstOrDefaultAsync(m => m.Id == id);

            if (level5learners == null)
            {
                return NotFound();
            }
            else 
            {
                Level5Learners = level5learners;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Level5Learners == null)
            {
                return NotFound();
            }
            var level5learners = await _context.Level5Learners.FindAsync(id);

            if (level5learners != null)
            {
                Level5Learners = level5learners;
                _context.Level5Learners.Remove(Level5Learners);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

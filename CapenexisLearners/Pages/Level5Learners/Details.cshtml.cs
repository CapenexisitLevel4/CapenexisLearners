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
    public class DetailsModel : PageModel
    {
        private readonly CapenexisLearners.Data.CapenexisLearnersContext _context;

        public DetailsModel(CapenexisLearners.Data.CapenexisLearnersContext context)
        {
            _context = context;
        }

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
    }
}

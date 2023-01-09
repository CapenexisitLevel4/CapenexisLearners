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
    public class IndexModel : PageModel
    {
        private readonly CapenexisLearners.Data.CapenexisLearnersContext _context;

        public IndexModel(CapenexisLearners.Data.CapenexisLearnersContext context)
        {
            _context = context;
        }

        public IList<Level5Learner> Level5Learners { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Level5Learners != null)
            {
                Level5Learners = await _context.Level5Learner.ToListAsync();
            }
        }
    }
}

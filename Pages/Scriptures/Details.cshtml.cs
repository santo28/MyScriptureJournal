using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesJournal.Data;
using ScriptureJournal.Models;

namespace MyScriptureJournal.Pages.Scriptures
{
    public class DetailsModel : PageModel
    {
        private readonly RazorPagesJournal.Data.RazorPagesJournalContext _context;

        public DetailsModel(RazorPagesJournal.Data.RazorPagesJournalContext context)
        {
            _context = context;
        }

      public Journal Journal { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Journal == null)
            {
                return NotFound();
            }

            var journal = await _context.Journal.FirstOrDefaultAsync(m => m.ID == id);
            if (journal == null)
            {
                return NotFound();
            }
            else 
            {
                Journal = journal;
            }
            return Page();
        }
    }
}

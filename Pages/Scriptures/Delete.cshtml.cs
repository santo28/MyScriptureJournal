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
    public class DeleteModel : PageModel
    {
        private readonly RazorPagesJournal.Data.RazorPagesJournalContext _context;

        public DeleteModel(RazorPagesJournal.Data.RazorPagesJournalContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Journal == null)
            {
                return NotFound();
            }
            var journal = await _context.Journal.FindAsync(id);

            if (journal != null)
            {
                Journal = journal;
                _context.Journal.Remove(Journal);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesJournal.Data;
using ScriptureJournal.Models;

namespace MyScriptureJournal.Pages.Scriptures
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesJournal.Data.RazorPagesJournalContext _context;

        public IndexModel(RazorPagesJournal.Data.RazorPagesJournalContext context)
        {
            _context = context;
        }

        public IList<Journal> Journal { get;set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }
        // Requires using Microsoft.AspNetCore.Mvc.Rendering;
        public SelectList? Book { get; set; }

          [BindProperty(SupportsGet = true)]
        public string Comments { get; set; }

        public async Task OnGetAsync()
        {
              // Use LINQ to get list of genres.
            IQueryable<string> bookQuery = from m in _context.Journal
                orderby m.Book
                select m.Book;

            var books = from m in _context.Journal
                select m;

            if (!string.IsNullOrEmpty(SearchString))
            {
                books = books.Where(s => s.Comments.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(Comments))
            {
                books = books.Where(x => x.Book == Comments);
            }
            Book = new SelectList(await bookQuery.Distinct().ToListAsync());
            Journal = await books.ToListAsync();
        }
    }
}

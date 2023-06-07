using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ScriptureJournal.Models;

namespace RazorPagesJournal.Data
{
    public class RazorPagesJournalContext : DbContext
    {
        public RazorPagesJournalContext (DbContextOptions<RazorPagesJournalContext> options)
            : base(options)
        {
        }

        public DbSet<ScriptureJournal.Models.Journal> Journal { get; set; } = default!;
    }
}

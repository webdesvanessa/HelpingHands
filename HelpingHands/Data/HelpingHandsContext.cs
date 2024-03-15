using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HelpingHands;

namespace HelpingHands.Data
{
    public class HelpingHandsContext : DbContext
    {
        public HelpingHandsContext (DbContextOptions<HelpingHandsContext> options)
            : base(options)
        {
        }

        public DbSet<HelpingHands.WorkerProfile_CLASS> WorkerProfile_CLASS { get; set; } = default!;
    }
}

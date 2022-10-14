using Microsoft.EntityFrameworkCore;
using System;

namespace KundeApp1.Models
{
    public class KundeDB :DbContext
    {
        public KundeDB (DbContextOptions<KundeDB> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Kunde> Kunder { get; set; }
    }
}


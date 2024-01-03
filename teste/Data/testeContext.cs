using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using teste.Models;

namespace teste.Data
{
    public class testeContext : DbContext
    {
        public testeContext (DbContextOptions<testeContext> options)
            : base(options)
        {
        }

        public DbSet<teste.Models.Teste> Teste { get; set; } = default!;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Miroșnicenco_Eugenia_Lab2.Models;

namespace Miroșnicenco_Eugenia_Lab2.Data
{
    public class Miroșnicenco_Eugenia_Lab2Context : DbContext
    {
        public Miroșnicenco_Eugenia_Lab2Context (DbContextOptions<Miroșnicenco_Eugenia_Lab2Context> options)
            : base(options)
        {
        }

        public DbSet<Miroșnicenco_Eugenia_Lab2.Models.Book> Book { get; set; } = default!;
		public DbSet<Miroșnicenco_Eugenia_Lab2.Models.Customer> Customer { get; set; } = default!;
		public DbSet<Miroșnicenco_Eugenia_Lab2.Models.Genre> Genre { get; set; } = default!;
        public DbSet<Miroșnicenco_Eugenia_Lab2.Models.Author> Author { get; set; } = default!;
        public DbSet<Miroșnicenco_Eugenia_Lab2.Models.Order> Order { get; set; } = default!;
    }
}

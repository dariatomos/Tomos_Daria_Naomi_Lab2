using Microsoft.EntityFrameworkCore;
using Tomos_Daria_Naomi_Lab2.Models;

namespace Tomos_Daria_Naomi_Lab2.Data
{
    public class Tomos_Daria_Naomi_Lab2Context : DbContext
    {
        public Tomos_Daria_Naomi_Lab2Context(DbContextOptions<Tomos_Daria_Naomi_Lab2Context> options)
            : base(options)
        {
        }

        public DbSet<Book> Book { get; set; } = default!;
        public DbSet<Publisher> Publisher { get; set; } = default!;

        public DbSet<Author> Author { get; set; } = default!;
    }
}
using Microsoft.EntityFrameworkCore;
using WorkParser.Entity;

namespace WorkParser.DataBase
{
    public class VacancyDbContext : DbContext
    {
        public DbSet<Vacancy> Vacances { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=LAPTOP-7EADQT2O;Database=Parse;Trusted_Connection=True");
        }


    }
}

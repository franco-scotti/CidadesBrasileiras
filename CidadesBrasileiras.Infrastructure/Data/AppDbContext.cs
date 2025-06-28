using Microsoft.EntityFrameworkCore;
using CidadesBrasileiras.Core.Models;

namespace CidadesBrasileiras.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Estado> Estados { get; set; }
        public DbSet<Municipio> Municipios { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Estado>().HasKey(e => e.Id);
            modelBuilder.Entity<Municipio>().HasKey(m => m.Id);

            modelBuilder.Entity<Municipio>()
                .HasOne(m => m.Estado)
                .WithMany(e => e.Municipios)
                .HasForeignKey(m => m.IdEstado);
        }
    }
}

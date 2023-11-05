using desafioBackend7Alura.Entities;
using Microsoft.EntityFrameworkCore;

namespace desafioBackend7Alura.Data.Context;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
    }

    public virtual DbSet<Depoimento> Depoimentos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        #region Depoimentos

        modelBuilder.Entity<Depoimento>().ToTable("Depoimentos");

        modelBuilder.Entity<Depoimento>().Property(x => x.Id);
        modelBuilder.Entity<Depoimento>().HasKey(x => x.Id);
        modelBuilder.Entity<Depoimento>().HasIndex(x => x.Id).IsUnique();

        modelBuilder.Entity<Depoimento>().Property(x => x.NomePessoa).IsRequired().HasMaxLength(64);

        modelBuilder.Entity<Depoimento>().Property(x => x.ConteudoDepoimento).IsRequired();

        modelBuilder.Entity<Depoimento>().Property(x => x.Foto).IsRequired();
        modelBuilder.Entity<Depoimento>().Property(x => x.CriadoEm).IsRequired();

        #endregion
    }
}
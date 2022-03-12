using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Inf_Portfolio_Service.Models
{
    public partial class PortfolioDbContext : DbContext
    {
        public virtual DbSet<Portfolio> Portfolios { get; set; }
        public virtual DbSet<Stock> Stocks { get; set; }

        public PortfolioDbContext()
        {
        }

        public PortfolioDbContext(DbContextOptions<PortfolioDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.\\sqlexpress; Database=PortfolioDb; Trusted_Connection=True; Integrated Security=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);

            modelBuilder.Entity<Portfolio>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(50);
                entity.Property(e => e.Guid).IsRequired();
                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.Code).IsRequired();
            });

            modelBuilder.Entity<Stock>(entity =>
            {
                entity.Property(e => e.Symbol).IsRequired();
                entity.Property(e => e.Name).IsRequired();

            });

            modelBuilder.Entity<Stock>()
                .HasOne(p => p.Portfolio)
                .WithMany(b => b.Stocks)
                .HasForeignKey(p => p.PortfolioId)
                .HasPrincipalKey(b => b.Guid);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

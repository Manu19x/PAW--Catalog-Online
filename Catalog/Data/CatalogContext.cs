using Microsoft.EntityFrameworkCore;
using Catalog.Models;

namespace Catalog.Data
{
    public class CatalogContext : DbContext
    {
        public CatalogContext(DbContextOptions<CatalogContext> options) : base(options) { }

        public DbSet<UserAccount> UserAccounts { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Profesor> Profesori { get; set; }
        public DbSet<Secretar> Secretari { get; set; }
        public DbSet<Moderator> Moderatori { get; set; }
        public DbSet<Curs> Cursuri { get; set; }
        public DbSet<InscriereCurs> InscrieriCursuri { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InscriereCurs>()
                .HasKey(ic => new { ic.StudentID, ic.CursID });

            modelBuilder.Entity<InscriereCurs>()
                .HasOne(ic => ic.Student)
                .WithMany(s => s.InscrieriCursuri)
                .HasForeignKey(ic => ic.StudentID)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<InscriereCurs>()
                .HasOne(ic => ic.Curs)
                .WithMany(c => c.InscrieriCursuri)
                .HasForeignKey(ic => ic.CursID)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Student>()
                .HasOne(s => s.UserAccount)
                .WithMany(u => u.Students)
                .HasForeignKey(s => s.UserID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Profesor>()
                .HasOne(p => p.UserAccount)
                .WithMany(u => u.Profesori)
                .HasForeignKey(p => p.UserID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Secretar>()
                .HasOne(s => s.UserAccount)
                .WithMany(u => u.Secretari)
                .HasForeignKey(s => s.UserID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Moderator>()
                .HasOne(m => m.UserAccount)
                .WithMany(u => u.Moderatori)
                .HasForeignKey(m => m.UserID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Curs>()
                .HasOne(c => c.Profesor)
                .WithMany(p => p.Cursuri)
                .HasForeignKey(c => c.ProfesorID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

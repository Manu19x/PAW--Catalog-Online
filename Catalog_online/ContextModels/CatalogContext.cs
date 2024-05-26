using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Catalog_online.Models;

public class CatalogContext : IdentityDbContext<UserModel>
{
    public DbSet<Role> Roles { get; set; }

    public CatalogContext(DbContextOptions<CatalogContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Role>().HasData(
            new Role { RoleId = 1, RoleName = "Student" },
            new Role { RoleId = 2, RoleName = "Profesor" },
            new Role { RoleId = 3, RoleName = "Secretar" },
            new Role { RoleId = 4, RoleName = "Moderator" }
        );
    }
}

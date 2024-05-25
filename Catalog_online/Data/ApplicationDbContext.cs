using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Catalog_online.Data // Asigură-te că namespace-ul este corect
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Adaugă DbSet-uri pentru modelele tale, dacă ai
        // public DbSet<SomeModel> SomeModels { get; set; }
    }
}

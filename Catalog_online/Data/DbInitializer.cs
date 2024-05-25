using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog_online.Data
{
    public static class DbInitializer
    {
        public static async Task InitializeAsync(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<ApplicationDbContext>();
            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            context.Database.EnsureCreated();

            // Verifică dacă există roluri
            string[] roleNames = { "Student", "Profesor", "Secretar", "Moderator" };
            IdentityResult roleResult;

            foreach (var roleName in roleNames)
            {
                var roleExist = await roleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    roleResult = await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            // Crearea utilizatorilor și atribuirea rolurilor
            await CreateUserAsync(userManager, "student@example.com", "Password123!", "Student");
            await CreateUserAsync(userManager, "profesor@example.com", "Password123!", "Profesor");
            await CreateUserAsync(userManager, "secretar@example.com", "Password123!", "Secretar");
            await CreateUserAsync(userManager, "moderator@example.com", "Password123!", "Moderator");
        }

        private static async Task CreateUserAsync(UserManager<IdentityUser> userManager, string email, string password, string role)
        {
            if (userManager.Users.All(u => u.UserName != email))
            {
                var user = new IdentityUser { UserName = email, Email = email };
                var result = await userManager.CreateAsync(user, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, role);
                }
            }
        }
    }
}

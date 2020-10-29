using Microsoft.AspNetCore.Identity;
using MovieHub.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieHub.Models
{
    public static class MyIdentityDataInitializer
    {
        public static void SeedData(UserManager<RegistrovaniKorisnik> userManager, RoleManager<IdentityRole> roleManager, ApplicationDbContext context)
        {
            context.Database.EnsureCreated();
            SeedRoles(roleManager);
            SeedUsers(userManager);
        }

        public static void SeedUsers(UserManager<RegistrovaniKorisnik> userManager)
        {
            if (userManager.FindByNameAsync("admin@admin.com").Result == null)
            {
                RegistrovaniKorisnik user = new RegistrovaniKorisnik();
                user.UserName = "admin@admin.com";
                user.Email = "admin@admin.com";
                user.Ime = "Admin";
                user.EmailConfirmed = true;
                user.AppUsername = "administator";
                user.Prezime = "Adminkovic";
                user.DatumRodjenja = new DateTime(1999, 1, 1);
                IdentityResult result = userManager.CreateAsync(user, "!Admin123").Result;
                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Administrator").Wait();
                }
            }
        }

        public static void SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync ("Administrator").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Administrator";
                IdentityResult roleResult = roleManager.
                CreateAsync(role).Result;
            }
        }
    }
}

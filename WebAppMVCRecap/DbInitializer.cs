using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace WebAppMVCRecap
{
    internal class DbInitializer
    {
        internal static void Initialize(DbContext context, Microsoft.AspNetCore.Identity.RoleManager<Microsoft.AspNetCore.Identity.IdentityRole> roleManager, Microsoft.AspNetCore.Identity.UserManager<Microsoft.AspNetCore.Identity.IdentityUser> userManager)
        {
            if (!roleManager.RoleExistsAsync("Admin").Result)
            {
                IdentityRole role = new IdentityRole("Admin");

                roleManager.CreateAsync(role).Wait();
            }

            if (!roleManager.RoleExistsAsync("NormalUser").Result)
            {
                IdentityRole role = new IdentityRole("NormalUser");

                roleManager.CreateAsync(role).Wait();
            }

            //------------------------------------------------------------------------------------//

            if (userManager.FindByNameAsync("Abduallah").Result == null)
            {
                IdentityUser user = new IdentityUser();
                user.Email = "Abduallah@admin.se";
                user.UserName = "Abduallah";

                IdentityResult result = userManager.CreateAsync(user, "Abduallah1996-").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Admin").Wait();
                }
            }

            if (userManager.FindByNameAsync("Abdullah").Result == null)
            {
                IdentityUser user = new IdentityUser();
                user.Email = "Abdullah@admin.se";
                user.UserName = "Abdullah";


                var result = userManager.CreateAsync(user, "Abduallah1996-");

                if (result.IsCompletedSuccessfully)
                {
                    userManager.AddToRoleAsync(user, "NormalUser").Wait();
                }
            }
            //------------------------------------------------------------------------------------------

            //Glöm inte att spara
            //context.SaveChanges();
        }
    }
}
using Microsoft.AspNetCore.Identity;
using Ramazan.ToDo.Entittes.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Ramazan.ToDo.Web
{
    public static class IdentityInitializer
    {
        public static async Task SeedData(UserManager<AppUser> userManager,RoleManager<AppRole> roleManager)
        {
            var adminRole = await roleManager.FindByNameAsync("Admin");
            if(adminRole == null)
            {
                await roleManager.CreateAsync(new AppRole
                {
                    Name = "Admin"
                });
            }

            var memberRole = await roleManager.FindByNameAsync("Member");
            if (memberRole == null)
            {
                await roleManager.CreateAsync(new AppRole
                {
                    Name = "Member"
                });
            }

            var adminUser = await userManager.FindByNameAsync("ramazan");
            if(adminUser == null)
            {
                AppUser user = new AppUser
                {
                    Name = "Ramazan",
                    SurName = "Sert",
                    Email = "ramazan.sert@gmail.com",
                    UserName ="ramazan"
                };
                await userManager.CreateAsync(user,"1");
                await userManager.AddToRoleAsync(user, "Admin");
            }
            
        }
    }
}

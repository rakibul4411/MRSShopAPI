using FwCore.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

namespace FwCore.Identity
{
    public class Seedvalue
    {
        public static async Task Initialize(AppIdentityDbContext context,
                              UserManager<AppUser> userManager,
                              RoleManager<AppRole> roleManager)
        {
            context.Database.EnsureCreated();

            String adminId1 = "";
            String adminId2 = "";

            string role1 = "Admin";
            string desc1 = "This is the administrator role";

            string role2 = "Operator";
            string desc2 = "This is the members role";

            string role3 = "User";
            string desc3 = "Maintain user activity";

            string password = "Rakib123.";
            if (await roleManager.FindByNameAsync(role1) == null)
            {
                await roleManager.CreateAsync(new AppRole(role1, desc1, DateTime.Now));
            }
            if (await roleManager.FindByNameAsync(role2) == null)
            {
                await roleManager.CreateAsync(new AppRole(role2, desc2, DateTime.Now));
            }
            if (await roleManager.FindByNameAsync(role3) == null)
            {
                await roleManager.CreateAsync(new AppRole(role3, desc3, DateTime.Now));
            }

            if (await userManager.FindByNameAsync("http.rakib@gmail.com") == null)
            {
                var user = new AppUser
                {
                    UserName = "http.rakib@gmail.com",
                    Email = "http.rakib@gmail.com",
                    FirstName = "Rakibul",
                    LastName = "Islam",
                    Street = "Razabazer",
                    City = "Dhake",
                    PostalCode = "1215",
                    Country = "Bangladesh",
                    PhoneNumber = "+8801737104448"
                };

                var result = await userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    await userManager.AddPasswordAsync(user, password);
                    await userManager.AddToRoleAsync(user, role1);
                }
                adminId1 = user.Id;
            }

            if (await userManager.FindByNameAsync("http.gazi@gmail.com") == null)
            {
                var user = new AppUser
                {
                    UserName = "http.gazi@gmail.com",
                    Email = "http.gazi@gmail.com",
                    FirstName = "Farid",
                    LastName = "Uddin",
                    Street = "Razabazer",
                    City = "Dhake",
                    PostalCode = "1215",
                    Country = "Bangladesh",
                    PhoneNumber = "+8801783881623"
                };

                var result = await userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    await userManager.AddPasswordAsync(user, password);
                    await userManager.AddToRoleAsync(user, role1);
                }
                adminId2 = user.Id;
            }

            if (await userManager.FindByNameAsync("http.golap@gmail.com") == null)
            {
                var user = new AppUser
                {
                    UserName = "http.golap@gmail.com",
                    Email = "http.golap@gmail.com",
                    FirstName = "Golap",
                    LastName = "Mostofa",
                    Street = "Razabazer",
                    City = "Dhake",
                    PostalCode = "1215",
                    Country = "Bangladesh",
                    PhoneNumber = "+8801765910578"
                };

                var result = await userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    await userManager.AddPasswordAsync(user, password);
                    await userManager.AddToRoleAsync(user, role2);
                }
            }

            if (await userManager.FindByNameAsync("https.mizan@gmail.com") == null)
            {
                var user = new AppUser
                {
                    UserName = "https.mizan@gmail.com",
                    Email = "https.mizan@gmail.com",
                    FirstName = "Mizan",
                    LastName = "Khan",
                    Street = "Razabazer",
                    City = "Dhake",
                    PostalCode = "1215",
                    Country = "Bangladesh",
                    PhoneNumber = "+8801765910578"
                };

                var result = await userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    await userManager.AddPasswordAsync(user, password);
                    await userManager.AddToRoleAsync(user, role3);
                }
            }
        }

    }
}

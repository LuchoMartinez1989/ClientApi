using Application.ENUMs;
using Identity.Models;
using Microsoft.AspNetCore.Identity;

namespace Identity.Seeds
{
    public static class DefaultAdministratorUser
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            var defaultUser = new ApplicationUser
            {
                UserName = "userAdministrator",
                Email = "admin@gmail.com",
                FirstName = "FirstName Administrator",
                Lastname = "LastName Administrator",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };

            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultUser, "123");
                    await userManager.AddToRoleAsync(defaultUser, Roles.Administrator.ToString());
                }
            }
        }

    }
}
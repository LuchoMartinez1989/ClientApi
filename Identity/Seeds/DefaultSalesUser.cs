using Application.ENUMs;
using Identity.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Seeds
{
    public static class DefaultSalesUser
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userSales, RoleManager<IdentityRole> roleSales)
        {
            var defaultUser = new ApplicationUser
            {
                UserName = "userSales",
                Email = "Sales@gmail.com",
                FirstName = "FirstName Sales",
                Lastname = "LastName Sales",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };

            if (userSales.Users.All(u => u.Id != defaultUser.Id))
            {
                var user = await userSales.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {
                    await userSales.CreateAsync(defaultUser, "P4$$w0rd");
                    await userSales.AddToRoleAsync(defaultUser, Roles.Sales.ToString());
                }
            }
        }

    }
}

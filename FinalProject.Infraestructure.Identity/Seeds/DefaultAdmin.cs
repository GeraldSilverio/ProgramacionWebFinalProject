using FinalProject.Core.Application.Enums;
using FinalProject.Infraestructure.Identity.Entities;
using Microsoft.AspNetCore.Identity;

namespace FinalProject.Infraestructure.Identity.Seeds
{
    public static class DefaultAdmin
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            ApplicationUser defaultAdmin = new()
            {
                UserName = "Adamix",
                Email = "Adamix@gmail.com",
                Nombre = "Amadis",
                Apellido = "Genao",
                Cedula = "40233807253",
                EmailConfirmed = true,
                Direccion = "ITLA",
                EstadoCivil ="SOLTERO",
                PhoneNumber = "8298828733"

            };

            if(userManager.Users.All(x=> x.Id == defaultAdmin.Id))
            {
                var user = await userManager.FindByNameAsync(defaultAdmin.UserName);
                if (user is null)
                {
                    await userManager.CreateAsync(defaultAdmin, "123AdminC#");
                    await userManager.AddToRoleAsync(defaultAdmin,Roles.Admin.ToString());
                }
            }
        }
    }
}
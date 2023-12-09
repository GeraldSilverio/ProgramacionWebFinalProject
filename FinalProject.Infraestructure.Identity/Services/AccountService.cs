using FinalProject.Core.Application.DTOs;
using FinalProject.Core.Application.Enums;
using FinalProject.Core.Application.Interfaces.Services;
using FinalProject.Core.Application.ViewModel.User;
using FinalProject.Infraestructure.Identity.Context;
using FinalProject.Infraestructure.Identity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Infraestructure.Identity.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public readonly IdentityContext _identityContext;

        public AccountService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IdentityContext identityContext)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _identityContext = identityContext;
        }

        public async Task<AutheticationResponse> Authetication(AutheticationRequest request)
        {
            AutheticationResponse response = new AutheticationResponse
            {
                HasError = false,
            };
            var user = await _userManager.FindByNameAsync(request.Usuario);
            if (user is null)
            {
                response.HasError = true;
                response.Error = $"NO EXISTEN CUENTAS CON ESE NOMBRE DE USUARIO{request.Usuario}";
                return response;
            }
            var result = await _signInManager.PasswordSignInAsync(user.UserName, request.Contraseña, false, false);

            if (!result.Succeeded)
            {
                response.HasError = true;
                response.Error = "Credenciales Incorrectas";
                return response;
            }
            response.Id = user.Id;
            response.NombreUsuario = user.UserName;
            response.Correo = user.Email;
            response.Cedula = user.Cedula;
            response.Nombre = user.Nombre;
            response.Apellido = user.Apellido;
            response.Direccion = user.Direccion;

            var role = await _userManager.GetRolesAsync(user).ConfigureAwait(false);
            response.Roles = role.ToList();
            return response;
        }

        public async Task<RegisterResponse> Register(RegisterRequest request)
        {
            RegisterResponse response = new RegisterResponse()
            {
                HasError = false,
            };

            var userCorreo = await _userManager.FindByEmailAsync(request.Correo);
            if (userCorreo is not null)
            {
                response.Error = "ESTE CORREO ESTA EN USO";
                response.HasError = true;
                return response;
            }
            var userName = await _userManager.FindByNameAsync(request.NombreUsuario);
            if (userName is not null)
            {
                response.Error = "ESTE NOMBRE DE USUARIO ESTA EN USO";
                response.HasError = true;
                return response;
            }

            var user = new ApplicationUser
            {
                UserName = request.NombreUsuario,
                Email = request.Correo,
                PhoneNumber = request.Phone,
                Nombre = request.Nombre,
                Apellido = request.Apellido,
                Cedula = request.Cedula,
                EstadoCivil = request.EstadoCivil,
                Direccion = request.Direccion,
                EmailConfirmed = true,
            };

            var result = await _userManager.CreateAsync(user, "123456");
            if (result.Succeeded)
            {
                switch (request.SelectRole)
                {
                    case (int)Roles.Admin:
                        await _userManager.AddToRoleAsync(user, Roles.Admin.ToString());
                        break;

                    case (int)Roles.Abogado:
                        await _userManager.AddToRoleAsync(user, Roles.Abogado.ToString());
                        break;

                    case (int)Roles.Cliente:
                        await _userManager.AddToRoleAsync(user, Roles.Cliente.ToString());
                        break;
                }
            }
            else
            {
                response.Error = "Ocurrio un error";
                response.HasError = true;
                return response;
            }
            return response;
        }

        public async Task<List<SaveUserViewModel>> GetAllAsync()
        {
            var users = await _userManager.Users.ToListAsync();

            var usersResponse = users
                .Select(user => new SaveUserViewModel
                {
                    Id = user.Id,
                    Nombre = user.Nombre,
                    Apellido = user.Apellido,
                    Cedula = user.Cedula,
                    Direccion = user.Direccion,
                    Correo = user.Email,
                    EstadoCivil = user.EstadoCivil,
                    Telefono = user.PhoneNumber,
                    NombreUsuario = user.UserName,
                    Roles = _userManager.GetRolesAsync(user).Result.ToList(),
                }).OrderByDescending(x => x.Id).ToList();

            return usersResponse;
        }

        public async Task<SaveUserViewModel> GetByIdAsync(string idUser)
        {
            var user = await _userManager.FindByIdAsync(idUser);

            var SaveUser = new SaveUserViewModel()
            {
                Id = user.Id,
                Nombre = user.Nombre,
                Apellido = user.Apellido,
                Cedula = user.Cedula,
                Direccion = user.Direccion,
                Correo = user.Email,
                EstadoCivil = user.EstadoCivil,
                Telefono = user.PhoneNumber,
                NombreUsuario = user.UserName,
            };
            return SaveUser;
        }
        public async Task UpdateAsync(SaveUserViewModel request, string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            #region User Attributes
            user.Nombre = request.Nombre;
            user.Apellido = request.Apellido;
            user.Cedula = request.Cedula;
            user.Email = request.Correo;
            user.UserName = request.NombreUsuario;
            user.EstadoCivil = request.EstadoCivil;
            user.PhoneNumber = request.Telefono;
            #endregion
            await _userManager.UpdateAsync(user);
        }
        public async Task DeleteAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            await _userManager.DeleteAsync(user);
        }
    }
}

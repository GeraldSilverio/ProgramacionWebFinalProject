using FinalProject.Core.Application.DTOs;
using FinalProject.Core.Application.Helpers;
using Microsoft.AspNetCore.Http;

namespace ProgramacionWebFinalProject.Middlewares
{
    public class ValidateUserSession
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ValidateUserSession(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public bool HasUser()
        {
            AutheticationResponse authenticationResponse = _httpContextAccessor.HttpContext.Session.Get<AutheticationResponse>("user");

            if (authenticationResponse == null)
            {
                return false;
            }
            return true;
        }
    }
}

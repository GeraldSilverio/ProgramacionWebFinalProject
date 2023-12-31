﻿using Microsoft.AspNetCore.Mvc.Filters;
using ProgramacionWebFinalProject.Controllers;

namespace ProgramacionWebFinalProject.Middlewares
{
    public class LoginAuthorize:IAsyncActionFilter
    {
        private readonly ValidateUserSession _validateUserSession;
        public LoginAuthorize(ValidateUserSession validateUserSession)
        {
            _validateUserSession = validateUserSession;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (_validateUserSession.HasUser())
            {
                var controller = (HomeController)context.Controller;

                context.Result = controller.RedirectToAction("Index", "Admin");
            }
            else
            {
                await next();
            }
        }
    }
}

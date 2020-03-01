using dotnet_g033.Models.Domain;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace dotnet_g033.Filters
{
    [AttributeUsageAttribute(AttributeTargets.All, AllowMultiple = false)]
    public class GebruikerFilter : ActionFilterAttribute
    {
        private readonly IGebruikerRepository _gebruikerRepository;

        public GebruikerFilter(IGebruikerRepository gebruikerRepository)
        {
            _gebruikerRepository = gebruikerRepository;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            context.ActionArguments["gebruiker"] = context.HttpContext.User.Identity.IsAuthenticated ?
                    _gebruikerRepository.GetByUsername(context.HttpContext.User.Identity.Name) : null;
            base.OnActionExecuting(context);
        }
    }
}

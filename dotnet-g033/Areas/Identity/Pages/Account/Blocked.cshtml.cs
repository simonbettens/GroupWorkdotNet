using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace dotnet_g033.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class BlockedModel : PageModel
    {
        public void OnGet()
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Ramazan.ToDo.Entittes.Concrete;

namespace Ramazan.ToDo.Web.BaseControllers
{
    public class BaseIdentityController : Controller
    {
        protected readonly UserManager<AppUser> _userManager;
        public BaseIdentityController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        protected async Task<AppUser> GetLoggedInUser()
        {
           return await _userManager.FindByNameAsync(User.Identity.Name);
        }

        protected void AddErrors(IEnumerable<IdentityError> errors)
        {

            foreach (var item in errors)
            {
                ModelState.AddModelError("", item.Description);
            }
        }
    }
}
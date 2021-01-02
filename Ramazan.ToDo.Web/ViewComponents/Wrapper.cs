using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Ramazan.ToDo.Business.Interfaces;
using Ramazan.ToDo.DTO.DTOs.AppUserDTOs;
using Ramazan.ToDo.Entittes.Concrete;

namespace Ramazan.ToDo.Web.ViewComponents
{
    public class Wrapper : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly INotificationService _notificationService;
        private readonly IMapper _mapper;
        public Wrapper(UserManager<AppUser> userManager, INotificationService notificationService, IMapper mapper)
        {
            _userManager = userManager;
            _notificationService = notificationService;
            _mapper = mapper;
        }
        public IViewComponentResult Invoke()
        {
            var identityUser = _userManager.FindByNameAsync(User.Identity.Name).Result;
            var model = _mapper.Map<AppUserListDto>(identityUser);

            ViewBag.NotificationCount = _notificationService.GetUnReadByUserId(identityUser.Id).Count;

            var roles = _userManager.GetRolesAsync(identityUser).Result;
            if (roles.Contains("Admin")) return View(model);
            return View("Member", model);
        }
    }
}

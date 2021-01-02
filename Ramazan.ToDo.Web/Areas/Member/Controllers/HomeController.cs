using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Ramazan.ToDo.Business.Interfaces;
using Ramazan.ToDo.Entittes.Concrete;
using Ramazan.ToDo.Web.BaseControllers;
using Ramazan.ToDo.Web.StringInfo;

namespace Ramazan.ToDo.Web.Areas.Member.Controllers
{
    [Area(AreaInfo.Member)]
    [Authorize(Roles = RoleInfo.Member)]
    public class HomeController : BaseIdentityController
    {
        private readonly IActionService _actionService;
        private readonly IWorkService _workService;
        private readonly INotificationService _notificationService;
        public HomeController(IActionService actionService, UserManager<AppUser> userManager, IWorkService workService, INotificationService notificationService):base(userManager)
        {
            _actionService = actionService;
            _workService = workService;
            _notificationService = notificationService;
        }
        public async Task<IActionResult> Index()
        {
            var user = await GetLoggedInUser();
            ViewBag.ActionCount = _actionService.GetActionCountByUserId(user.Id);
            ViewBag.FinishedWorkCount = _workService.GetFinishedWorkCountByUserId(user.Id);
            ViewBag.UnFinishedWorkCount = _workService.GetUnFinishedWorkCountByUserId(user.Id);
            ViewBag.UnReadNotificationCount = _notificationService.GetUnReadCountByUserId(user.Id);
            TempData["Active"] = TempDataInfo.Home;
            return View();
        }
    }
}
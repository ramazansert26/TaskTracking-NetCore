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

namespace Ramazan.ToDo.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = RoleInfo.Admin)]
    [Area(AreaInfo.Admin)]
    public class HomeController : BaseIdentityController
    {
        private readonly IWorkService _workService;
        private readonly INotificationService _notificationService;
        private readonly IActionService _actionService;
        public HomeController(IWorkService workService, INotificationService notificationService, UserManager<AppUser> userManager, IActionService actionService):base(userManager)
        {
            _workService = workService;
            _notificationService = notificationService;
            _actionService = actionService;
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.UnassignedWorkCount = _workService.GetUnassignedWorkCount();
            ViewBag.FinishedWorkCount = _workService.GetFinishedWorkCount();

            var user = await GetLoggedInUser();

            ViewBag.UnReadNotificationCount = _notificationService.GetUnReadCountByUserId(user.Id);
            ViewBag.ActionCount = _actionService.GetAllActionCount();
            TempData["Active"] = TempDataInfo.Home;
            return View();
        }

    }


}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Ramazan.ToDo.Business.Interfaces;
using Ramazan.ToDo.Web.StringInfo;

namespace Ramazan.ToDo.Web.Areas.Admin.Controllers
{
    [Area(AreaInfo.Admin)]
    [Authorize(Roles =RoleInfo.Admin)]
    public class GraphicController : Controller
    {

        private readonly IAppUserService _appUserService;
        public GraphicController(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }
        public IActionResult Index()
        {
            TempData["Active"] = TempDataInfo.Graphic;
            return View();
        }

        public IActionResult MostWorkFinishedUsers()
        {
            var jsonResult = JsonConvert.SerializeObject(_appUserService.GetMostWorkFinishedUsers());
            return Json(jsonResult);
        }
        public IActionResult MostWorkAssignedUsers()
        {
            var jsonResult = JsonConvert.SerializeObject(_appUserService.GetMostWorkAssginedUsers());
            return Json(jsonResult);
        }
    }
}
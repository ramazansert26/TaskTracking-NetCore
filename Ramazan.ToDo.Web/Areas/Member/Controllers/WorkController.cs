using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Ramazan.ToDo.Business.Interfaces;
using Ramazan.ToDo.DTO.DTOs.WorkDTOs;
using Ramazan.ToDo.Entittes.Concrete;
using Ramazan.ToDo.Web.BaseControllers;
using Ramazan.ToDo.Web.StringInfo;

namespace Ramazan.ToDo.Web.Areas.Member.Controllers
{
    [Authorize(Roles =RoleInfo.Member)]
    [Area(AreaInfo.Member)]
    public class WorkController : BaseIdentityController
    {
        private readonly IWorkService _workService;
        private readonly IMapper _mapper;
        public WorkController(IWorkService workService, UserManager<AppUser> userManager, IMapper mapper):base(userManager)
        {
            _workService = workService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index(int activePage = 1)
        {
            TempData["Active"] = TempDataInfo.Work;
            ViewBag.ActivePage = activePage;
            var user = await GetLoggedInUser();
            var works = _mapper.Map<List<WorkListAllDto>>(_workService.GetWithAllPropertyFinishedByUserId(out int totalPage, user.Id, activePage));
            ViewBag.TotalPage = totalPage;
            return View(works);
        }
    }
}
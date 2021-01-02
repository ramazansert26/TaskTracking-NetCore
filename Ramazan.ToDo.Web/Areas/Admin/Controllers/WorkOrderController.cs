using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Ramazan.ToDo.Business.Interfaces;
using Ramazan.ToDo.DTO.DTOs.ActionDTOs;
using Ramazan.ToDo.DTO.DTOs.AppUserDTOs;
using Ramazan.ToDo.DTO.DTOs.WorkDTOs;
using Ramazan.ToDo.Entittes.Concrete;
using Ramazan.ToDo.Web.BaseControllers;
using Ramazan.ToDo.Web.StringInfo;

namespace Ramazan.ToDo.Web.Areas.Admin.Controllers
{
    [Area(AreaInfo.Admin)]
    [Authorize(Roles = AreaInfo.Admin)]
    public class WorkOrderController : BaseIdentityController
    {
        private readonly IAppUserService _appUserService;
        private readonly IWorkService _workService;
        private readonly IFileService _fileService;
        private readonly INotificationService _notificationService;
        private readonly IMapper _mapper;

        public WorkOrderController(IAppUserService appUserService, IWorkService workService, UserManager<AppUser> userManager, IFileService fileService, INotificationService notificationService, IMapper mapper):base(userManager)
        {
            _appUserService = appUserService;
            _workService = workService;
            _fileService = fileService;
            _notificationService = notificationService;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            TempData["Active"] = TempDataInfo.WorkOrder;
            return View(_mapper.Map<List<WorkListAllDto>>(_workService.GetWithAllProperty()));
        }

        public IActionResult AssignUser(int id, string s, int page = 1)
        {
            TempData["Active"] = TempDataInfo.WorkOrder;
            int totalPage;
            ViewBag.ActivePage = page;
            ViewBag.Search = s;

            var personels = _mapper.Map<List<AppUserListDto>>(_appUserService.GetRoleNonAdmin(out totalPage, s, page));
            ViewBag.TotalPage = totalPage;
            ViewBag.Personels = personels;

            return View(_mapper.Map<WorkListDto>(_workService.FindByIdWithPriority(id)));
        }

        [HttpPost]
        public async Task<IActionResult> AssignUser(UserAssignDto model)
        {
            var work = _workService.FindById(model.WorkId);
            work.AppUserId = model.UserId;
            _workService.Update(work);

            var adminUser = await GetLoggedInUser();

            _notificationService.Save(new Notification
            {
                AppUserId = model.UserId,
                Description = $"{work.Name} adlı görev için {adminUser.Name} {adminUser.SurName} tarafından görevlendirildiniz.",
                Area = "Member",
                Controller = "WorkOrder",
                Action = "AddAction",
                DataId = work.Id

            });

            return RedirectToAction("Index");
        }
        public IActionResult AssignUserConfirm(UserAssignDto model)
        {
            TempData["Active"] = TempDataInfo.WorkOrder;
            UserAssignListDto assignUserModel = new UserAssignListDto
            {
                AppUser = _mapper.Map<AppUserListDto>(_userManager.Users.FirstOrDefault(I => I.Id == model.UserId)),
                Work = _mapper.Map<WorkListDto>(_workService.FindByIdWithPriority(model.WorkId))
            };

            return View(assignUserModel);
        }

        public IActionResult Details(int id)
        {
            TempData["Active"] = TempDataInfo.WorkOrder;
            return View(_mapper.Map<WorkListAllDto>(_workService.FindByIdWithActions(id)));
        }

        public IActionResult ExportExcel(int id)
        {
            return File(_fileService.ExportExcel(_mapper.Map<List<ActionExportDto>>(_workService.FindByIdWithActions(id).Actions)), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", Guid.NewGuid() + ".xlsx");
        }

        public IActionResult ExportPdf(int id)
        {
            var path = _fileService.ExportPdf(_mapper.Map<List<ActionExportDto>>(_workService.FindByIdWithActions(id).Actions));
            return File(path, "application/pdf", Guid.NewGuid() + ".pdf");
        }
    }
}
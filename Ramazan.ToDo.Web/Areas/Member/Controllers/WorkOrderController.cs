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
using Ramazan.ToDo.DTO.DTOs.WorkDTOs;
using Ramazan.ToDo.Entittes.Concrete;
using Ramazan.ToDo.Web.BaseControllers;
using Ramazan.ToDo.Web.StringInfo;
using Action = Ramazan.ToDo.Entittes.Concrete.Action;

namespace Ramazan.ToDo.Web.Areas.Member.Controllers
{
    [Area(AreaInfo.Member)]
    [Authorize(Roles = RoleInfo.Member)]
    public class WorkOrderController : BaseIdentityController
    {
        private readonly IWorkService _workService;
        private readonly IActionService _actionService;
        private readonly INotificationService _notificationService;
        private readonly IMapper _mapper;
        public WorkOrderController(IWorkService workService, UserManager<AppUser> userManager, IActionService actionService, INotificationService notificationService,
            IMapper mapper):base(userManager)
        {
            _workService = workService;
            _actionService = actionService;
            _notificationService = notificationService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            TempData["Active"] = TempDataInfo.WorkOrder;
            var user = await GetLoggedInUser();

            return View(_mapper.Map<List<WorkListAllDto>>(_workService.GetWithAllProperty(I => I.AppUserId == user.Id && !I.Finished)));
        }

        public IActionResult AddAction(int id)
        {
            TempData["Active"] = TempDataInfo.WorkOrder;
            ActionAddDto model = new ActionAddDto
            {
                WorkId = id,
                Work = _workService.FindByIdWithPriority(id)
            };
            return View(model);

        }

        [HttpPost]
        public async Task<IActionResult> AddAction(ActionAddDto model)
        {
            if (ModelState.IsValid)
            {
                _actionService.Save(new Action
                {
                    WorkId = model.WorkId,
                    Description = model.Description,
                    Detail = model.Detail,
                    TimeSpent = model.TimeSpent
                });
                var activeUser = await GetLoggedInUser();
                var adminUserList = await _userManager.GetUsersInRoleAsync("Admin");
                var work = _workService.FindById(model.WorkId);
                foreach (var admin in adminUserList)
                {
                    _notificationService.Save(new Notification
                    {
                        Description = $"{activeUser.Name} {activeUser.SurName} kullanıcısı {work.Name} görevi için yeni bir aksiyon aldı",
                        AppUserId = admin.Id,
                        Area = "Admin",
                        Controller = "WorkOrder",
                        Action = "Details",
                        DataId = model.WorkId
                    });
                }
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult UpdateAction(int id)
        {
            TempData["Active"] = TempDataInfo.WorkOrder;
            return View(_mapper.Map<ActionUpdateDto>(_actionService.FindByIdWithWork(id)));
        }

        [HttpPost]
        public IActionResult UpdateAction(ActionUpdateDto model)
        {
            if (ModelState.IsValid)
            {
                var action = _actionService.FindById(model.Id);

                action.Description = model.Description;
                action.Detail = model.Detail;
                action.TimeSpent = model.TimeSpent;
                _actionService.Update(action);

                return RedirectToAction("Index");
            }
            return View(model);
        }

        public async Task<IActionResult> CompleteWork(int workId)
        {
            var work = _workService.FindById(workId);
            work.Finished = true;
            _workService.Update(work);
            var activeUser = await GetLoggedInUser();
            var adminUserList = await _userManager.GetUsersInRoleAsync("Admin");
            foreach (var admin in adminUserList)
            {
                _notificationService.Save(new Notification
                {
                    Description = $"{activeUser.Name} {activeUser.SurName} bir görev tamamladı.Görev Adı: {work.Name}",
                    AppUserId = admin.Id,
                });
            }
            return Json(null);
        }



    }
}
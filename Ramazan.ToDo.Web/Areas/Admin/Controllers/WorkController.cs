using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Ramazan.ToDo.Business.Interfaces;
using Ramazan.ToDo.DTO.DTOs.WorkDTOs;
using Ramazan.ToDo.Entittes.Concrete;
using Ramazan.ToDo.Web.StringInfo;

namespace Ramazan.ToDo.Web.Areas.Admin.Controllers
{
    [Authorize(Roles =RoleInfo.Admin)]
    [Area(AreaInfo.Admin)]
    public class WorkController : Controller
    {
        private readonly IWorkService _workService;
        private readonly IPriorityService _priorityService;
        private readonly IMapper _mapper;
        public WorkController(IWorkService workService, IPriorityService priorityService, IMapper mapper)
        {
            _workService = workService;
            _priorityService = priorityService;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            TempData["Active"] = TempDataInfo.Work;
            return View (_mapper.Map<List<WorkListDto>>(_workService.GetUnFinishedWithPriority()));
        }

        public IActionResult FinishedWorks(int activePage = 1)
        {
            TempData["Active"] = TempDataInfo.FinishedWorks;
            ViewBag.ActivePage = activePage;
            var works = _mapper.Map<List<WorkListAllDto>>(_workService.GetWithAllPropertyFinished(out int totalPage, activePage));
            ViewBag.TotalPage = totalPage;
            return View(works);
        }

        public IActionResult AddWork()
        {
            TempData["Active"] = TempDataInfo.Work;
            ViewBag.Priorities = new SelectList(_priorityService.GetAll(),"Id", "Description");
            return View(new WorkAddDto());
        }

        [HttpPost]
        public IActionResult AddWork(WorkAddDto model)
        {
            if (ModelState.IsValid)
            {
                _workService.Save(_mapper.Map<Work>(model));
                return RedirectToAction("Index");
            }
            ViewBag.Priorities = new SelectList(_priorityService.GetAll(), "Id", "Description");
            return View(model);
        }

        public IActionResult UpdateWork(int id)
        {
            TempData["Active"] = TempDataInfo.Work;
            var work = _workService.FindById(id);
            ViewBag.Priorities = new SelectList(_priorityService.GetAll(), "Id", "Description", work.PriorityId);
            return View (_mapper.Map<WorkUpdateDto>(work));
        }
        [HttpPost]
        public IActionResult UpdateWork(WorkUpdateDto model)
        {
            ViewBag.Priorities = new SelectList(_priorityService.GetAll(), "Id", "Description", model.PriorityId);
            if (ModelState.IsValid)
            {
                _workService.Update(_mapper.Map<Work>(model));
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult DeleteWork(int id)
        {
            _workService.Delete(new Work { Id = id });
            return Json(null);
        }
    }
}
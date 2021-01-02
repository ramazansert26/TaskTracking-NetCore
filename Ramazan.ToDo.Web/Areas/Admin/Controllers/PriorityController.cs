using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ramazan.ToDo.Business.Interfaces;
using Ramazan.ToDo.DTO.DTOs.PriorityDTOs;
using Ramazan.ToDo.Entittes.Concrete;
using Ramazan.ToDo.Web.StringInfo;

namespace Ramazan.ToDo.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = RoleInfo.Admin)]
    [Area(AreaInfo.Admin)]
    public class PriorityController : Controller
    {
        private readonly IPriorityService _priorityService;
        private readonly IMapper _mapper;

        public PriorityController(IPriorityService priorityService, IMapper mapper)
        {
            _priorityService = priorityService;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            TempData["Active"] = TempDataInfo.Priority;
            return View(_mapper.Map<List<PriorityListDto>>(_priorityService.GetAll()));
        }

        public IActionResult AddPriority()
        {
            TempData["Active"] = TempDataInfo.Priority;
            return View(new PriorityAddDto());
        }

        [HttpPost]
        public IActionResult AddPriority(PriorityAddDto model)
        {
            if (ModelState.IsValid)
            {
                _priorityService.Save(new Priority()
                {
                    Description = model.Description
                });

                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult UpdatePriority(int id)
        {
            TempData["Active"] = TempDataInfo.Priority;
            return View(_mapper.Map<PriorityUpdateDto>(_priorityService.FindById(id)));
        }
        
        [HttpPost]
        public IActionResult UpdatePriority(PriorityUpdateDto model)
        {
            if(ModelState.IsValid)
            {
                _priorityService.Update(new Priority
                {
                    Id = model.Id,
                    Description = model.Description
                });

                return RedirectToAction("Index");
            }
            return View(model);

        }
    }


}
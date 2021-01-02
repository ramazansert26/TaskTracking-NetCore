using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Ramazan.ToDo.DTO.DTOs.AppUserDTOs;
using Ramazan.ToDo.Entittes.Concrete;
using Ramazan.ToDo.Web.BaseControllers;
using Ramazan.ToDo.Web.StringInfo;

namespace Ramazan.ToDo.Web.Areas.Admin.Controllers
{
    [Area(AreaInfo.Admin)]
    [Authorize(Roles = RoleInfo.Admin)]
    public class ProfileController : BaseIdentityController
    {
        private readonly IMapper _mapper;
        public ProfileController(UserManager<AppUser> userManager, IMapper mapper) : base(userManager)
        {
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            TempData["Active"] = TempDataInfo.Profile;
            return View(_mapper.Map<AppUserListDto>(await GetLoggedInUser()));
        }

        [HttpPost]
        public async Task<IActionResult> Index(AppUserListDto model, IFormFile picture)
        {
            if (ModelState.IsValid)
            {
                var user = _userManager.Users.FirstOrDefault(I => I.Id == model.Id);
                if (picture != null)
                {
                    string extension = Path.GetExtension(picture.FileName);
                    string pictureName = Guid.NewGuid() + extension;
                    string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/" + pictureName);
                    using var stream = new FileStream(path, FileMode.Create);
                    await picture.CopyToAsync(stream);

                    user.Picture = pictureName;

                }
                user.Name = model.Name;
                user.SurName = model.SurName;
                user.Email = model.Email;
                var identityResult = await _userManager.UpdateAsync(user);
                if (identityResult.Succeeded)
                {
                    TempData["Message"] = "Güncelleme İşlemi Başarıyla Gerçekleşti";
                    return RedirectToAction("Index");
                }

                AddErrors(identityResult.Errors);
            }
            return View(model);
        }
    }
}
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Ramazan.ToDo.Business.ValidationRules.FluentValidation;
using Ramazan.ToDo.DataAccess.EntityFrameworkCore.Contexts;
using Ramazan.ToDo.DTO.DTOs.ActionDTOs;
using Ramazan.ToDo.DTO.DTOs.AppUserDTOs;
using Ramazan.ToDo.DTO.DTOs.PriorityDTOs;
using Ramazan.ToDo.DTO.DTOs.WorkDTOs;
using Ramazan.ToDo.Entittes.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ramazan.ToDo.Web.CustomCollectionExtensions
{
    public static class CollectionExtension
    {
        public static void AddCustomIdentity(this IServiceCollection services)
        {
            services.AddIdentity<AppUser, AppRole>(opt =>
            {
                opt.Password.RequireDigit = false;
                opt.Password.RequireUppercase = false;
                opt.Password.RequireLowercase = false;
                opt.Password.RequiredLength = 1;
                opt.Password.RequireNonAlphanumeric = false;
            }).AddEntityFrameworkStores<TodoContext>();

            services.ConfigureApplicationCookie(opt =>
            {
                opt.Cookie.Name = "ToDoCookie";
                opt.Cookie.SameSite = Microsoft.AspNetCore.Http.SameSiteMode.Strict;
                opt.Cookie.HttpOnly = true;
                opt.ExpireTimeSpan = TimeSpan.FromDays(20);
                opt.Cookie.SecurePolicy = Microsoft.AspNetCore.Http.CookieSecurePolicy.SameAsRequest;
                opt.LoginPath = "/Home/Index";
                opt.AccessDeniedPath = "/Home/AccessDenied";
            });
        }

        public static void AddCustomValidator(this IServiceCollection services)
        {

            services.AddTransient<IValidator<PriorityAddDto>, PriorityAddValidator>();
            services.AddTransient<IValidator<PriorityUpdateDto>, PriorityUpdateValidator>();
            services.AddTransient<IValidator<AppUserAddDto>, AppUserAddValidator>();
            services.AddTransient<IValidator<AppUserSignInDto>, AppUserSignInValidator>();
            services.AddTransient<IValidator<WorkAddDto>, WorkAddValidator>();
            services.AddTransient<IValidator<WorkUpdateDto>, WorkUpdateValidator>();
            services.AddTransient<IValidator<ActionAddDto>, ActionAddValidator>();
            services.AddTransient<IValidator<ActionUpdateDto>, ActionUpdateValidator>();
        }
    }
}

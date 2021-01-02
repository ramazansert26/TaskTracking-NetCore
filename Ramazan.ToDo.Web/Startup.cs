using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Ramazan.ToDo.Business.Concrete;
using Ramazan.ToDo.Business.DiContainer;
using Ramazan.ToDo.Business.Interfaces;
using Ramazan.ToDo.Business.ValidationRules.FluentValidation;
using Ramazan.ToDo.DataAccess.EntityFrameworkCore.Contexts;
using Ramazan.ToDo.DataAccess.EntityFrameworkCore.Repositories;
using Ramazan.ToDo.DataAccess.Interfaces;
using Ramazan.ToDo.DTO.DTOs.ActionDTOs;
using Ramazan.ToDo.DTO.DTOs.AppUserDTOs;
using Ramazan.ToDo.DTO.DTOs.PriorityDTOs;
using Ramazan.ToDo.DTO.DTOs.WorkDTOs;
using Ramazan.ToDo.Entittes.Concrete;
using Ramazan.ToDo.Web.CustomCollectionExtensions;
using System;

namespace Ramazan.ToDo.Web
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddContainerWithDependencies();
            services.AddDbContext<TodoContext>();
            services.AddCustomIdentity();

            services.AddAutoMapper(typeof(Startup));
            services.AddCustomValidator();

            //For All Validators
            //services.AddValidatorsFromAssemblyContaining<PriorityAddValidator>();
            services.AddControllersWithViews().AddFluentValidation();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,UserManager<AppUser> userManager,RoleManager<AppRole> roleManager)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStatusCodePagesWithReExecute("/Home/StatusCode", "?code={0}");
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            IdentityInitializer.SeedData(userManager, roleManager).Wait();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name:"areas",
                    pattern:"{area}/{controller=Home}/{action=Index}/{id?}"
                    );
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}"
                    );
            });
        }
    }
}

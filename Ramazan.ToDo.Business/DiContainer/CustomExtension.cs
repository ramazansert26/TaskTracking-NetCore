using Microsoft.Extensions.DependencyInjection;
using Ramazan.ToDo.Business.Concrete;
using Ramazan.ToDo.Business.CustomLogger;
using Ramazan.ToDo.Business.Interfaces;
using Ramazan.ToDo.DataAccess.EntityFrameworkCore.Repositories;
using Ramazan.ToDo.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ramazan.ToDo.Business.DiContainer
{
    public static class CustomExtension
    {
        public static void AddContainerWithDependencies(this IServiceCollection services)
        {
            services.AddScoped<IWorkService, WorkManager>();
            services.AddScoped<IPriorityService, PriorityManager>();
            services.AddScoped<IActionService, ActionManager>();
            services.AddScoped<IAppUserService, AppUserManager>();
            services.AddScoped<IFileService, FileManager>();
            services.AddScoped<INotificationService, NotificationManager>();

            services.AddScoped<IWorkDal, EfWorkRepository>();
            services.AddScoped<IPriorityDal, EfPriorityRepository>();
            services.AddScoped<IActionDal, EfActionRepository>();
            services.AddScoped<IAppUserDal, EfAppUserReposityory>();
            services.AddScoped<INotificationDal, EfNotificationRepository>();

            services.AddTransient<ICustomLogger, NLogLogger>();
        }
    }
}

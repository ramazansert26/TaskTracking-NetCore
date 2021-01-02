using Microsoft.EntityFrameworkCore;
using Ramazan.ToDo.DataAccess.EntityFrameworkCore.Contexts;
using Ramazan.ToDo.DataAccess.Interfaces;
using Ramazan.ToDo.Entittes.Concrete;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Ramazan.ToDo.DataAccess.EntityFrameworkCore.Repositories
{
    public class EfAppUserReposityory : IAppUserDal
    {
        public List<AppUser> GetRoleNonAdmin()
        {
            using var context = new TodoContext();
           return context.Users.Join(context.UserRoles, user => user.Id, userRole => userRole.UserId, (resultUser, resultUserRole) => new
            {
                user = resultUser,
                userRole = resultUserRole
            }).Join(context.Roles, twoTableResult => twoTableResult.userRole.RoleId, role => role.Id, (resultTable, resultRole) => new
            {
                user = resultTable.user,
                userRoles = resultTable.userRole,
                roles = resultRole,
            }).Where(I => I.roles.Name != "Admin").Select(I => new AppUser()
            {
                Id = I.user.Id,
                Name = I.user.Name,
                SurName = I.user.SurName,
                Picture = I.user.Picture,
                Email = I.user.Email,
                UserName = I.user.UserName,
            }).ToList();
        }

        public List<AppUser> GetRoleNonAdmin(out int totalPage,string searchText, int activePage = 1)
        {
            using var context = new TodoContext();
            var result = context.Users.Join(context.UserRoles, user => user.Id, userRole => userRole.UserId, (resultUser, resultUserRole) => new
            {
                user = resultUser,
                userRole = resultUserRole
            }).Join(context.Roles, twoTableResult => twoTableResult.userRole.RoleId, role => role.Id, (resultTable, resultRole) => new
            {
                user = resultTable.user,
                userRoles = resultTable.userRole,
                roles = resultRole,
            }).Where(I => I.roles.Name != "Admin").Select(I => new AppUser()
            {
                Id = I.user.Id,
                Name = I.user.Name,
                SurName = I.user.SurName,
                Picture = I.user.Picture,
                Email = I.user.Email,
                UserName = I.user.UserName,
            });

            totalPage = (int)Math.Ceiling((double)result.Count()/3);

            if(!string.IsNullOrWhiteSpace(searchText))
            {
                result = result.Where(I => I.Name.ToLower().Contains(searchText.ToLower()) || I.SurName.ToLower().Contains(searchText.ToLower()));
                totalPage = (int)Math.Ceiling((double)result.Count() / 3);
            }

            result = result.Skip((activePage - 1) * 3).Take(3);
            return result.ToList();
        }

        public List<DualHelper> GetMostWorkFinishedUsers()
        {
            using var context = new TodoContext();
           return  context.Works.Include(I => I.AppUser).Where(I => I.Finished).GroupBy(I => I.AppUser.UserName).
                OrderByDescending(I => I.Count()).Take(5).Select(
                I => new DualHelper
                {
                    Name = I.Key,
                    WorkCount = I.Count()
                }).ToList();
        }

        public List<DualHelper> GetMostWorkAssginedUsers()
        {
            using var context = new TodoContext();
            return context.Works.Include(I => I.AppUser).Where(I => !I.Finished && I.AppUser !=null).GroupBy(I => I.AppUser.UserName).
                OrderByDescending(I => I.Count()).Take(5).Select(
                I => new DualHelper
                {
                    Name = I.Key,
                    WorkCount = I.Count()
                }).ToList();
        }
    }
}

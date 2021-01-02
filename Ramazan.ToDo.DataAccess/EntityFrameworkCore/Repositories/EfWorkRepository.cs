
using Microsoft.EntityFrameworkCore;
using Ramazan.ToDo.DataAccess.EntityFrameworkCore.Contexts;
using Ramazan.ToDo.DataAccess.Interfaces;
using Ramazan.ToDo.Entittes.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Ramazan.ToDo.DataAccess.EntityFrameworkCore.Repositories
{
    public class EfWorkRepository : EfGenericRepository<Work>, IWorkDal
    {
        public Work FindByIdWithActions(int id)
        {
            using var context = new TodoContext();
            return context.Works.Include(I => I.AppUser).Include(I => I.Actions.OrderByDescending(I => I.CreateDate)).Where(I => I.Id == id).FirstOrDefault();
        }

        public Work FindByIdWithPriority(int id)
        {
            using var context = new TodoContext();
            return context.Works.Include(I => I.Priority).Where(I => !I.Finished && I.Id == id).FirstOrDefault();
        }

        public List<Work> GetByAppUserId(int appUserId)
        {
            using var context = new TodoContext();
            return context.Works.Where(I => I.AppUserId == appUserId).ToList();
        }

        public int GetFinishedWorkCount()
        {
            using var context = new TodoContext();
            return context.Works.Count(I => I.Finished);
        }

        public int GetFinishedWorkCountByUserId(int userId)
        {
            using var context = new TodoContext();
            return context.Works.Count(I => I.AppUserId == userId && I.Finished);
        }

        public int GetUnassignedWorkCount()
        {
            using var context = new TodoContext();
            return context.Works.Count(I => I.AppUserId == null && !I.Finished);
        }

        public List<Work> GetUnFinishedWithPriority()
        {
            using var context = new TodoContext();
            //Eager loading
            return context.Works.Include(I => I.Priority).Where(I => !I.Finished).OrderByDescending(I => I.CreateDate).ToList();
        }

        public int GetUnFinishedWorkCountByUserId(int userId)
        {
            using var context = new TodoContext();
            return context.Works.Count(I => I.AppUserId == userId && !I.Finished);
        }

        public List<Work> GetWithAllProperty()
        {
            using var context = new TodoContext();
            //Eager loading
            return context.Works.Include(I => I.AppUser).Include(I => I.Actions).Include(I => I.Priority).Where(I => !I.Finished).OrderByDescending(I => I.CreateDate).ToList();
        }

        public List<Work> GetWithAllProperty(Expression<Func<Work, bool>> filter)
        {
            using var context = new TodoContext();
            //Eager loading
            return context.Works.Include(I => I.AppUser).Include(I => I.Actions).Include(I => I.Priority).Where(filter).OrderByDescending(I => I.CreateDate).ToList();
        }

        public List<Work> GetWithAllPropertyFinished(out int totalPage, int activePage)
        {
            using var context = new TodoContext();
            //Eager loading
            var returnValue = context.Works.Include(I => I.AppUser).Include(I => I.Actions).Include(I => I.Priority).Where(I => I.Finished).OrderByDescending(I => I.CreateDate);
            totalPage = (int)Math.Ceiling((double)returnValue.Count() / 3);

            return returnValue.Skip((activePage - 1) * 3).Take(3).ToList();
        }

        public List<Work> GetWithAllPropertyFinishedByUserId(out int totalPage, int userId,int activePage = 1)
        {
            using var context = new TodoContext();
            //Eager loading
             var returnValue = context.Works.Include(I => I.AppUser).Include(I => I.Actions).Include(I => I.Priority).Where(I => I.AppUserId == userId && I.Finished).OrderByDescending(I => I.CreateDate);
            totalPage = (int)Math.Ceiling((double)returnValue.Count() / 3);

            return returnValue.Skip((activePage - 1) * 3).Take(3).ToList();

        }
    }
}

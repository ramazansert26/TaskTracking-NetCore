using Microsoft.EntityFrameworkCore;
using Ramazan.ToDo.DataAccess.EntityFrameworkCore.Contexts;
using Ramazan.ToDo.DataAccess.Interfaces;
using Ramazan.ToDo.Entittes.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Action = Ramazan.ToDo.Entittes.Concrete.Action;

namespace Ramazan.ToDo.DataAccess.EntityFrameworkCore.Repositories
{
    public class EfActionRepository : EfGenericRepository<Action>, IActionDal
    {
        public int GetActionCountByUserId(int userId)
        {
            using var context = new TodoContext();
            return context.Works.Include(I => I.Actions).Where(I => I.AppUserId == userId).SelectMany(I => I.Actions).Count();
        }

        public Action FindByIdWithWork(int id)
        {
            using var context = new TodoContext();
            return context.Actions.Include(I => I.Work).ThenInclude(I => I.Priority).Where(I => I.Id == id).FirstOrDefault();
        }
        public int GetAllActionCount()
        {
            using var context = new TodoContext();
            return context.Actions.Count();
        }
    }
}

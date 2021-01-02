using Ramazan.ToDo.DataAccess.EntityFrameworkCore.Contexts;
using Ramazan.ToDo.DataAccess.Interfaces;
using Ramazan.ToDo.Entittes.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ramazan.ToDo.DataAccess.EntityFrameworkCore.Repositories
{
    public class EfNotificationRepository : EfGenericRepository<Notification>, INotificationDal
    {
        public List<Notification> GetUnReadByUserId(int userId)
        {
            using var context = new TodoContext();
            return context.Notifications.Where(I => I.AppUserId == userId && !I.Read).ToList();
        }

        public int GetUnReadCountByUserId(int userId)
        {
            using var context = new TodoContext();
            return context.Notifications.Count(I => I.AppUserId == userId && !I.Read);
        }
    }
}

using Ramazan.ToDo.Business.Interfaces;
using Ramazan.ToDo.DataAccess.Interfaces;
using Ramazan.ToDo.Entittes.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ramazan.ToDo.Business.Concrete
{
    public class NotificationManager : INotificationService
    {
        private readonly INotificationDal _notificationDal;
        public NotificationManager(INotificationDal notificationDal)
        {
            _notificationDal = notificationDal;
        }
        public void Delete(Notification table)
        {
            _notificationDal.Delete(table);
        }

        public Notification FindById(int id)
        {
            return _notificationDal.FindById(id);
        }

        public List<Notification> GetAll()
        {
            return _notificationDal.GetAll();
        }

        public List<Notification> GetUnReadByUserId(int userId)
        {
            return _notificationDal.GetUnReadByUserId(userId);
        }

        public int GetUnReadCountByUserId(int userId)
        {
            return _notificationDal.GetUnReadCountByUserId(userId);
        }

        public void Save(Notification table)
        {
            _notificationDal.Save(table);
        }

        public void Update(Notification table)
        {
            _notificationDal.Update(table);
        }
    }
}

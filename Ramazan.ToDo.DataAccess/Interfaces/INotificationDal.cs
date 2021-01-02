using Ramazan.ToDo.Entittes.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ramazan.ToDo.DataAccess.Interfaces
{
    public interface INotificationDal :IGenericDal<Notification>
    {
        List<Notification> GetUnReadByUserId(int userId);
        int GetUnReadCountByUserId(int userId);
    }
}

using Ramazan.ToDo.Entittes.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ramazan.ToDo.Business.Interfaces
{
    public interface INotificationService : IGenericService<Notification>
    {
        List<Notification> GetUnReadByUserId(int userId);
        int GetUnReadCountByUserId(int userId);
    }
}

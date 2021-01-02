using Ramazan.ToDo.Entittes.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Action = Ramazan.ToDo.Entittes.Concrete.Action;

namespace Ramazan.ToDo.DataAccess.Interfaces
{
    public interface IActionDal : IGenericDal<Action>
    {
        Action FindByIdWithWork(int id);
        int GetActionCountByUserId(int userId);

        int GetAllActionCount();
    }
}

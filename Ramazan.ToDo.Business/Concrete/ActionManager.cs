using Ramazan.ToDo.Business.Interfaces;
using Ramazan.ToDo.DataAccess.EntityFrameworkCore.Repositories;
using Ramazan.ToDo.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ramazan.ToDo.Business.Concrete
{
    public class ActionManager : IActionService
    {
        private readonly IActionDal _actionDal;
        public ActionManager(IActionDal actionDal)
        {
            _actionDal = actionDal;
        }

        public int GetActionCountByUserId(int userId)
        {
            return _actionDal.GetActionCountByUserId(userId);
        }

        public void Delete(ToDo.Entittes.Concrete.Action table)
        {
            _actionDal.Delete(table);
        }

        public ToDo.Entittes.Concrete.Action FindById(int id)
        {
            return _actionDal.FindById(id);
        }

        public Entittes.Concrete.Action FindByIdWithWork(int id)
        {
            return _actionDal.FindByIdWithWork(id);
        }

        public List<ToDo.Entittes.Concrete.Action> GetAll()
        {
            return _actionDal.GetAll();
        }

        public void Save(ToDo.Entittes.Concrete.Action table)
        {
            _actionDal.Save(table);
        }

        public void Update(ToDo.Entittes.Concrete.Action table)
        {
            _actionDal.Update(table);
        }

        public int GetAllActionCount()
        {
           return _actionDal.GetAllActionCount();
        }
    }
}

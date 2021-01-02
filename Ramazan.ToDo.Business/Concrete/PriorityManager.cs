using Ramazan.ToDo.Business.Interfaces;
using Ramazan.ToDo.DataAccess.EntityFrameworkCore.Repositories;
using Ramazan.ToDo.DataAccess.Interfaces;
using Ramazan.ToDo.Entittes.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ramazan.ToDo.Business.Concrete
{
    public class PriorityManager : IPriorityService
    {
        private readonly IPriorityDal _priorityDal;

        public PriorityManager(IPriorityDal priorityDal)
        {
            _priorityDal = priorityDal;
        }
        public void Delete(Priority table)
        {
            _priorityDal.Delete(table);
        }

        public Priority FindById(int id)
        {
            return _priorityDal.FindById(id);
        }

        public List<Priority> GetAll()
        {
            return _priorityDal.GetAll();
        }

        public void Save(Priority table)
        {
            _priorityDal.Save(table);
        }

        public void Update(Priority table)
        {
            _priorityDal.Update(table);
        }
    }
}

using Ramazan.ToDo.Business.Interfaces;
using Ramazan.ToDo.DataAccess.EntityFrameworkCore.Repositories;
using Ramazan.ToDo.DataAccess.Interfaces;
using Ramazan.ToDo.Entittes.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Ramazan.ToDo.Business.Concrete
{
    public class WorkManager : IWorkService
    {
        private readonly IWorkDal _workDal;

        public WorkManager(IWorkDal workDal)
        {
            _workDal = workDal;
        }
        public void Delete(Work table)
        {
            _workDal.Delete(table);
        }

        public Work FindById(int id)
        {
            return _workDal.FindById(id);
        }

        public Work FindByIdWithActions(int id)
        {
            return _workDal.FindByIdWithActions(id);
        }

        public Work FindByIdWithPriority(int id)
        {
            return _workDal.FindByIdWithPriority(id);
        }

        public List<Work> GetAll()
        {
            return _workDal.GetAll();
        }

        public List<Work> GetByAppUserId(int appUserId)
        {
            return _workDal.GetByAppUserId(appUserId);
        }

        public int GetFinishedWorkCount()
        {
            return _workDal.GetFinishedWorkCount();
        }

        public int GetFinishedWorkCountByUserId(int userId)
        {
            return _workDal.GetFinishedWorkCountByUserId(userId);
        }

        public int GetUnassignedWorkCount()
        {
            return _workDal.GetUnassignedWorkCount();
        }

        public List<Work> GetUnFinishedWithPriority()
        {
            return _workDal.GetUnFinishedWithPriority();
        }

        public int GetUnFinishedWorkCountByUserId(int userId)
        {
            return _workDal.GetUnFinishedWorkCountByUserId(userId);
        }

        public List<Work> GetWithAllProperty()
        {
            return _workDal.GetWithAllProperty();
        }

        public List<Work> GetWithAllProperty(Expression<Func<Work, bool>> filter)
        {
            return _workDal.GetWithAllProperty(filter);
        }

        public List<Work> GetWithAllPropertyFinished(out int totalPage, int activePage = 1)
        {
            return _workDal.GetWithAllPropertyFinished(out totalPage, activePage);
        }

        public List<Work> GetWithAllPropertyFinishedByUserId(out int totalPage, int userId, int activePage)
        {
            return _workDal.GetWithAllPropertyFinishedByUserId(out totalPage, userId, activePage);
        }

        public void Save(Work table)
        {
            _workDal.Save(table);
        }

        public void Update(Work table)
        {
            _workDal.Update(table);
        }
    }
}

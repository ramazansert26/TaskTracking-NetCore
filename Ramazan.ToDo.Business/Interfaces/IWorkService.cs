using Ramazan.ToDo.Entittes.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Ramazan.ToDo.Business.Interfaces
{
    public interface IWorkService : IGenericService<Work>
    {
        List<Work> GetUnFinishedWithPriority();
        List<Work> GetWithAllProperty();
        Work FindByIdWithPriority(int id);
        List<Work> GetByAppUserId(int appUserId);
        Work FindByIdWithActions(int id);
        List<Work> GetWithAllProperty(Expression<Func<Work, bool>> filter);
        List<Work> GetWithAllPropertyFinishedByUserId(out int totalPage, int userId, int activePage = 1);
        List<Work> GetWithAllPropertyFinished(out int totalPage, int activePage=1);
        int GetFinishedWorkCountByUserId(int userId);
        int GetFinishedWorkCount();
        int GetUnFinishedWorkCountByUserId(int userId);
        int GetUnassignedWorkCount();
    }
}

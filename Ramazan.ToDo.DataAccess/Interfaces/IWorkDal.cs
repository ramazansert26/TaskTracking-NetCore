using Microsoft.EntityFrameworkCore.Query;
using Ramazan.ToDo.Entittes.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Ramazan.ToDo.DataAccess.Interfaces
{
    public interface IWorkDal : IGenericDal<Work>
    {
        List<Work> GetUnFinishedWithPriority();
        List<Work> GetWithAllProperty();
        List<Work> GetWithAllProperty(Expression<Func<Work,bool>> filter);
        List<Work> GetWithAllPropertyFinishedByUserId(out int totalPage, int userId, int activePage);
        List<Work> GetWithAllPropertyFinished(out int totalPage,int activePage);
        Work FindByIdWithPriority(int id);

        List<Work> GetByAppUserId(int appUserId);

        Work FindByIdWithActions(int id);

        int GetFinishedWorkCountByUserId(int userId);
        int GetUnFinishedWorkCountByUserId(int userId);
        int GetUnassignedWorkCount();
        int GetFinishedWorkCount();

    }
}

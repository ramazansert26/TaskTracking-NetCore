using Ramazan.ToDo.DataAccess.Interfaces;
using Ramazan.ToDo.Entittes.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ramazan.ToDo.DataAccess.EntityFrameworkCore.Repositories
{
    public class EfPriorityRepository : EfGenericRepository<Priority>, IPriorityDal
    {
    }
}

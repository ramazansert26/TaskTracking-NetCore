
using Ramazan.ToDo.DataAccess.EntityFrameworkCore.Contexts;
using Ramazan.ToDo.DataAccess.Interfaces;
using Ramazan.ToDo.Entittes.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ramazan.ToDo.DataAccess.EntityFrameworkCore.Repositories
{
    public class EfGenericRepository<Table> : IGenericDal<Table>
        where Table : class, ITable, new()
    {
        public List<Table> GetAll()
        {
            using var context = new TodoContext();
            return context.Set<Table>().ToList();
        }
        public Table FindById(int id)
        {
            using var context = new TodoContext();
            return context.Set<Table>().Find(id);
        }
        public void Update(Table table)
        {
            using var context = new TodoContext();
            context.Set<Table>().Update(table);
            context.SaveChanges();
        }

        public void Save(Table table)
        {
            using var context = new TodoContext();
            context.Set<Table>().Add(table);
            context.SaveChanges();
        }

        public void Delete(Table table)
        {
            using var context = new TodoContext();
            context.Set<Table>().Remove(table);
            context.SaveChanges();
        }
    }
}

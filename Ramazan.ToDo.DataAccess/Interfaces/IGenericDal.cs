using Ramazan.ToDo.Entittes.Interfaces;
using System.Collections.Generic;

namespace Ramazan.ToDo.DataAccess.Interfaces
{
    public interface IGenericDal<Table> where Table:class, ITable, new()
    {
        void Save(Table table);
        void Delete(Table table);
        void Update(Table table);

        Table FindById(int id);
        List<Table> GetAll();
    }
}

using Ramazan.ToDo.Entittes.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ramazan.ToDo.Entittes.Concrete
{
    public class Priority : ITable
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public List<Work> Works { get; set; }
    }
}

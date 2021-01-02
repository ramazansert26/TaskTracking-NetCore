using Ramazan.ToDo.Entittes.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ramazan.ToDo.Entittes.Concrete
{
    public class Action : ITable
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Detail { get; set; }


        public Work Work { get; set; }
        public int WorkId { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public int TimeSpent { get; set; }
    }
}

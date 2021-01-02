
using Ramazan.ToDo.Entittes.Interfaces;
using System;
using System.Collections.Generic;

namespace Ramazan.ToDo.Entittes.Concrete
{
    public class Work : ITable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public bool Finished { get; set; }

        public int PriorityId { get; set; }
        public Priority Priority { get; set; }

        public int? AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public List<Action> Actions { get; set; }
    }
}

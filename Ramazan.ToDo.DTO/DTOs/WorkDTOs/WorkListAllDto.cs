using Ramazan.ToDo.Entittes.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Action = Ramazan.ToDo.Entittes.Concrete.Action;

namespace Ramazan.ToDo.DTO.DTOs.WorkDTOs
{
    public class WorkListAllDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
        public bool Finished { get; set; }

        public int PriorityId { get; set; }
        public Priority Priority { get; set; }
        public List<Action> Actions { get; set; }
        public AppUser AppUser { get; set; }
    }
}

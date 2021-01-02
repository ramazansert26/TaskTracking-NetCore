using Ramazan.ToDo.Entittes.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ramazan.ToDo.DTO.DTOs.WorkDTOs
{
    public class WorkListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
        public bool Finished { get; set; }

        public int PriorityId { get; set; }
        public Priority Priority { get; set; }
    }
}

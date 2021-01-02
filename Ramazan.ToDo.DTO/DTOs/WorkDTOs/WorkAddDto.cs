using System;
using System.Collections.Generic;
using System.Text;

namespace Ramazan.ToDo.DTO.DTOs.WorkDTOs
{
    public class WorkAddDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int PriorityId { get; set; }
    }
}

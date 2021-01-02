using Ramazan.ToDo.Entittes.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ramazan.ToDo.DTO.DTOs.ActionDTOs
{
    public class ActionAddDto
    {
        public string Description { get; set; }

        public string Detail { get; set; }
        public int WorkId { get; set; }
        public Work Work { get; set; }

        public int TimeSpent { get; set; }
    }
}

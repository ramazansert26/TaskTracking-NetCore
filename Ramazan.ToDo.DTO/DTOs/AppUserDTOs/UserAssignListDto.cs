using Ramazan.ToDo.DTO.DTOs.WorkDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ramazan.ToDo.DTO.DTOs.AppUserDTOs
{
    public class UserAssignListDto
    {
        public WorkListDto Work { get; set; }

       public AppUserListDto AppUser { get; set; }
    }
}

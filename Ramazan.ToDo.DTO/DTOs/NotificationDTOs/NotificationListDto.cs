using System;
using System.Collections.Generic;
using System.Text;

namespace Ramazan.ToDo.DTO.DTOs.NotificationDTOs
{
    public class NotificationListDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Area { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public int DataId { get; set; }
    }
}

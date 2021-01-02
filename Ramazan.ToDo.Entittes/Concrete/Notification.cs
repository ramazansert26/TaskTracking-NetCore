using Ramazan.ToDo.Entittes.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ramazan.ToDo.Entittes.Concrete
{
    public class Notification : ITable
    {
        public int Id { get; set; }
        public int AppUserId { get; set; }
        public AppUser AppUser{ get; set; }
        public string Description{ get; set; }
        public bool Read{ get; set; }
        public string Area{ get; set; }
        public string Controller{ get; set; }
        public string Action{ get; set; }
        public int DataId{ get; set; }
    }
}

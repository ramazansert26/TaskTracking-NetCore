using Microsoft.AspNetCore.Identity;
using Ramazan.ToDo.Entittes.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ramazan.ToDo.Entittes.Concrete
{
    public class AppUser : IdentityUser<int>, ITable
    {
        public string Name { get; set; }
        public string SurName { get; set; }

        public string Picture { get; set; } = "default.png";


        public List<Work> Works  { get; set; }
        public  List<Notification> Notifications{ get; set; }
    }
}

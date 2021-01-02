using Ramazan.ToDo.Entittes.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ramazan.ToDo.Business.Interfaces
{
    public interface IAppUserService
    {
        List<AppUser> GetRoleNonAdmin();
        List<AppUser> GetRoleNonAdmin(out int totalPage, string searchText, int activePage = 1);
        List<DualHelper> GetMostWorkFinishedUsers();
        List<DualHelper> GetMostWorkAssginedUsers();
    }
}

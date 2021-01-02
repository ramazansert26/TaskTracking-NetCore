using Ramazan.ToDo.Business.Interfaces;
using Ramazan.ToDo.DataAccess.Interfaces;
using Ramazan.ToDo.Entittes.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ramazan.ToDo.Business.Concrete
{
    public class AppUserManager : IAppUserService
    {
        private readonly IAppUserDal _userDal;
        public AppUserManager(IAppUserDal userDal)
        {
            _userDal = userDal;
        }

        public List<DualHelper> GetMostWorkAssginedUsers()
        {
            return _userDal.GetMostWorkAssginedUsers();
        }

        public List<DualHelper> GetMostWorkFinishedUsers()
        {
            return _userDal.GetMostWorkFinishedUsers();
        }

        public List<AppUser> GetRoleNonAdmin()
        {
           return  _userDal.GetRoleNonAdmin();
        }

        public List<AppUser> GetRoleNonAdmin(out int totalPage,string searchText, int activePage = 1)
        {
            return _userDal.GetRoleNonAdmin(out  totalPage,searchText, activePage);
        }
    }
}

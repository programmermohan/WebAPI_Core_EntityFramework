using IMS.Web.Business.Common;
using IMS.Web.Business.Interfaces;
using IMS.Web.Business.ModelEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Web.Business.Implementation
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public UserService(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public bool IsValidUser(string userName, string password)
        {
            var user = _applicationDbContext.Users.FirstOrDefault(x => x.UserName == userName && x.Password == password);
            if(user != null)
            {
                return true;
            }
            return false;
        }
        public User GetUser(string userName, string password)
        {
            return _applicationDbContext.Users.FirstOrDefault(x => x.UserName == userName && x.Password == password);
        }

        public bool AddUser(User user)
        {
            var role = _applicationDbContext.Roles.FirstOrDefault(x => x.Id == user.RoleId);
            if(role != null)
            {
                var registerUser = new User()
                {
                    Id = 0,
                    RoleId = user.RoleId,
                    UserName = user.UserName,
                    Password = user.Password
                };
                _applicationDbContext.Users.Add(registerUser);
                _applicationDbContext.SaveChanges();
                return true;
            }
            return false;
        }
    }
}

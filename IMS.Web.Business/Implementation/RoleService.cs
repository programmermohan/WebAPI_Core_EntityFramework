using IMS.Web.Business.Common;
using IMS.Web.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Web.Business.Implementation
{
    public class RoleService :IRoleService
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public RoleService(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public ModelEntities.Role GetRole(long roleId)
        {
            return _applicationDbContext.Roles.FirstOrDefault(x => x.Id == roleId);
        }

        public ModelEntities.Role GetUserRole(string userName)
        {
            var role = _applicationDbContext.Users.Where(x => x.UserName == userName).Select(x=> x.Role).FirstOrDefault();
            return role;
        }
    }
}

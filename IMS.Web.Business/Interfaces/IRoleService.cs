using IMS.Web.Business.ModelEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Web.Business.Interfaces
{
    public interface IRoleService
    {
        Role GetRole(long roleId);
        Role GetUserRole(string userName);
    }
}

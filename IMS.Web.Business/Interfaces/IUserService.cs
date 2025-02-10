using IMS.Web.Business.ModelEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Web.Business.Interfaces
{
    public interface IUserService
    {
        bool IsValidUser(string userName, string password);
        User GetUser(string userName, string password);
        bool AddUser(User user);
    }
}

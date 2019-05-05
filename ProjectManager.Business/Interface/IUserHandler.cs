using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Business
{
    public interface IUserHandler
    {
        void AddUser(UserViewModel user);
        void UpdateUser(UserViewModel user);
        List<UserViewModel> GetAllUsers();
        void DeleteUser(UserViewModel user);

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.DataAccess
{
    public interface IUserRepository
    {
        void AddUser(User user);
        void DeleteUser(User user);
        void UpdateUser(User user);
        IQueryable<User> GetAllUSer();
        User GetUserById(int Id);
    }
}

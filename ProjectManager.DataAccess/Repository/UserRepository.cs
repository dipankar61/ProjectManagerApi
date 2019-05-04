using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.DataAccess
{
    internal class UserRepository:IUserRepository
    {
        private readonly IProjectManagerRepository<User> UserRepo;
        public UserRepository(IProjectManagerRepository<User> UserRepo)
        {
            this.UserRepo = UserRepo;
        }

        public void AddUser(User user)
        {
            UserRepo.Create(user);
        }

        public void DeleteUser(User user)
        {
            UserRepo.Delete(user);
        }
        public void UpdateUser(User user)
        {
            UserRepo.Update(user);
        }

        public IQueryable<User> GetAllUSer()
        {
            return UserRepo.All;
        }

        public User GetUserById(int Id)
        {
            return UserRepo.GetById(Id);
        }
    }
}

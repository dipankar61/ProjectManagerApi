using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
[assembly: InternalsVisibleTo("ProjectManager.UnitTest")]

namespace ProjectManager.DataAccess
{
    internal class UserRepository:IUserRepository
    {
        private readonly IProjectManagerRepository<User> UserRepo;
        public UserRepository() : this(new ProjectManagerRepository<User>()) { }
        public UserRepository(IProjectManagerRepository<User> UserRepo)
        {
            this.UserRepo = UserRepo;
        }

        public void AddUser(User user)
        {
            UserRepo.Create(user);
            UserRepo.SaveChange();
        }

        public void DeleteUser(User user)
        {
            UserRepo.Delete(user);
            UserRepo.SaveChange();
        }
        public void UpdateUser(User user)
        {
            UserRepo.Update(user);
            UserRepo.SaveChange();
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

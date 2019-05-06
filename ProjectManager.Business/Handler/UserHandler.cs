using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectManager.DataAccess;
using System.Runtime.CompilerServices;
[assembly: InternalsVisibleTo("ProjectManager.UnitTest")]

namespace ProjectManager.Business
{
    internal class UserHandler : IUserHandler
    {
        private readonly IUserRepository userRepo;
        internal UserHandler(IUserRepository userRepo)
        {
            this.userRepo = userRepo;
        }
        public void AddUser(UserViewModel user)
        {
            if (!IsEmployeeIdExist(user))
            {
                var us = new User()
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    EmployeeId = user.EmployeeId
                };
                userRepo.AddUser(us);
            }
            else
            {
                var customException = new CustomException();
                customException.ExceptionMsg = "Employee Id is already exist in the system";
                throw customException;
            }
        }

        public List<UserViewModel> GetAllUsers()
        {
            var userList = new List<UserViewModel>();
            userRepo.GetAllUSer().ToList().ForEach(item =>
            {
                var usVM = new UserViewModel()
                {
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    UserId = item.UserId,
                    EmployeeId = item.EmployeeId
                };
                userList.Add(usVM);


            });
            return userList;
        }

        public void UpdateUser(UserViewModel user)
        {
            bool isAllowEdit = false;
            var us = userRepo.GetUserById(user.UserId);
            isAllowEdit = (us.EmployeeId == user.EmployeeId) ? true : !IsEmployeeIdExist(user);
            if (isAllowEdit)
            {
                us.FirstName = user.FirstName;
                us.LastName = user.LastName;
                us.EmployeeId = user.EmployeeId;
                userRepo.UpdateUser(us);
            }
            else
            {
                var customException = new CustomException();
                customException.ExceptionMsg = "Employee Id is already exist in the system";
                throw customException;
            }
        }
        public void DeleteUser(UserViewModel user)
        {
            var us = userRepo.GetUserById(user.UserId);
            
            userRepo.DeleteUser(us);

        }
        private bool IsEmployeeIdExist(UserViewModel user)
        {
            return userRepo.GetAllUSer().Any(u => u.EmployeeId == user.EmployeeId);
        }
    }
}

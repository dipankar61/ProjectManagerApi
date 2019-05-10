using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Moq;
using NUnit.Framework;
using ProjectManager.Business;
using ProjectManager.DataAccess;

namespace ProjectManager.UnitTest.BusinessHandler
{
    [TestFixture]
    public class UserTaskHandler_Test
    {
        [Test]
        public void AddUser_Test()
        {
            UserViewModel usVm = new UserViewModel();
            usVm.FirstName = "usF";
            usVm.LastName = "usL";
            usVm.EmployeeId = 11;
            
            User us1 = new User();
            us1.FirstName = "usF";
            us1.LastName = "usL";
            us1.EmployeeId = 12;
            User us2 = new User();
            us2.FirstName = "usF2";
            us2.LastName = "usL2";
            us2.EmployeeId = 13;
            List<User> usList = new List<User>();
            usList.Add(us1);
            usList.Add(us2);
            IQueryable<User> Users = usList.AsQueryable();
            var mockRepo = new Mock<IUserRepository>();
            mockRepo.Setup(p => p.GetAllUSer()).Returns(Users);
            var handler = new UserHandler(mockRepo.Object);
            handler.AddUser(usVm);
            mockRepo.Verify(mock => mock.GetAllUSer(), Times.Once());
        }
        [Test]
        public void AddUser_Failure_Test()
        {
            UserViewModel usVm = new UserViewModel();
            usVm.FirstName = "usF";
            usVm.LastName = "usL";
            usVm.EmployeeId = 12;

            User us1 = new User();
            us1.FirstName = "usF";
            us1.LastName = "usL";
            us1.EmployeeId = 12;
            User us2 = new User();
            us2.FirstName = "usF2";
            us2.LastName = "usL2";
            us2.EmployeeId = 13;
            List<User> usList = new List<User>();
            usList.Add(us1);
            usList.Add(us2);
            IQueryable<User> Users = usList.AsQueryable();
            var mockRepo = new Mock<IUserRepository>();
            mockRepo.Setup(p => p.GetAllUSer()).Returns(Users);
            var handler = new UserHandler(mockRepo.Object);
            Assert.That(() => handler.AddUser(usVm),
            Throws.TypeOf<CustomException>());
            mockRepo.Verify(mock => mock.GetAllUSer(), Times.Once());
           
        }
        [Test]
        public void GetAllUser_Test()
        {
            
            User us1 = new User();
            us1.FirstName = "usF";
            us1.LastName = "usL";
            us1.EmployeeId = 12;
            User us2 = new User();
            us2.FirstName = "usF2";
            us2.LastName = "usL2";
            us2.EmployeeId = 13;
            List<User> usList = new List<User>();
            usList.Add(us1);
            usList.Add(us2);
            IQueryable<User> Users = usList.AsQueryable();
            var mockRepo = new Mock<IUserRepository>();
            mockRepo.Setup(p => p.GetAllUSer()).Returns(Users);
            var handler = new UserHandler(mockRepo.Object);
            var retList = handler.GetAllUsers();
            mockRepo.Verify(mock => mock.GetAllUSer(), Times.Once());
            Assert.AreEqual(retList.Count, usList.Count);
            Assert.AreEqual(retList[0].FirstName, usList[0].FirstName);
        }
        [Test]
        public void UpdateUser_Test()
        {
            UserViewModel usVm = new UserViewModel();
            usVm.FirstName = "usFk";
            usVm.LastName = "usL";
            usVm.EmployeeId = 11;

            User us1 = new User();
            us1.FirstName = "usF";
            us1.LastName = "usL";
            us1.EmployeeId = 11;
            User us2 = new User();
            us2.FirstName = "usF2";
            us2.LastName = "usL2";
            us2.EmployeeId = 13;
            List<User> usList = new List<User>();
            usList.Add(us1);
            usList.Add(us2);
            IQueryable<User> Users = usList.AsQueryable();
            var mockRepo = new Mock<IUserRepository>();
            mockRepo.Setup(p => p.GetAllUSer()).Returns(Users);
            mockRepo.Setup(p => p.GetUserById(usVm.UserId)).Returns(us1);
            var handler = new UserHandler(mockRepo.Object);
            handler.UpdateUser(usVm);
            mockRepo.Verify(mock => mock.GetUserById(usVm.UserId), Times.Once());
        }
        [Test]
        public void DeleteUser_Test()
        {
            UserViewModel usVm = new UserViewModel();
            usVm.FirstName = "usFk";
            usVm.LastName = "usL";
            usVm.EmployeeId = 11;

            User us1 = new User();
            us1.FirstName = "usF";
            us1.LastName = "usL";
            us1.EmployeeId = 11;
            
            var mockRepo = new Mock<IUserRepository>();
           
            mockRepo.Setup(p => p.GetUserById(usVm.UserId)).Returns(us1);
            mockRepo.Setup(p => p.DeleteUser(us1));
            var handler = new UserHandler(mockRepo.Object);
            handler.DeleteUser(usVm.UserId);
            mockRepo.Verify(mock => mock.GetUserById(usVm.UserId), Times.Once());
            mockRepo.Verify(mock => mock.DeleteUser(us1), Times.Once());
        }
    }
}

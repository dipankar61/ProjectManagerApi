using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Moq;
using NUnit.Framework;
using ProjectManager.DataAccess;

namespace ProjectManager.UnitTest.Repository
{
    [TestFixture]
    public class UserRepository_Test
    {
        [Test]
        public void AddUser_test()
        {
            User us = new User();
            us.FirstName= "testF";
            us.LastName = "lastN";
            us.EmployeeId = 1;
            var mockUserRepository = new Mock<IProjectManagerRepository<User>>(MockBehavior.Strict);
            mockUserRepository.Setup(p => p.Create(us));
            mockUserRepository.Setup(p => p.SaveChange());
            var objUserRepo = new UserRepository(mockUserRepository.Object);
            objUserRepo.AddUser(us);
            mockUserRepository.Verify(mock => mock.Create(us), Times.Once());
            mockUserRepository.Verify(mock => mock.SaveChange(), Times.Once());
        }
        [Test]
        public void GetAllUser_Test()
        {
            User us = new User();
            us.FirstName = "testF";
            us.LastName = "lastN";
            us.EmployeeId = 1;
            List<User> userList = new List<User>();
            userList.Add(us);

            IQueryable<User> users = userList.AsQueryable();
            var mockUserRepository = new Mock<IProjectManagerRepository<User>>(MockBehavior.Strict);
            mockUserRepository.Setup(p => p.All).Returns(users);
            var objUserRepo = new UserRepository(mockUserRepository.Object);
            var returnUsers = objUserRepo.GetAllUSer();
            mockUserRepository.Verify(mock => mock.All, Times.Once());
            Assert.AreEqual(returnUsers.ToList().Count, 1);
            Assert.IsTrue(returnUsers.ToList().Any(item => item.FirstName == "testF"));

        }
        [Test]
        public void DeleteUser_Test()
        {
            User us = new User();
            us.FirstName = "testF";
            us.LastName = "lastN";
            us.EmployeeId = 1;
            var mockUserRepository = new Mock<IProjectManagerRepository<User>>(MockBehavior.Strict);
            mockUserRepository.Setup(p => p.Delete(us));
            mockUserRepository.Setup(p => p.SaveChange());
            var objUserRepo = new UserRepository(mockUserRepository.Object);
            objUserRepo.DeleteUser(us);
            mockUserRepository.Verify(mock => mock.Delete(us), Times.Once());
            mockUserRepository.Verify(mock => mock.SaveChange(), Times.Once());

        }
        [Test]
        public void UpdateUser_Test()
        {
            User us = new User();
            us.FirstName = "testF";
            us.LastName = "lastN";
            us.EmployeeId = 1;
            var mockUserRepository = new Mock<IProjectManagerRepository<User>>(MockBehavior.Strict);
            mockUserRepository.Setup(p => p.Update(us));
            mockUserRepository.Setup(p => p.SaveChange());
            var objUserRepo = new UserRepository(mockUserRepository.Object);
            objUserRepo.UpdateUser(us);
            mockUserRepository.Verify(mock => mock.Update(us), Times.Once());
            mockUserRepository.Verify(mock => mock.SaveChange(), Times.Once());

        }
    }
}

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
    public class ProjectHandler_Test
    {
        [Test]
        public void AddProject_Test()
        {
            ProjectViewModel pjVM = new ProjectViewModel();
            pjVM.ProjectName = "testproj3";
            pjVM.StartDate = DateTime.Now;
            pjVM.EndDate = DateTime.Now.AddDays(1);
            pjVM.Priority = 10;
            pjVM.UserId = 1;
            
            Project pj1 = new Project();
            pj1.ProjectName = "testproj1";
            pj1.StartDate = DateTime.Now;
            pj1.EndDate = DateTime.Now.AddDays(1);
            pj1.Priority = 10;
            pj1.UserId = 1;
            pj1.ProjectId = 1;
            Project pj2 = new Project();
            pj2.ProjectName = "testproj2";
            pj2.StartDate = DateTime.Now;
            pj2.EndDate = DateTime.Now.AddDays(1);
            pj2.Priority = 10;
            pj2.UserId = 1;
            pj2.ProjectId = 2;
            List<Project> projList = new List<Project>();
            projList.Add(pj1);
            projList.Add(pj2);
            IQueryable<Project> Projects = projList.AsQueryable();
            var mockRepo = new Mock<IProjectRepository>();
            mockRepo.Setup(p => p.GetAllProject()).Returns(Projects);
            var handler = new ProjectHandler(mockRepo.Object);
            handler.AddProject(pjVM);
            mockRepo.Verify(mock => mock.GetAllProject(), Times.Once());
        }
        [Test]
        public void AddProject_Failure_Test()
        {
            ProjectViewModel pjVM = new ProjectViewModel();
            pjVM.ProjectName = "testproj1";
            pjVM.StartDate = DateTime.Now;
            pjVM.EndDate = DateTime.Now.AddDays(1);
            pjVM.Priority = 10;
            pjVM.UserId = 1;

            Project pj1 = new Project();
            pj1.ProjectName = "testproj1";
            pj1.StartDate = DateTime.Now;
            pj1.EndDate = DateTime.Now.AddDays(1);
            pj1.Priority = 10;
            pj1.UserId = 1;
            pj1.ProjectId = 1;
            Project pj2 = new Project();
            pj2.ProjectName = "testproj2";
            pj2.StartDate = DateTime.Now;
            pj2.EndDate = DateTime.Now.AddDays(1);
            pj2.Priority = 10;
            pj2.UserId = 1;
            pj2.ProjectId = 2;
            List<Project> projList = new List<Project>();
            projList.Add(pj1);
            projList.Add(pj2);
            IQueryable<Project> Projects = projList.AsQueryable();
            var mockRepo = new Mock<IProjectRepository>();
            mockRepo.Setup(p => p.GetAllProject()).Returns(Projects);
            var handler = new ProjectHandler(mockRepo.Object);
            Assert.That(() => handler.AddProject(pjVM),
           Throws.TypeOf<CustomException>());
            mockRepo.Verify(mock => mock.GetAllProject(), Times.Once());
        }
        [Test]
        public void GetAllProjects_Test()
        {
          

            Project pj1 = new Project();
            pj1.ProjectName = "testproj1";
            pj1.StartDate = DateTime.Now;
            pj1.EndDate = DateTime.Now.AddDays(1);
            pj1.Priority = 10;
            pj1.UserId = 1;
            pj1.ProjectId = 1;
            Project pj2 = new Project();
            pj2.ProjectName = "testproj2";
            pj2.StartDate = DateTime.Now;
            pj2.EndDate = DateTime.Now.AddDays(1);
            pj2.Priority = 10;
            pj2.UserId = 1;
            pj2.ProjectId = 2;
            List<Project> projList = new List<Project>();
            projList.Add(pj1);
            projList.Add(pj2);
            IQueryable<Project> Projects = projList.AsQueryable();
            var mockRepo = new Mock<IProjectRepository>();
            mockRepo.Setup(p => p.GetAllProject()).Returns(Projects);
            var handler = new ProjectHandler(mockRepo.Object);
            var returnList=handler.GetAllProjects();
            mockRepo.Verify(mock => mock.GetAllProject(), Times.Once());
            Assert.AreEqual(returnList.Count, projList.Count);
            Assert.AreEqual(returnList[0].ProjectName, projList[0].ProjectName);
        }
        [Test]
        public void UpdateProject_Test()
        {
            ProjectViewModel pjVM = new ProjectViewModel();
            pjVM.ProjectName = "testproj1";
            pjVM.StartDate = DateTime.Now;
            pjVM.EndDate = DateTime.Now.AddDays(1);
            pjVM.Priority = 10;
            pjVM.UserId = 1;
            pjVM.ProjectId = 1;
            Project pj1 = new Project();
            pj1.ProjectName = "testproj1";
            pj1.StartDate = DateTime.Now;
            pj1.EndDate = DateTime.Now.AddDays(1);
            pj1.Priority = 10;
            pj1.UserId = 1;
            pj1.ProjectId = 1;
            Project pj2 = new Project();
            pj2.ProjectName = "testproj2";
            pj2.StartDate = DateTime.Now;
            pj2.EndDate = DateTime.Now.AddDays(1);
            pj2.Priority = 10;
            pj2.UserId = 1;
            pj2.ProjectId = 2;
            List<Project> projList = new List<Project>();
            projList.Add(pj1);
            projList.Add(pj2);
            IQueryable<Project> Projects = projList.AsQueryable();
            var mockRepo = new Mock<IProjectRepository>();
            mockRepo.Setup(p => p.GetProjectById(pjVM.ProjectId)).Returns(pj1);
            var handler = new ProjectHandler(mockRepo.Object);
            handler.UpdateProject(pjVM);
            mockRepo.Verify(mock => mock.GetProjectById(pjVM.ProjectId), Times.Once());
        }
        [Test]
        public void UpdateProject_Failure_Test()
        {
            ProjectViewModel pjVM = new ProjectViewModel();
            pjVM.ProjectName = "testproj2";
            pjVM.StartDate = DateTime.Now;
            pjVM.EndDate = DateTime.Now.AddDays(1);
            pjVM.Priority = 10;
            pjVM.UserId = 1;
            pjVM.ProjectId = 1;
            Project pj1 = new Project();
            pj1.ProjectName = "testproj1";
            pj1.StartDate = DateTime.Now;
            pj1.EndDate = DateTime.Now.AddDays(1);
            pj1.Priority = 10;
            pj1.UserId = 1;
            pj1.ProjectId = 1;
            Project pj2 = new Project();
            pj2.ProjectName = "testproj2";
            pj2.StartDate = DateTime.Now;
            pj2.EndDate = DateTime.Now.AddDays(1);
            pj2.Priority = 10;
            pj2.UserId = 1;
            pj2.ProjectId = 2;
            List<Project> projList = new List<Project>();
            projList.Add(pj1);
            projList.Add(pj2);
            IQueryable<Project> Projects = projList.AsQueryable();
            var mockRepo = new Mock<IProjectRepository>();
            mockRepo.Setup(p => p.GetAllProject()).Returns(Projects);
            mockRepo.Setup(p => p.GetProjectById(pjVM.ProjectId)).Returns(pj1);
            var handler = new ProjectHandler(mockRepo.Object);
            Assert.That(() => handler.UpdateProject(pjVM),
            Throws.TypeOf<CustomException>());
            mockRepo.Verify(mock => mock.GetProjectById(pjVM.ProjectId), Times.Once());
        }
    }
}

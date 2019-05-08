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
    public class ProjectRepository_Test
    {
        [Test]
        public void AddProject_Test()
        {
            Project pj = new Project();
            pj.ProjectName = "testproj";
            pj.StartDate = DateTime.Now;
            pj.EndDate = DateTime.Now.AddDays(1);
            pj.Priority = 10;
            pj.UserId = 1;
            var mockProjRepository = new Mock<IProjectManagerRepository<Project>>(MockBehavior.Strict);
            mockProjRepository.Setup(p => p.Create(pj));
            mockProjRepository.Setup(p => p.SaveChange());
            var objProjRepo = new ProjectRepository(mockProjRepository.Object);
            objProjRepo.AddProject(pj);
            mockProjRepository.Verify(mock => mock.Create(pj), Times.Once());
            mockProjRepository.Verify(mock => mock.SaveChange(), Times.Once());
        }
        [Test]
        public void UpdateProject_Test()
        {
            Project pj = new Project();
            pj.ProjectName = "testproj";
            pj.StartDate = DateTime.Now;
            pj.EndDate = DateTime.Now.AddDays(1);
            pj.Priority = 10;
            pj.UserId = 1;
            var mockProjRepository = new Mock<IProjectManagerRepository<Project>>(MockBehavior.Strict);
            mockProjRepository.Setup(p => p.Update(pj));
            mockProjRepository.Setup(p => p.SaveChange());
            var objProjRepo = new ProjectRepository(mockProjRepository.Object);
            objProjRepo.UpdateProject(pj);
            mockProjRepository.Verify(mock => mock.Update(pj), Times.Once());
            mockProjRepository.Verify(mock => mock.SaveChange(), Times.Once());
        }
        [Test]
        public void GetAllProjects_Test()
        {
            Project pj = new Project();
            pj.ProjectName = "testproj";
            pj.StartDate = DateTime.Now;
            pj.EndDate = DateTime.Now.AddDays(1);
            pj.Priority = 10;
            pj.UserId = 1;
            List<Project> projList = new List<Project>();
            projList.Add(pj);

            IQueryable<Project> projects = projList.AsQueryable();
            var mockProjRepository = new Mock<IProjectManagerRepository<Project>>(MockBehavior.Strict);
            mockProjRepository.Setup(p => p.All).Returns(projects);
            var objprojRepo = new ProjectRepository(mockProjRepository.Object);
            var returnProjs = objprojRepo.GetAllProject();
            mockProjRepository.Verify(mock => mock.All, Times.Once());
            Assert.AreEqual(returnProjs.ToList().Count, 1);
            Assert.IsTrue(returnProjs.ToList().Any(item => item.ProjectName == "testproj"));

        }
        [Test]
        public void GetProjectById_Test()
        {
            Project pj = new Project();
            pj.ProjectId = 10;
            pj.ProjectName = "testproj";
            pj.StartDate = DateTime.Now;
            pj.EndDate = DateTime.Now.AddDays(1);
            pj.Priority = 10;
            pj.UserId = 1;
            var mockProjRepository = new Mock<IProjectManagerRepository<Project>>(MockBehavior.Strict);
            mockProjRepository.Setup(p => p.GetById(10)).Returns(pj);
            var objprojRepo = new ProjectRepository(mockProjRepository.Object);
            var returnProj = objprojRepo.GetProjectById(10);
            mockProjRepository.Verify(mock => mock.GetById(10), Times.Once());
            Assert.AreEqual(returnProj.ProjectId, pj.ProjectId);
            

        }
    }
}

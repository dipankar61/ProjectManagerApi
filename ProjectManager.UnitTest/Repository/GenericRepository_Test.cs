using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Moq;
using NUnit.Framework;
using System.Data.Entity;
using ProjectManager.DataAccess;

namespace ProjectManager.UnitTest.Repository
{
    [TestFixture]
    public class GenericRepository_Test
    {
        [Test]
        public void Create_Test()
        {
            ParentTask pTask = new ParentTask();
            pTask.ParentId = 1;
            pTask.TaskName = "ABCD";
            var ptasks = new List<ParentTask>();
            ptasks.Add(pTask);
            var t = ptasks.AsQueryable();
            //var mockSet = new Mock<DbSet<Task_Table>>();
            var mockSet = new Mock<DbSet<ParentTask>>();
            mockSet.As<IQueryable<ParentTask>>().Setup(m => m.Provider).Returns(t.Provider);
            mockSet.As<IQueryable<ParentTask>>().Setup(m => m.Expression).Returns(t.Expression);
            mockSet.As<IQueryable<ParentTask>>().Setup(m => m.ElementType).Returns(t.ElementType);
            mockSet.As<IQueryable<ParentTask>>().Setup(m => m.GetEnumerator()).Returns(t.GetEnumerator());


            var mockTaskMangerContext = new Mock<ProjectmanagerContext>();
            mockTaskMangerContext.Setup(c => c.ParentTasks).Returns(mockSet.Object);
            mockTaskMangerContext.Setup(c => c.Set<ParentTask>()).Returns(mockSet.Object);
            mockTaskMangerContext.Setup(p => p.SaveChanges());
            var objTestTaskrepo = new ProjectManagerRepository<ParentTask>(mockTaskMangerContext.Object);
            objTestTaskrepo.Create(pTask);
            Assert.AreEqual(mockSet.Object.ToList().Count, 1);

            
        }
        [Test]
        public void GetById_Test()
        {
            ParentTask pTask = new ParentTask();
            pTask.ParentId = 1;
            pTask.TaskName = "ABCD";
            var ptasks = new List<ParentTask>();
            ptasks.Add(pTask);
            var t = ptasks.AsQueryable();
            //var mockSet = new Mock<DbSet<Task_Table>>();
            var mockSet = new Mock<DbSet<ParentTask>>();
            mockSet.As<IQueryable<ParentTask>>().Setup(m => m.Provider).Returns(t.Provider);
            mockSet.As<IQueryable<ParentTask>>().Setup(m => m.Expression).Returns(t.Expression);
            mockSet.As<IQueryable<ParentTask>>().Setup(m => m.ElementType).Returns(t.ElementType);
            mockSet.As<IQueryable<ParentTask>>().Setup(m => m.GetEnumerator()).Returns(t.GetEnumerator());
                     

            var mockTaskMangerContext = new Mock<ProjectmanagerContext>();
            mockTaskMangerContext.Setup(c => c.ParentTasks).Returns(mockSet.Object);
            mockTaskMangerContext.Setup(c => c.Set<ParentTask>()).Returns(mockSet.Object);
            mockTaskMangerContext.Setup(c => c.Set<ParentTask>().Find(1)).Returns(pTask);
            mockTaskMangerContext.Setup(p => p.SaveChanges());
            var objTestTaskrepo = new ProjectManagerRepository<ParentTask>(mockTaskMangerContext.Object);
            var retObj =objTestTaskrepo.GetById(1);
            Assert.AreEqual(retObj.TaskName, pTask.TaskName);
            mockTaskMangerContext.Verify(mock => mock.Set<ParentTask>().Find(1), Times.Once());


        }
        [Test]
        public void Delete_Test()
        {
            ParentTask pTask = new ParentTask();
            pTask.ParentId = 1;
            pTask.TaskName = "ABCD";
            var ptasks = new List<ParentTask>();
            ptasks.Add(pTask);
            var t = ptasks.AsQueryable();
            //var mockSet = new Mock<DbSet<Task_Table>>();
            var mockSet = new Mock<DbSet<ParentTask>>();
            mockSet.As<IQueryable<ParentTask>>().Setup(m => m.Provider).Returns(t.Provider);
            mockSet.As<IQueryable<ParentTask>>().Setup(m => m.Expression).Returns(t.Expression);
            mockSet.As<IQueryable<ParentTask>>().Setup(m => m.ElementType).Returns(t.ElementType);
            mockSet.As<IQueryable<ParentTask>>().Setup(m => m.GetEnumerator()).Returns(t.GetEnumerator());


            var mockTaskMangerContext = new Mock<ProjectmanagerContext>();
            mockTaskMangerContext.Setup(c => c.ParentTasks).Returns(mockSet.Object);
            mockTaskMangerContext.Setup(c => c.Set<ParentTask>()).Returns(mockSet.Object);
            mockTaskMangerContext.Setup(c => c.Set<ParentTask>().Remove(pTask));
            mockTaskMangerContext.Setup(p => p.SaveChanges());
            var objTestTaskrepo = new ProjectManagerRepository<ParentTask>(mockTaskMangerContext.Object);
            objTestTaskrepo.Delete(pTask);
            
            mockTaskMangerContext.Verify(mock => mock.Set<ParentTask>().Remove(pTask), Times.Once());


        }
        [Test]
        public void SaveChange_Test()
        {
            ParentTask pTask = new ParentTask();
            pTask.ParentId = 1;
            pTask.TaskName = "ABCD";
            var ptasks = new List<ParentTask>();
            ptasks.Add(pTask);
            var t = ptasks.AsQueryable();
            //var mockSet = new Mock<DbSet<Task_Table>>();
            var mockSet = new Mock<DbSet<ParentTask>>();
            mockSet.As<IQueryable<ParentTask>>().Setup(m => m.Provider).Returns(t.Provider);
            mockSet.As<IQueryable<ParentTask>>().Setup(m => m.Expression).Returns(t.Expression);
            mockSet.As<IQueryable<ParentTask>>().Setup(m => m.ElementType).Returns(t.ElementType);
            mockSet.As<IQueryable<ParentTask>>().Setup(m => m.GetEnumerator()).Returns(t.GetEnumerator());


            var mockTaskMangerContext = new Mock<ProjectmanagerContext>();
            mockTaskMangerContext.Setup(c => c.ParentTasks).Returns(mockSet.Object);
            mockTaskMangerContext.Setup(c => c.Set<ParentTask>()).Returns(mockSet.Object);
            
            mockTaskMangerContext.Setup(p => p.SaveChanges());
            var objTestTaskrepo = new ProjectManagerRepository<ParentTask>(mockTaskMangerContext.Object);
            objTestTaskrepo.SaveChange();

            mockTaskMangerContext.Verify(mock => mock.SaveChanges(), Times.Once());


        }
    }
}

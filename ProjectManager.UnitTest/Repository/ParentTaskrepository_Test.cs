using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using ProjectManager.DataAccess;

namespace ProjectManager.UnitTest.Repository
{
    [TestFixture]
    public class ParentTaskrepository_Test
    {
        [Test]
        public void AddParentTask_Test()
        {
            ParentTask ptask = new ParentTask();
            ptask.TaskName = "test";
            var mockTaskRepository = new Mock<IProjectManagerRepository<ParentTask>>(MockBehavior.Strict);
            mockTaskRepository.Setup(p => p.Create(ptask));
            mockTaskRepository.Setup(p => p.SaveChange());
            var objPtaskRepo = new ParentTaskRepository(mockTaskRepository.Object);
            objPtaskRepo.AddParentTask(ptask);
            mockTaskRepository.Verify(mock => mock.Create(ptask), Times.Once());
            mockTaskRepository.Verify(mock => mock.SaveChange(), Times.Once());
           
        }
        [Test]
        public void GetParentTasks_Test()
        {
            ParentTask ptask = new ParentTask();
            ptask.TaskName = "test";
            List<ParentTask> tasklist = new List<ParentTask>();
            tasklist.Add(ptask);
            
            IQueryable<ParentTask> pTasks = tasklist.AsQueryable();
            var mockTaskRepository = new Mock<IProjectManagerRepository<ParentTask>>(MockBehavior.Strict);
            mockTaskRepository.Setup(p => p.All).Returns(pTasks);
            var objPtaskRepo = new ParentTaskRepository(mockTaskRepository.Object);
            var returnTasks=objPtaskRepo.GetParentTasks();
            mockTaskRepository.Verify(mock => mock.All, Times.Once());
            Assert.AreEqual(returnTasks.ToList().Count, 1);

        }
    }
}

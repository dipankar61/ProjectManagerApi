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
    public class TaskRepository_Test
    {
        [Test]
        public void AddTask_Test()
        {
            Task tsk = new Task();
            tsk.TaskName = "testTask";
            tsk.StartDate = DateTime.Now;
            tsk.EndDate = DateTime.Now.AddDays(1);
            tsk.Priority = 10;
            tsk.UserId = 1;
            tsk.ProjectId = 1;
            tsk.TaskId = 5;
            var mocktaskRepository = new Mock<IProjectManagerRepository<Task>>(MockBehavior.Strict);
            mocktaskRepository.Setup(p => p.Create(tsk));
            mocktaskRepository.Setup(p => p.SaveChange());
            var objtaskRepo = new TaskRepository(mocktaskRepository.Object);
            objtaskRepo.AddTask(tsk);
            mocktaskRepository.Verify(mock => mock.Create(tsk), Times.Once());
            mocktaskRepository.Verify(mock => mock.SaveChange(), Times.Once());
        }
        [Test]
        public void Update_Test()
        {
            Task tsk = new Task();
            tsk.TaskName = "testTask";
            tsk.StartDate = DateTime.Now;
            tsk.EndDate = DateTime.Now.AddDays(1);
            tsk.Priority = 10;
            tsk.UserId = 1;
            tsk.ProjectId = 1;
            tsk.TaskId = 5;
            var mocktaskRepository = new Mock<IProjectManagerRepository<Task>>(MockBehavior.Strict);
            mocktaskRepository.Setup(p => p.Update(tsk));
            mocktaskRepository.Setup(p => p.SaveChange());
            var objtaskRepo = new TaskRepository(mocktaskRepository.Object);
            objtaskRepo.UpdateTask(tsk);
            mocktaskRepository.Verify(mock => mock.Update(tsk), Times.Once());
            mocktaskRepository.Verify(mock => mock.SaveChange(), Times.Once());
        }
        [Test]
        public void GetAllTask_Test()
        {
            Task tsk = new Task();
            tsk.TaskName = "testTask";
            tsk.StartDate = DateTime.Now;
            tsk.EndDate = DateTime.Now.AddDays(1);
            tsk.Priority = 10;
            tsk.UserId = 1;
            tsk.ProjectId = 1;
            tsk.TaskId = 5;
            List<Task> taskList = new List<Task>();
            taskList.Add(tsk);

            IQueryable<Task> Tasks = taskList.AsQueryable();
            var mocktaskRepository = new Mock<IProjectManagerRepository<Task>>(MockBehavior.Strict);
            mocktaskRepository.Setup(p => p.All).Returns(Tasks);
            var objtaskRepo = new TaskRepository(mocktaskRepository.Object);
            var Returntasks=objtaskRepo.GetAllTask();
            Assert.AreEqual(Returntasks.ToList().Count, 1);
            Assert.IsTrue(Returntasks.ToList().Any(item => item.TaskName == "testTask"));

        }
        [Test]
        public void GetTaskById_Test()
        {
            Task tsk = new Task();
            tsk.TaskName = "testTask";
            tsk.StartDate = DateTime.Now;
            tsk.EndDate = DateTime.Now.AddDays(1);
            tsk.Priority = 10;
            tsk.UserId = 1;
            tsk.ProjectId = 1;
            tsk.TaskId = 5;
            var mocktaskRepository = new Mock<IProjectManagerRepository<Task>>(MockBehavior.Strict);
            mocktaskRepository.Setup(p => p.GetById(5)).Returns(tsk);
            var objtaskRepo = new TaskRepository(mocktaskRepository.Object);
            var Returntasks = objtaskRepo.GetTaskById(5);
            mocktaskRepository.Verify(mock => mock.GetById(5), Times.Once());
            Assert.AreEqual(Returntasks.TaskId, tsk.TaskId);

        }
    }
}

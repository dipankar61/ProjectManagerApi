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
    public class Taskhandler_Test
    {
        [Test]
        public void AddTask_Test()
        {
            TaskViewModel taskVm = new TaskViewModel();
            taskVm.TaskName = "testTask1";
            taskVm.StartDate = DateTime.Now;
            taskVm.EndDate = DateTime.Now.AddDays(1);
            taskVm.Priority = 10;
            taskVm.UserId = 1;
            taskVm.ProjectId = 1;
            taskVm.TaskId = 5;

            Task tsk2 = new Task();
            tsk2.TaskName = "testTask2";
            tsk2.StartDate = DateTime.Now;
            tsk2.EndDate = DateTime.Now.AddDays(1);
            tsk2.Priority = 10;
            tsk2.UserId = 1;
            tsk2.ProjectId = 1;
            tsk2.TaskId = 6;

            Task tsk3 = new Task();
            tsk3.TaskName = "testTask3";
            tsk3.StartDate = DateTime.Now;
            tsk3.EndDate = DateTime.Now.AddDays(1);
            tsk3.Priority = 10;
            tsk3.UserId = 1;
            tsk3.ProjectId = 1;
            tsk3.TaskId = 7;
            List<Task> tskList = new List<Task>();
            tskList.Add(tsk2);
            tskList.Add(tsk3);
            IQueryable<Task> Tasks = tskList.AsQueryable();
            var mockRepo = new Mock<ITaskRepository>();
            mockRepo.Setup(p => p.GetAllTask()).Returns(Tasks);
            var handler = new TaskHandler(mockRepo.Object);
            handler.AddTask(taskVm);
            mockRepo.Verify(mock => mock.GetAllTask(), Times.Once());

        }
        [Test]
        public void AddTask_Failure_Test()
        {
            TaskViewModel taskVm = new TaskViewModel();
            taskVm.TaskName = "testTask1";
            taskVm.StartDate = DateTime.Now;
            taskVm.EndDate = DateTime.Now.AddDays(1);
            taskVm.Priority = 10;
            taskVm.UserId = 1;
            taskVm.ProjectId = 1;
            taskVm.TaskId = 5;

            Task tsk2 = new Task();
            tsk2.TaskName = "testTask1";
            tsk2.StartDate = DateTime.Now;
            tsk2.EndDate = DateTime.Now.AddDays(1);
            tsk2.Priority = 10;
            tsk2.UserId = 1;
            tsk2.ProjectId = 1;
            tsk2.TaskId = 6;

            Task tsk3 = new Task();
            tsk3.TaskName = "testTask3";
            tsk3.StartDate = DateTime.Now;
            tsk3.EndDate = DateTime.Now.AddDays(1);
            tsk3.Priority = 10;
            tsk3.UserId = 1;
            tsk3.ProjectId = 1;
            tsk3.TaskId = 7;
            List<Task> tskList = new List<Task>();
            tskList.Add(tsk2);
            tskList.Add(tsk3);
            IQueryable<Task> Tasks = tskList.AsQueryable();
            var mockRepo = new Mock<ITaskRepository>();
            mockRepo.Setup(p => p.GetAllTask()).Returns(Tasks);
            var handler = new TaskHandler(mockRepo.Object);
            Assert.That(() => handler.AddTask(taskVm),
           Throws.TypeOf<CustomException>());
            mockRepo.Verify(mock => mock.GetAllTask(), Times.Once());

        }
        [Test]
        public void UpdateTask_Failure_Test()
        {
            TaskViewModel taskVm = new TaskViewModel();
            taskVm.TaskName = "testTask3";
            taskVm.StartDate = DateTime.Now;
            taskVm.EndDate = DateTime.Now.AddDays(1);
            taskVm.Priority = 10;
            taskVm.UserId = 1;
            taskVm.ProjectId = 1;
            taskVm.TaskId = 5;

            Task tsk2 = new Task();
            tsk2.TaskName = "testTask2";
            tsk2.StartDate = DateTime.Now;
            tsk2.EndDate = DateTime.Now.AddDays(1);
            tsk2.Priority = 10;
            tsk2.UserId = 1;
            tsk2.ProjectId = 1;
            tsk2.TaskId = 5;

            Task tsk3 = new Task();
            tsk3.TaskName = "testTask3";
            tsk3.StartDate = DateTime.Now;
            tsk3.EndDate = DateTime.Now.AddDays(1);
            tsk3.Priority = 10;
            tsk3.UserId = 1;
            tsk3.ProjectId = 1;
            tsk3.TaskId = 7;
            List<Task> tskList = new List<Task>();
            tskList.Add(tsk2);
            tskList.Add(tsk3);
            IQueryable<Task> Tasks = tskList.AsQueryable();
            var mockRepo = new Mock<ITaskRepository>();
            mockRepo.Setup(p => p.GetAllTask()).Returns(Tasks);
            mockRepo.Setup(p => p.GetTaskById(taskVm.TaskId)).Returns(tsk2);
            var handler = new TaskHandler(mockRepo.Object);
            Assert.That(() => handler.UpdateTask(taskVm),
           Throws.TypeOf<CustomException>());
            mockRepo.Verify(mock => mock.GetAllTask(), Times.Once());

        }
        [Test]
        public void UpdateTask_Test()
        {
            TaskViewModel taskVm = new TaskViewModel();
            taskVm.TaskName = "testTask1";
            taskVm.StartDate = DateTime.Now;
            taskVm.EndDate = DateTime.Now.AddDays(1);
            taskVm.Priority = 10;
            taskVm.UserId = 1;
            taskVm.ProjectId = 1;
            taskVm.TaskId = 5;

            Task tsk2 = new Task();
            tsk2.TaskName = "testTask2";
            tsk2.StartDate = DateTime.Now;
            tsk2.EndDate = DateTime.Now.AddDays(1);
            tsk2.Priority = 10;
            tsk2.UserId = 1;
            tsk2.ProjectId = 1;
            tsk2.TaskId = 5;

            Task tsk3 = new Task();
            tsk3.TaskName = "testTask3";
            tsk3.StartDate = DateTime.Now;
            tsk3.EndDate = DateTime.Now.AddDays(1);
            tsk3.Priority = 10;
            tsk3.UserId = 1;
            tsk3.ProjectId = 1;
            tsk3.TaskId = 7;
            List<Task> tskList = new List<Task>();
            tskList.Add(tsk2);
            tskList.Add(tsk3);
            IQueryable<Task> Tasks = tskList.AsQueryable();
            var mockRepo = new Mock<ITaskRepository>();
            mockRepo.Setup(p => p.GetAllTask()).Returns(Tasks);
            mockRepo.Setup(p => p.GetTaskById(taskVm.TaskId)).Returns(tsk2);
            var handler = new TaskHandler(mockRepo.Object);
            handler.UpdateTask(taskVm);
            mockRepo.Verify(mock => mock.GetTaskById(taskVm.TaskId), Times.Once());

        }

        [Test]
        public void GetAllTasks_Test()
        {
            

            Task tsk2 = new Task();
            tsk2.TaskName = "testTask2";
            tsk2.StartDate = DateTime.Now;
            tsk2.EndDate = DateTime.Now.AddDays(1);
            tsk2.Priority = 10;
            tsk2.UserId = 1;
            tsk2.ProjectId = 1;
            tsk2.TaskId = 6;
            tsk2.ParentId = 1;
            tsk2.User = new User();
            tsk2.Project = new Project();
            tsk2.Parent = new ParentTask();
            Task tsk3 = new Task();
            tsk3.TaskName = "testTask3";
            tsk3.StartDate = DateTime.Now;
            tsk3.EndDate = DateTime.Now.AddDays(1);
            tsk3.Priority = 10;
            tsk3.UserId = 1;
            tsk3.ProjectId = 1;
            tsk3.TaskId = 7;
            tsk3.ParentId = 1;
            tsk3.User = new User();
            tsk3.Project = new Project();
            tsk3.Parent = new ParentTask();
            List<Task> tskList = new List<Task>();
            tskList.Add(tsk2);
            tskList.Add(tsk3);
            IQueryable<Task> Tasks = tskList.AsQueryable();
            var mockRepo = new Mock<ITaskRepository>();
            mockRepo.Setup(p => p.GetAllTask()).Returns(Tasks);
            var handler = new TaskHandler(mockRepo.Object);
            var retList = handler.GetAllTasks();
            mockRepo.Verify(mock => mock.GetAllTask(), Times.Once());
            Assert.AreEqual(retList.Count, tskList.Count);
            Assert.AreEqual(retList[0].TaskName, tskList[0].TaskName);

        }
        [Test]
        public void GetTask_Test()
        {


            Task tsk2 = new Task();
            tsk2.TaskName = "testTask2";
            tsk2.StartDate = DateTime.Now;
            tsk2.EndDate = DateTime.Now.AddDays(1);
            tsk2.Priority = 10;
            tsk2.UserId = 1;
            tsk2.ProjectId = 1;
            tsk2.TaskId = 6;
            tsk2.ParentId = 1;
            tsk2.User = new User();
            tsk2.Project = new Project();
            tsk2.Parent = new ParentTask();
            Task tsk3 = new Task();
            tsk3.TaskName = "testTask3";
            tsk3.StartDate = DateTime.Now;
            tsk3.EndDate = DateTime.Now.AddDays(1);
            tsk3.Priority = 10;
            tsk3.UserId = 1;
            tsk3.ProjectId = 1;
            tsk3.TaskId = 7;
            tsk3.ParentId = 1;
            tsk3.User = new User();
            tsk3.Project = new Project();
            tsk3.Parent = new ParentTask();
            
            var mockRepo = new Mock<ITaskRepository>();
            mockRepo.Setup(p => p.GetTaskById(6)).Returns(tsk2);
            var handler = new TaskHandler(mockRepo.Object);
            var tsk = handler.GetTask(6);
            mockRepo.Verify(mock => mock.GetTaskById(6), Times.Once());
            Assert.AreEqual(tsk.TaskId, tsk2.TaskId);
            Assert.AreEqual(tsk.TaskName, tsk.TaskName);

        }
    }
}

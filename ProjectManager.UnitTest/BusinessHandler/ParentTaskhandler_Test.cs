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
    public class ParentTaskhandler_Test
    {
        [Test]
        public void AddParenTask_Test()
        {
            ParentTaskViewModel ptaskVModel = new ParentTaskViewModel();
            ptaskVModel.TaskName = "PTest1";
            ParentTask ptaskAdd = new ParentTask()
            {
                TaskName = ptaskVModel.TaskName
            };
           

            ParentTask ptaskList1 = new ParentTask();
            ptaskList1.TaskName = "PTest2";
            ParentTask ptaskList2 = new ParentTask();
            ptaskList2.TaskName = "PTest3";
            List<ParentTask> ptaskList = new List<ParentTask>();
            ptaskList.Add(ptaskList1);
            ptaskList.Add(ptaskList2);
            IQueryable<ParentTask> pTasks = ptaskList.AsQueryable();
            var mockRepo = new Mock<IParentTaskRepository>();
            mockRepo.Setup(p => p.AddParentTask(ptaskAdd));
            mockRepo.Setup(p => p.GetParentTasks()).Returns(pTasks);
            var handler = new ParentTaskhandler(mockRepo.Object);
            handler.AddParentTask(ptaskVModel);
            mockRepo.Verify(mock => mock.GetParentTasks(), Times.Once());
            



        }
        [Test]
        public void AddParentTask_Failure_Test()
        {
            ParentTaskViewModel ptaskVModel = new ParentTaskViewModel();
            ptaskVModel.TaskName = "PTest2";
            ParentTask ptaskAdd = new ParentTask()
            {
                TaskName = ptaskVModel.TaskName
            };


            ParentTask ptaskList1 = new ParentTask();
            ptaskList1.TaskName = "PTest2";
            ParentTask ptaskList2 = new ParentTask();
            ptaskList2.TaskName = "PTest3";
            List<ParentTask> ptaskList = new List<ParentTask>();
            ptaskList.Add(ptaskList1);
            ptaskList.Add(ptaskList2);
            IQueryable<ParentTask> pTasks = ptaskList.AsQueryable();
            var mockRepo = new Mock<IParentTaskRepository>();
            mockRepo.Setup(p => p.GetParentTasks()).Returns(pTasks);
            var handler = new ParentTaskhandler(mockRepo.Object);
           
            Assert.That(() => handler.AddParentTask(ptaskVModel),
             Throws.TypeOf<CustomException>());

        }
        [Test]
        public void GetParentTasks_Test()
        {
            ParentTask ptaskList1 = new ParentTask();
            ptaskList1.TaskName = "PTest2";
            ParentTask ptaskList2 = new ParentTask();
            ptaskList2.TaskName = "PTest3";
            List<ParentTask> ptaskList = new List<ParentTask>();
            ptaskList.Add(ptaskList1);
            ptaskList.Add(ptaskList2);
            IQueryable<ParentTask> pTasks = ptaskList.AsQueryable();
            var mockRepo = new Mock<IParentTaskRepository>();
            mockRepo.Setup(p => p.GetParentTasks()).Returns(pTasks);
            var handler = new ParentTaskhandler(mockRepo.Object);
            var retList=handler.GetparentTasks();
            mockRepo.Verify(mock => mock.GetParentTasks(), Times.Once());
            Assert.AreEqual(retList.Count, ptaskList.Count);
            Assert.AreEqual(retList[0].TaskName, ptaskList[0].TaskName);

        }
    }
}

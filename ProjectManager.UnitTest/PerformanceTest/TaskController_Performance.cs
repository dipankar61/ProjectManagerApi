using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NBench;
using ProjectManagerWebApi.Controllers;
using ProjectManager.DataAccess;
using ProjectManager.Business;

namespace ProjectManager.UnitTest.PerformanceTest
{
    public class TaskController_Performance
    {
        private Counter _counter;
        private TaskController _controller;
        private TaskViewModel _Task;


        [PerfSetup]
        public void Setup(BenchmarkContext context)
        {
            _counter = context.GetCounter("TestCounter");
            _controller = new TaskController();
            _Task = new TaskViewModel() { TaskName = "Test1", Priority = 1, StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(1), UserId = 1, ProjectId = 1 };

        }

        [PerfBenchmark(Description = "Add task through put test.",
        NumberOfIterations = 500, RunMode = RunMode.Throughput,
        RunTimeMilliseconds = 1200, TestMode = TestMode.Measurement)]
        [CounterMeasurement("TestCounter")]
        [MemoryAssertion(MemoryMetric.TotalBytesAllocated, MustBe.LessThanOrEqualTo, ByteConstants.ThirtyTwoKb)]
        [GcTotalAssertion(GcMetric.TotalCollections, GcGeneration.Gen2, MustBe.ExactlyEqualTo, 0.0d)]
        public void AddTask()
        {
            _controller.PostNewTask(_Task);
            _counter.Increment();
        }

        [PerfBenchmark(Description = "Get All  Tasks.",
        NumberOfIterations = 500, RunMode = RunMode.Throughput,
        RunTimeMilliseconds = 1200, TestMode = TestMode.Measurement)]
        [CounterMeasurement("TestCounter")]
        [MemoryAssertion(MemoryMetric.TotalBytesAllocated, MustBe.LessThanOrEqualTo, ByteConstants.ThirtyTwoKb)]
        [GcTotalAssertion(GcMetric.TotalCollections, GcGeneration.Gen2, MustBe.ExactlyEqualTo, 0.0d)]
        public void GetAllParentTasks()
        {
            _controller.GetAllTasks();
            _counter.Increment();
        }

        [PerfCleanup]
        public void Cleanup()
        {

        }
    }
}

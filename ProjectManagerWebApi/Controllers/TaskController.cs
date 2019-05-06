using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ProjectManager.Business;

namespace ProjectManagerWebApi.Controllers
{
    public class TaskController : ApiController
    {
        private readonly ITaskHandler taskHandler;
        private readonly IParentTaskHandler pTaskHandler;
        public TaskController()
        {
            var controller = new BusinessController();
            taskHandler = controller.GetTaskHandler();
            pTaskHandler = controller.GetParentTaskHandler();
        }
        public IHttpActionResult GetAllTasks()
        {
            try
            {
                var allTasks = taskHandler.GetAllTasks();
                if (allTasks.Count == 0)
                    return NotFound();
                return Ok(allTasks);

            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        public IHttpActionResult GetTask(int Id)
        {
            try
            {
                var task = taskHandler.GetTask(Id);
                if (task ==null)
                    return NotFound();
                return Ok(task);

            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }
        public IHttpActionResult PostNewTask(TaskViewModel task)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Invalid data.");

                taskHandler.AddTask(task);
                return Ok();

            }
            catch (CustomException ex)
            {
                return BadRequest(ex.ExceptionMsg);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        public IHttpActionResult PutUpdateProject(TaskViewModel task)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Invalid data.");

                taskHandler.UpdateTask(task);
                return Ok();

            }
            catch (CustomException ex)
            {
                return BadRequest(ex.ExceptionMsg);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}

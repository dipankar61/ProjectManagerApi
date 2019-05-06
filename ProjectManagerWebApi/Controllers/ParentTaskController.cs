using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ProjectManager.Business;

namespace ProjectManagerWebApi.Controllers
{
    public class ParentTaskController : ApiController
    {
        private readonly IParentTaskHandler pTaskHandler;
        public ParentTaskController()
        {
            var controller = new BusinessController();
            pTaskHandler = controller.GetParentTaskHandler();
        }
        public IHttpActionResult GetAllParentTasks()
        {
            try
            {
                var allParentTasks = pTaskHandler.GetparentTasks();
                if (allParentTasks.Count == 0)
                    return NotFound();
                return Ok(allParentTasks);

            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        public IHttpActionResult PostNewParentTask(ParentTaskViewModel task)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Invalid data.");

                pTaskHandler.AddParentTask(task);
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

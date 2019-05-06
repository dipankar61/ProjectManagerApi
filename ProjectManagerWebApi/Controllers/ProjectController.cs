using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ProjectManager.Business;

namespace ProjectManagerWebApi.Controllers
{
    public class ProjectController : ApiController
    {
        private readonly IProjectHandler projHandler;
        public ProjectController()
        {
            var controller = new BusinessController();
            projHandler = controller.GetProjectHandler();
        }
        public IHttpActionResult GetAllProjects()
        {
            try
            {
                var allProjects = projHandler.GetAllProjects();
                if (allProjects.Count == 0)
                    return NotFound();
                return Ok(allProjects);

            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        public IHttpActionResult PostNewProj(ProjectViewModel proj)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Invalid data.");

                projHandler.AddProject(proj);
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
        public IHttpActionResult PutUpdateProject(ProjectViewModel proj)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Invalid data.");

                projHandler.UpdateProject(proj);
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

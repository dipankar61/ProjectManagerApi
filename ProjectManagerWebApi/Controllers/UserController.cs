using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ProjectManager.Business;

namespace ProjectManagerWebApi.Controllers
{
    public class UserController : ApiController
    {
        private readonly IUserHandler userHandler;
        public UserController()
        {
            var controller = new BusinessController();
            userHandler = controller.GetUserHandler();
        }
       
        public IHttpActionResult GetAllUser()
        {
            try
            {
                var allUser = userHandler.GetAllUsers();
                if (allUser.Count == 0)
                    return NotFound();
                return Ok(allUser);

            }
            catch(Exception ex)
            {
                return InternalServerError(ex);
            }
        }

      
        public IHttpActionResult PostNewUser(UserViewModel user)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Invalid data.");

                userHandler.AddUser(user);
                return Ok();

            }
            catch(CustomException ex)
            {
                return BadRequest(ex.ExceptionMsg);
            }
            catch(Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        
        public IHttpActionResult PutUpdateUser(UserViewModel user)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Invalid data.");

                userHandler.UpdateUser(user);
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

        
        public IHttpActionResult Delete(int Id)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Invalid data.");

                userHandler.DeleteUser(Id);
                return Ok();

            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}

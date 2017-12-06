using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Routing;
using Bryan.Architecture.BusinessLogic.Interface;
using Bryan.Architecture.DomainModel.Dto.User;

namespace Bryan.Architecture.Service.Controllers
{
    /// <summary>The user controller.</summary>
    public class UserController : ApiController
    {
        /// <summary>The _user bll.</summary>
        private readonly IUserBll _userBll;

        /// <summary>Initializes a new instance of the <see cref="UserController"/> class.</summary>
        /// <param name="userBll">The user BLL.</param>
        public UserController(IUserBll userBll)
        {
            this._userBll = userBll;
        }

        /// <summary>The get user.</summary>
        /// <param name="dto">The dto.</param>
        /// <returns>The <see cref="IHttpActionResult"/>.</returns>
        [HttpGet]
        [Route("GetUser")]
        public IHttpActionResult GetUser([FromUri]GetUserDto dto)
        {
            var result = this._userBll.GetUser(dto);
            return this.Ok(result);
        }

        /// <summary>The update user.</summary>
        /// <param name="dto">The dto.</param>
        /// <returns>The <see cref="IHttpActionResult"/>.</returns>
        [HttpPost]
        [Route("UpdateUser")]
        public IHttpActionResult UpdateUser([FromBody] UpdateUserDto dto)
        {
            var result = this._userBll.UpdateUser(dto);
            return this.Ok(result);
        }

        /// <summary>The add user.</summary>
        /// <param name="dto">The dto.</param>
        /// <returns>The <see cref="IHttpActionResult"/>.</returns>
        [HttpPost]
        [Route("AddUser")]
        public IHttpActionResult AddUser([FromBody] AddUserDto dto)
        {
            var result = this._userBll.AddUser(dto);
            return this.Ok(result);
        }

        /// <summary>The delete user.</summary>
        /// <param name="id">The id.</param>
        /// <returns>The <see cref="IHttpActionResult"/>.</returns>
        [HttpPost]
        [Route("DeleteUser")]
        public IHttpActionResult DeleteUser([FromBody] int id)
        {
            var result = this._userBll.DeleteUser(id);
            return this.Ok(result);
        }
    }
}
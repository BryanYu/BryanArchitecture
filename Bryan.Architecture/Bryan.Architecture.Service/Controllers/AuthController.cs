using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Bryan.Architecture.BusinessLogic.Interface;
using Bryan.Architecture.DomainModel.Dto.User;

namespace Bryan.Architecture.Service.Controllers
{
    /// <summary>
    /// Auth
    /// </summary>
    public class AuthController : ApiController
    {
        /// <summary>The _user bll.</summary>
        private readonly IUserBll _userBll;

        /// <summary>Initializes a new instance of the <see cref="AuthController"/> class.</summary>
        /// <param name="userBll">The user BLL.</param>
        public AuthController(IUserBll userBll)
        {
            this._userBll = userBll;
        }

        /// <summary>The login.</summary>
        /// <param name="dto">The dto.</param>
        /// <returns>The <see cref="IHttpActionResult"/>.</returns>
        public IHttpActionResult Login([FromBody]LoginDto dto)
        {
            var result = this._userBll.Login(dto);
            return this.Ok(result);
        }

        /// <summary>The get user.</summary>
        /// <param name="id">The id.</param>
        /// <param name="name">The name.</param>
        /// <param name="password">The password.</param>
        /// <returns>The <see cref="IHttpActionResult"/>.</returns>
        [HttpGet]
        public IHttpActionResult GetUser([FromUri]GetUserDto dto)
        {
            var result = this._userBll.GetUser(dto);
            return this.Ok(result);
        }
    }
}
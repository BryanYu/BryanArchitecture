using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Bryan.Architecture.BusinessLogic.Interface;

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
        /// <param name="account">The account.</param>
        /// <param name="password">The password.</param>
        /// <returns>The <see cref="IHttpActionResult"/>.</returns>
        public IHttpActionResult Login(string account, string password)
        {
            var result = this._userBll.Login(account, password);
            return this.Ok(result);
        }
    }
}
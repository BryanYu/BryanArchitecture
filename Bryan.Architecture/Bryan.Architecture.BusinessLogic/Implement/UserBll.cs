using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Bryan.Architecture.BusinessLogic.Interface;
using Bryan.Architecture.DomainModel.Base;

namespace Bryan.Architecture.BusinessLogic.Implement
{
    /// <summary>The user bll.</summary>
    public class UserBll : IUserBll
    {
        public UserBll()
        {
        }

        /// <summary>The login.</summary>
        /// <param name="account">The account.</param>
        /// <param name="password">The password.</param>
        /// <returns>The <see cref="ExecuteResult{T}"/>.</returns>
        /// <exception cref="NotImplementedException">NotImplementedException</exception>
        public ExecuteResult<object> Login(string account, string password)
        {
            throw new NotFiniteNumberException();
        }
    }
}
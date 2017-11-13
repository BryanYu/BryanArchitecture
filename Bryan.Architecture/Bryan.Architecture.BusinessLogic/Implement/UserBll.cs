using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Bryan.Architecture.BusinessLogic.Interface;
using Bryan.Architecture.DataAccess;
using Bryan.Architecture.DataAccess.Base;
using Bryan.Architecture.DomainModel.Base;
using Bryan.Architecture.DomainModel.Base.Enum;
using Bryan.Architecture.DomainModel.User;

namespace Bryan.Architecture.BusinessLogic.Implement
{
    /// <summary>The user bll.</summary>
    public class UserBll : IUserBll
    {
        /// <summary>The _user repository.</summary>
        private IRepository<User> _userRepository;

        /// <summary>Initializes a new instance of the <see cref="UserBll"/> class.</summary>
        /// <param name="userRepository">The user repository.</param>
        public UserBll(IRepository<User> userRepository)
        {
            this._userRepository = userRepository;
        }

        /// <summary>The login.</summary>
        /// <param name="account">The account.</param>
        /// <param name="password">The password.</param>
        /// <returns>The <see cref="ExecuteResult{T}"/>.</returns>
        public ExecuteResult<string> Login(string account, string password)
        {
            var user = this._userRepository.Get(item => item.Account == account && item.Password == password);
            if (user != null)
            {
                var token = string.Empty;
                return new ExecuteResult<string> { Status = ExcuteResultStatus.UserNotFound, Data = token };
            }

            return new ExecuteResult<string>() { Status = ExcuteResultStatus.Success };
        }
    }
}
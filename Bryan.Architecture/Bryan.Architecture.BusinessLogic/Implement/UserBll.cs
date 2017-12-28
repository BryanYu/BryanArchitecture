using Autofac.Extras.DynamicProxy;
using Bryan.Architecture.AOP.Interceptor;
using Bryan.Architecture.BusinessLogic.Interface;
using Bryan.Architecture.BusinessLogic.Properties;
using Bryan.Architecture.DataAccess;
using Bryan.Architecture.DataAccess.Base;
using Bryan.Architecture.DomainModel.Base;
using Bryan.Architecture.DomainModel.Base.Enum;
using Bryan.Architecture.DomainModel.Dto.User;
using Bryan.Architecture.Utility.AOP.Attributes;
using Bryan.Architecture.Utility.Cryptography;
using Bryan.Architecture.Utility.Logger.Enum;

namespace Bryan.Architecture.BusinessLogic.Implement
{
    /// <summary>The user bll.</summary>
    [Intercept(typeof(Interceptor))]
    public class UserBll : IUserBll
    {
        /// <summary>The _user repository.</summary>
        private readonly IRepository<User> _userRepository;

        /// <summary>Initializes a new instance of the <see cref="UserBll"/> class.</summary>
        /// <param name="userRepository">The user repository.</param>
        public UserBll(IRepository<User> userRepository)
        {
            this._userRepository = userRepository;
        }

        /// <summary>The get user.</summary>
        /// <param name="dto">The dto.</param>
        /// <returns>The <see cref="ExecuteResult{T}"/>.</returns>
        [Log(IsLogArguments = true, Level = LoggerLevel.Trace)]
        [Cache(ExpiredSecond = 3600)]
        public ExecuteResult<UserDto> GetUser(GetUserDto dto)
        {
            var user = this._userRepository.Get(
                item => item.Account == dto.Account,
                item2 => new UserDto { Id = item2.Id, Account = item2.Account, Password = item2.Password });

            return new ExecuteResult<UserDto>(data: user);
        }

        /// <summary>The login.</summary>
        /// <param name="dto">The dto.</param>
        /// <returns>The <see cref="ExecuteResult{T}"/>.</returns>
        public ExecuteResult<string> Login(LoginDto dto)
        {
            var hashPassword = Md5.GetHash(dto.Password);
            var user = this._userRepository.Get(item => item.Account == dto.Account
                                                     && item.Password == hashPassword);
            if (user != null)
            {
                var token = JwtToken.Generate(Settings.Default.Secret, user);
                return new ExecuteResult<string>(data: token);
            }

            return new ExecuteResult<string>(status: ExcuteResultStatus.UserNotFound);
        }

        /// <summary>The update user.</summary>
        /// <param name="dto">The dto.</param>
        /// <returns>The <see cref="ExecuteResult{T}"/>.</returns>
        public ExecuteResult<object> UpdateUser(UpdateUserDto dto)
        {
            var user = this._userRepository.Get(item => item.Id == dto.Id);
            if (user == null)
            {
                return new ExecuteResult<object>(ExcuteResultStatus.UserNotFound);
            }

            user.Phone = dto.Phone;
            this._userRepository.Update(user);
            return new ExecuteResult<object>();
        }

        /// <summary>The add user.</summary>
        /// <param name="dto">The dto.</param>
        /// <returns>The <see cref="ExecuteResult{T}"/>.</returns>
        public ExecuteResult<object> AddUser(AddUserDto dto)
        {
            var user = new User
            {
                Account = dto.Account,
                Password = Md5.GetHash(dto.Password),
                Phone = dto.Phone
            };
            this._userRepository.Insert(user);
            return new ExecuteResult<object>();
        }

        /// <summary>The delete user.</summary>
        /// <param name="id">The id.</param>
        /// <returns>The <see cref="ExecuteResult{T}"/>.</returns>
        public ExecuteResult<object> DeleteUser(int id)
        {
            this._userRepository.Delete(id);
            return new ExecuteResult<object>();
        }
    }
}
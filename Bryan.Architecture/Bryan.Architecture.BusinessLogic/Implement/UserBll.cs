using Autofac.Extras.DynamicProxy;
using Bryan.Architecture.BusinessLogic.Interceptor;
using Bryan.Architecture.BusinessLogic.Interface;
using Bryan.Architecture.BusinessLogic.Properties;
using Bryan.Architecture.DataAccess;
using Bryan.Architecture.DataAccess.Base;
using Bryan.Architecture.DomainModel.Base;
using Bryan.Architecture.DomainModel.Base.Enum;
using Bryan.Architecture.DomainModel.Dto.User;
using Bryan.Architecture.Utility.Attributes;
using Bryan.Architecture.Utility.Cryptography;
using Bryan.Architecture.Utility.Logger.Enum;

namespace Bryan.Architecture.BusinessLogic.Implement
{
    /// <summary>The user bll.</summary>
    [Intercept(typeof(BllInterceptor))]
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
            return new ExecuteResult<UserDto>
            {
                Data = new UserDto
                {
                    Id = dto.Id,
                    Name = dto.Name,
                    Password = dto.Password
                }
            };
        }

        /// <summary>The login.</summary>
        /// <param name="dto">The dto.</param>
        /// <returns>The <see cref="ExecuteResult{T}"/>.</returns>
        public ExecuteResult<string> Login(LoginDto dto)
        {
            var hashPassword = Md5.GetHash(dto.Password);
            var user = this._userRepository.Get(item => item.Account == dto.Account && item.Password == hashPassword);
            if (user != null)
            {
                var token = JwtToken.Generate(Settings.Default.Secret, user);
                return new ExecuteResult<string> { Status = ExcuteResultStatus.Success, Data = token };
            }

            return new ExecuteResult<string>() { Status = ExcuteResultStatus.UserNotFound };
        }
    }
}
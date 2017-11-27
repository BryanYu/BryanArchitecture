using Bryan.Architecture.DomainModel.Base;
using Bryan.Architecture.DomainModel.Dto.User;

namespace Bryan.Architecture.BusinessLogic.Interface
{
    /// <summary>The UserBll interface.</summary>
    public interface IUserBll
    {
        /// <summary>The login.</summary>
        /// <param name="dto">The dto.</param>
        /// <returns>The <see cref="ExecuteResult{T}"/>.</returns>
        ExecuteResult<string> Login(LoginDto dto);

        /// <summary>The get user.</summary>
        /// <param name="dto">The dto.</param>
        /// <returns>The <see cref="ExecuteResult"/>.</returns>
        ExecuteResult<UserDto> GetUser(GetUserDto dto);
    }
}
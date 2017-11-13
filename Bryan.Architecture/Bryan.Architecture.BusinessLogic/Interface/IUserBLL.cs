using Bryan.Architecture.DomainModel.Base;

namespace Bryan.Architecture.BusinessLogic.Interface
{
    /// <summary>The UserBll interface.</summary>
    public interface IUserBll
    {
        /// <summary>The login.</summary>
        /// <param name="account">The account.</param>
        /// <param name="password">The password.</param>
        /// <returns>The <see cref="ExecuteResult{T}"/>object</returns>
        ExecuteResult<object> Login(string account, string password);
    }
}
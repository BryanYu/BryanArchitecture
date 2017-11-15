using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Bryan.Architecture.BusinessLogic.Implement;
using Bryan.Architecture.BusinessLogic.Interface;
using Bryan.Architecture.DataAccess.Base;
using Bryan.Architecture.DomainModel.Base;
using Bryan.Architecture.DomainModel.Base.Enum;
using Bryan.Architecture.DomainModel.Dto.User;

using Castle.DynamicProxy.Generators.Emitters.SimpleAST;

using NSubstitute;

using NUnit.Framework;
using System.Linq.Expressions;

namespace Bryan.Architecture.BusinessLogic.Tests.User
{
    [TestFixture]
    [Category("Bunsiness UserBll")]
    public class UserTests
    {
        [Test]
        public void When_User_Input_Account_And_Password_Return_Token()
        {
            var mockUserRepository = Substitute.For<IRepository<DataAccess.User>>();

            mockUserRepository.Get(Arg.Any<Expression<Func<DataAccess.User, bool>>>())
                .Returns(new DataAccess.User { Account = "Bryan" });

            var target = new UserBll(mockUserRepository);
            var actual = target.Login(new LoginDto { Account = "Bryan", Password = "BryanPassword" });

            Assert.NotNull(actual);
            Assert.AreEqual(ExcuteResultStatus.Success, actual.Status);
            Assert.IsNotEmpty(actual.Data);
        }
    }
}
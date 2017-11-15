using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bryan.Architecture.Utility.Cryptography;
using ExpectedObjects;
using NUnit.Framework;

namespace Bryan.Architecture.Utility.Cyptography.UnitTests
{
    /// <summary>The jwt token tests.</summary>
    [TestFixture]
    [Category("JwtTokenTests")]
    public class JwtTokenTests
    {
        /// <summary>The _secret.</summary>
        private readonly string _secret = "BryanJwtTokenSecret";

        /// <summary>The temp data.</summary>
        private readonly TempData _tempData = new TempData { Id = 1, Name = "Bryan", ExpiredTime = new DateTime(2017, 11, 14) };

        /// <summary>The when_ input_ t data_ get_ jwt token.</summary>
        [Test]
        public void When_Input_TData_Get_JwtToken()
        {
            var expected = @"eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJJZCI6MSwiTmFtZSI6IkJyeWFuIiwiRXhwaXJlZFRpbWUiOiIyMDE3LTExLTE0VDAwOjAwOjAwIn0.RqWN2mv3HUS33v-8h4PHMd7CUHztz_16tYQrQfJplNs";
            var actual = JwtToken.Generate<TempData>(this._secret, this._tempData);
            StringAssert.AreEqualIgnoringCase(expected, actual);
        }

        /// <summary>The when_ input_ token_ get_ t data.</summary>
        [Test]
        public void When_Input_Token_Get_TData()
        {
            var token = @"eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJJZCI6MSwiTmFtZSI6IkJyeWFuIiwiRXhwaXJlZFRpbWUiOiIyMDE3LTExLTE0VDAwOjAwOjAwIn0.RqWN2mv3HUS33v-8h4PHMd7CUHztz_16tYQrQfJplNs";
            var expected = this._tempData;
            var actual = JwtToken.Decode<TempData>(this._secret, token);
            expected.ToExpectedObject().ShouldEqual(actual);
        }
    }
}
using System;
using Bryan.Architecture.Utility.Cryptography;
using NUnit.Framework;

namespace Bryan.Architecture.Utility.Cyptography.UnitTests
{
    /// <summary>The md 5 tests.</summary>
    [TestFixture]
    [Category("Md5Tests")]
    public class Md5Tests
    {
        /// <summary>The when_ input_string_ get_ md5hash.</summary>
        [Test]
        public void When_Input_string_Get_Md5Hash()
        {
            var expected = "c8c5e5d635056e28d6779183190b25d4";
            var actual = Md5.GetHash("BryanPassword");
            StringAssert.AreEqualIgnoringCase(expected, actual);
        }
    }
}
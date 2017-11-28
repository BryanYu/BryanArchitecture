using System;
using System.Threading;

using Bryan.Architecture.Utility.Cache.Implement;
using Bryan.Architecture.Utility.Cache.Interface;

using NUnit.Framework;

namespace Bryan.Architecture.Utility.IntegrationTests.Cache
{
    /// <summary>The default cache tests.</summary>
    [TestFixture]
    [Category("IntegrationTests DefaultCacheTests")]
#if DEBUG
    [Ignore("local")]
#endif
    public class DefaultCacheTests
    {
        /// <summary>The _temp cache data.</summary>
        private TempCacheData _tempCacheData = new TempCacheData { Id = 1, Name = "Bryan" };

        /// <summary>The _target.</summary>
        private ICache _target = new DefaultCache();

        /// <summary>The when_ set_ value_ to_ cache_ get_ cache.</summary>
        [Test]
        public void When_Set_Value_To_Cache_Get_Cache()
        {
            this._target.Set("Bryan", this._tempCacheData, 30);
            var actual = this._target.Get<TempCacheData>("Bryan") != null;
            Assert.IsTrue(actual);
        }

        /// <summary>The when_ remove_ value_ success.</summary>
        [Test]
        public void When_Remove_Value_From_Cache_Get_Null()
        {
            this._target.Set("Bryan", this._tempCacheData, 30);
            this._target.Remove("Bryan");
            var actual = this._target.Get<TempCacheData>("Bryan") == null;
            Assert.IsTrue(actual);
        }

        /// <summary>The when_ set_ value_ with_ expired time_ is_ valid.</summary>
        [Test]
        public void When_Set_Value_With_ExpiredTime_Is_Valid()
        {
            this._target.Set("Bryan", this._tempCacheData, 1);
            Thread.Sleep(5000);
            var actual = this._target.Get<TempCacheData>("Bryan") == null;
            Assert.IsTrue(actual);
        }
    }
}
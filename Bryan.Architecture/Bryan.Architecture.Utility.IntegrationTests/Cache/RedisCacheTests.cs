using System;
using System.Threading;
using Bryan.Architecture.Utility.Cache.Implement;
using NUnit.Framework;

namespace Bryan.Architecture.Utility.IntegrationTests.Cache
{
    /// <summary>The redis cache tests.</summary>
    [TestFixture]
    [Category("IntegrationTests RedisCacheTests")]
#if DEBUG
    [Ignore("local")]
#endif
    public class RedisCacheTests
    {
        /// <summary>The target.</summary>
        private RedisCache _target;

        /// <summary>The _temp cache data.</summary>
        private TempCacheData _tempCacheData = new TempCacheData { Id = 1, Name = "Bryan" };

        /// <summary>The set up.</summary>
        [SetUp]
        public void SetUp()
        {
            this._target = new RedisCache(0, "35.197.147.100", password: "mayday00066");
        }

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

        /// <summary>The set down.</summary>
        [TearDown]
        public void TearDown()
        {
            this._target.Remove("Bryan");
        }
    }
}
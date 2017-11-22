using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Bryan.Architecture.Utility.Cache.Implement;
using NUnit.Framework;

namespace Bryan.Architecture.Utility.UnitTests.Cache
{
    /// <summary>The default cache tests.</summary>
    [TestFixture]
    public class DefaultCacheTests
    {
        /// <summary>The target.</summary>
        private DefaultCache _target = new DefaultCache();

        /// <summary>The _temp cache data.</summary>
        private TempCacheData _tempCacheData = new TempCacheData { Id = 1, Name = "Bryan" };

        /// <summary>The when_ set_ value_ to_ cache_ get_ cache.</summary>
        [Test]
        public void When_Set_Value_To_Cache_Get_Cache()
        {
            this._target.Set("Bryan", _tempCacheData, DateTime.Now.AddDays(1));
            var actual = this._target.Get<TempCacheData>("Bryan") != null;
            Assert.IsTrue(actual);
        }

        /// <summary>The when_ remove_ value_ success.</summary>
        [Test]
        public void When_Remove_Value_From_Cache_Get_Null()
        {
            this._target.Set("Bryan", this._tempCacheData, DateTime.Now.AddDays(1));
            this._target.Remove("Bryan");
            var actual = this._target.Get<TempCacheData>("Bryan") == null;
            Assert.IsTrue(actual);
        }

        /// <summary>The when_ set_ value_ with_ expired time_ is_ valid.</summary>
        [Test]
        public void When_Set_Value_With_ExpiredTime_Is_Valid()
        {
            this._target.Set("Bryan", this._tempCacheData, DateTime.Now.AddSeconds(1));
            Thread.Sleep(3000);
            var actual = this._target.Get<TempCacheData>("Bryan") == null;
            Assert.IsTrue(actual);
        }
    }
}
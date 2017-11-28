using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bryan.Architecture.Utility.Attributes
{
    /// <summary>The cache attribute.</summary>
    public class CacheAttribute : Attribute
    {
        /// <summary>Gets or sets the expired minutes.</summary>
        public int ExpiredSecond { get; set; }
    }
}
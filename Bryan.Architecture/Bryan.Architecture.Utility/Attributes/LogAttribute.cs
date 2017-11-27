using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bryan.Architecture.Utility.Logger.Enum;

namespace Bryan.Architecture.Utility.Attributes
{
    /// <summary>The log attribute.</summary>
    public class LogAttribute : Attribute
    {
        /// <summary>Gets or sets the level.</summary>
        public LoggerLevel Level { get; set; }

        /// <summary>Gets or sets a value indicating whether is log arguments.</summary>
        public bool IsLogArguments { get; set; }

        /// <summary>Gets or sets the message.</summary>
        public string Message { get; set; }
    }
}
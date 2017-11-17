using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bryan.Architecture.Utility.Logger.Enum;
using NUnit.Framework;

namespace Bryan.Architecture.Utility.UnitTests.Logger
{
    /// <summary>The logger test.</summary>
    [TestFixture]
    public class LoggerTest
    {
        /// <summary>The when_ rasie_ exception_ log_ to_ file.</summary>
        /// <param name="level">The level.</param>
        [TestCase(LoggerLevel.Trace)]
        [TestCase(LoggerLevel.Debug)]
        [TestCase(LoggerLevel.Info)]
        [TestCase(LoggerLevel.Warn)]
        [TestCase(LoggerLevel.Error)]
        [TestCase(LoggerLevel.Fatal)]
        public void When_Rasie_Exception_Log_To_File(LoggerLevel level)
        {
            try
            {
                int zero = 0;
                int i = 1 / zero;
            }
            catch (Exception e)
            {
                Bryan.Architecture.Utility.Logger.Logger.Log(level, e, message: "Test");

                var file = AppDomain.CurrentDomain.BaseDirectory + "\\Logs\\" + level.ToString() + ".log";
                FileAssert.Exists(file);
            }
        }
    }
}
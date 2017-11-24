using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bryan.Architecture.Utility.Logger.Enum;
using NUnit.Framework;

namespace Bryan.Architecture.Utility.UnitTests.Logger
{
    /// <summary>The logger test.</summary>
    [TestFixture]
    [Category("Integration LoggerTest")]
#if DEBUG
    [Ignore("local")]
#endif
    public class LoggerTest
    {
        /// <summary>The set up.</summary>
        [SetUp]
        public void SetUp()
        {
            this.DeleteLogFile();
        }

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

        /// <summary>The tear down.</summary>
        [TearDown]
        public void TearDown()
        {
            this.DeleteLogFile();
        }

        /// <summary>The delete log file.</summary>
        private void DeleteLogFile()
        {
            var fields = typeof(LoggerLevel).GetFields();

            foreach (var field in fields)
            {
                var path = AppDomain.CurrentDomain.BaseDirectory + "\\Logs\\" + field.Name + ".log";
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
            }
        }
    }
}
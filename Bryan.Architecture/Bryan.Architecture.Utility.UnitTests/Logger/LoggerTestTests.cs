using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bryan.Architecture.Utility.Logger.Enum;
using NUnit.Framework;

namespace Bryan.Architecture.Utility.UnitTests.Logger
{
    [TestFixture]
    public class LoggerTest
    {
        [Test]
        public void When_Rasie_Trace_Log_To_Console()
        {
            try
            {
                int zero = 0;
                int i = 1 / zero;
            }
            catch (Exception e)
            {
                Bryan.Architecture.Utility.Logger.Logger.Log(LoggerLevel.Debug, e, message: "Test");
            }
        }
    }
}
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void LinqTest()
        {
            SampleQueries.LinqSamples linq = new SampleQueries.LinqSamples();
        }
    }
}

using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RepairHouse.Temporals;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        MyTest myTest = new MyTest();

        [TestMethod]
        public void TestMethod1()
        {
            Debug.WriteLine(myTest.helloWord());
        }
    }
}

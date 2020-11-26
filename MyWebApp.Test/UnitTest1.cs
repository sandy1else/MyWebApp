using System;
using LogicLayer.BusinessLogic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MyWebApp.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        { 
            bool result = PracticeManager.IsEvenNumber(1);
             
            Assert.AreEqual(result,false);
        }
    }
}

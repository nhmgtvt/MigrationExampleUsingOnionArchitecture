using Microsoft.VisualStudio.TestTools.UnitTesting;
using Infrastructure.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.FileIO.Tests
{
    [TestClass()]
    public class FileWriteTests
    {
        [TestMethod()]
        public void GetFileContentsTest()
        {
            //arrange
            var fileWriteTest = new FileWrite("aaaa");
            //act
            var testResult = fileWriteTest.SaveFileContents();
            //assert
            Assert.IsFalse(testResult);
        }
    }
}

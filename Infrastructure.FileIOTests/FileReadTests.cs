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
    public class FileReadTests
    {
        [TestMethod()]
        public void GetFileContentsTest()
        {
            //arrange
            var fileReadTest = new FileRead("aaaa");
            //act
            var testResult = fileReadTest.GetFileContents();
            //assert
            Assert.IsNull(testResult);
        }
    }
}
using Infrastructure.CustomerService;
using Infrastructure.FileIO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.CustomerServiceTests
{
    [TestClass()]
    public class GetExternalCustomerFromFileServiceTests
    {
        [TestMethod()]
        public void GetExternalSourcesTests()
        {
            //arrange
            var mockFileRead = new MockFileRead();
            var test = new GetExternalCustomerFromFileService(mockFileRead);

            //act
            var testResult = test.GetExternalSources();

            //assert
            Assert.IsTrue(testResult.Count() == 2);
        }
        private class MockFileRead : IFileRead
        {
            public IEnumerable<string> GetFileContents()
            {
                return new string[] { "aaa vvv", "bbb ccc" };
            }
        }
    }
}

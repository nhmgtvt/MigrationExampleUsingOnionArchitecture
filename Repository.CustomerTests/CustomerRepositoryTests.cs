using Infrastructure.FileIO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repository.CustomerRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Customer.Tests
{
    [TestClass()]
    public class CustomerRepositoryTests
    {
        [TestMethod()]
        public void SaveAllTest()
        {
            //arrange
            var mockFileWrite = new MockFileWrite();
            var testRepository = new CustomerRepository.CustomerFileRepository(mockFileWrite);
            var contents = new List<Domain.Entities.BasicCustomer> { new Domain.Entities.BasicCustomer { GivenNames = "aaa", LastName = "bbb" } };
            
            //act
            var result = testRepository.SaveAll(contents);
            //assert
            Assert.IsTrue(result);
            Assert.IsTrue(mockFileWrite.Contents.First().Equals("aaa bbb"));

        }
        private class MockFileWrite : IFileWrite
        {
            public IEnumerable<string> Contents { get; set; }
            public bool SaveFileContents()
            {
                return true;
            }
        }
    }
}
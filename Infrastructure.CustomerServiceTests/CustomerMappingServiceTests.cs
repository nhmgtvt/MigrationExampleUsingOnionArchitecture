using Microsoft.VisualStudio.TestTools.UnitTesting;
using Infrastructure.CustomerService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.CustomerService.Tests
{
    [TestClass()]
    public class CustomerMappingServiceTests
    {
        [TestMethod()]
        public void MapTest()
        {
            //Arrange
            var service = new CustomerMappingService();
            var externalCustomer = new ExternalCustomer { FullName = "dgh dsjf ther" };
            //Act
            var test = service.Map(externalCustomer);
            //Assert
            Assert.IsTrue(test.LastName.Equals("ther")
                            && test.GivenNames.Equals("dgh dsjf"));
        }
    }
}
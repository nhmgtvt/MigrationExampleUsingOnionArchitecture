using Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Service.Interfaces.Domain_Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces.Domain_Services.Tests
{
    [TestClass()]
    public class CustomerSortingServiceTests
    {
        [TestMethod()]
        public void SortTest()
        {
            // Arrange
            var customerSortingService = new CustomerSortingService();
            var customers = new List<BasicCustomer>();
            customers.Add(new BasicCustomer { LastName = "z", GivenNames = "asd" });
            customers.Add(new BasicCustomer { LastName = "msd", GivenNames = "sdf" });
            customers.Add(new BasicCustomer { LastName = "msd", GivenNames = "abc" });
            customers.Add(new BasicCustomer { LastName = "asd", GivenNames = "qwe" });

            var expectedResult = new List<BasicCustomer>();
            expectedResult.Add(new BasicCustomer { LastName = "asd", GivenNames = "qwe" });
            expectedResult.Add(new BasicCustomer { LastName = "msd", GivenNames = "abc" });
            expectedResult.Add(new BasicCustomer { LastName = "msd", GivenNames = "sdf" });
            expectedResult.Add(new BasicCustomer { LastName = "z", GivenNames = "asd" });

            //Act
            var test = customerSortingService.Sort(customers).ToList();

            //Assert
            Assert.IsTrue(test.Count() == 4);
            for (int i = 0; i < test.Count; i++)
            {
                if (!
                        (test[i].LastName.Equals(expectedResult[i].LastName) &&
                            test[i].GivenNames.Equals(expectedResult[i].GivenNames))
                    )
                {
                    Assert.Fail();
                    break;
                }
            }
        }
    }
}
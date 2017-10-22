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
    public class PersonSortingServiceTests
    {
        [TestMethod()]
        public void SortTest()
        {
            // Arrange
            var PersonSortingService = new PersonSortingService();
            var customers = new List<Person>();
            customers.Add(new Person { LastName = "z", GivenNames = "asd" });
            customers.Add(new Person { LastName = "msd", GivenNames = "sdf" });
            customers.Add(new Person { LastName = "msd", GivenNames = "abc" });
            customers.Add(new Person { LastName = "asd", GivenNames = "qwe" });

            var expectedResult = new List<Person>();
            expectedResult.Add(new Person { LastName = "asd", GivenNames = "qwe" });
            expectedResult.Add(new Person { LastName = "msd", GivenNames = "abc" });
            expectedResult.Add(new Person { LastName = "msd", GivenNames = "sdf" });
            expectedResult.Add(new Person { LastName = "z", GivenNames = "asd" });

            //Act
            var test = PersonSortingService.Sort(customers).ToList();

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
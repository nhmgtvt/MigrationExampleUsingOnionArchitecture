using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces.Domain_Services
{
    public class CustomerSortingService : ISortingService<BasicCustomer>
    {
        public IEnumerable<BasicCustomer> Sort(IEnumerable<BasicCustomer> customers)
        {
            return customers.OrderBy(customer => customer.LastName).ThenBy(customer => customer.GivenNames);
        }
    }
}

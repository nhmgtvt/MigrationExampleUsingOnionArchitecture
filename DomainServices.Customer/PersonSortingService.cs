using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces.Domain_Services
{
    public class PersonSortingService : ISortingService<Person>
    {
        public IEnumerable<Person> Sort(IEnumerable<Person> customers)
        {
            return customers.OrderBy(customer => customer.LastName).ThenBy(customer => customer.GivenNames);
        }
    }
}

using Domain.Entities;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementation
{
    public class CustomerSortingService : ISortingService<Customer>
    {
        private IEnumerable<Customer> _customers;
        public CustomerSortingService(IEnumerable<Customer> customers)
        {
            _customers = customers;
        }
        public IEnumerable<Customer> Sort()
        {
            return _customers.OrderBy(customer => customer.LastName).ThenBy(customer => customer.GivenNames);
        }
    }
}

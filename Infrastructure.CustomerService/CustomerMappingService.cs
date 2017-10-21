using Domain.Entities;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.CustomerService
{
    public class CustomerMappingService : IMappingService<BasicCustomer, ExternalCustomer>
    {
        public BasicCustomer Map(ExternalCustomer externalCustomer)
        {
            var customer = new BasicCustomer();
            customer.LastName = externalCustomer.FullName.Split().Last();
            customer.GivenNames = externalCustomer.FullName.Remove(externalCustomer.FullName.Length - customer.LastName.Length).TrimEnd();
            return customer;
        }
    }
}

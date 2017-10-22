using Domain.Entities;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.CustomerService
{
    public class PersonMappingService : IMappingService<Person, ExternalCustomer>
    {
        public Person Map(ExternalCustomer externalCustomer)
        {
            var customer = new Person();
            customer.LastName = externalCustomer.FullName.Split().Last();
            customer.GivenNames = externalCustomer.FullName.Remove(externalCustomer.FullName.Length - customer.LastName.Length).TrimEnd();
            return customer;
        }
    }
}

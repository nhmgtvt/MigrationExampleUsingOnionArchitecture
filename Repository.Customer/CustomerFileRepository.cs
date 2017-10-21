using Domain.ReporitoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Infrastructure.FileIO;

namespace Repository.CustomerRepository
{
    public class CustomerFileRepository : ICustomerRepositorySave
    {
        private readonly IFileWrite _file;
        public CustomerFileRepository(IFileWrite file)
        {
            _file = file;
        }
        public bool SaveAll(IEnumerable<BasicCustomer> customers)
        {
            if (customers != null)
            {
                _file.Contents = from customer in customers
                                 select String.Format("{0} {1}", customer.GivenNames, customer.LastName);
                return _file.SaveFileContents();
            }
            else
                return false;
        }
    }
}

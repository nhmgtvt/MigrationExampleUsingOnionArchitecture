using Domain.Entities;
using Domain.ReporitoryInterfaces;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.CustomerService
{
    public class PersonProcessingService : IProcessingService
    {
        private readonly IMappingService<Person, ExternalCustomer> _customerMap;
        private readonly IGetExternalSourcesService<ExternalCustomer> _getExternalCustomerFromFileService;
        private readonly ISortingService<Person> _sortingServices;
        private readonly IPersonRepositorySave _repository;
        public PersonProcessingService(IGetExternalSourcesService<ExternalCustomer> getExternalCustomerFromFileService , IMappingService<Person, ExternalCustomer> customerMap 
                                            , ISortingService<Person> sortingService, IPersonRepositorySave repository)
        {
            _customerMap = customerMap;
            _getExternalCustomerFromFileService = getExternalCustomerFromFileService;
            _sortingServices = sortingService;
            _repository = repository;
        }
        public void Process()
        {
            var externalCustomers = _getExternalCustomerFromFileService.GetExternalSources();
            if (externalCustomers != null)
            {
                var customers = from externalCustomer in externalCustomers
                                select _customerMap.Map(externalCustomer);
                var sortedCustomers = _sortingServices.Sort(customers);
                _repository.SaveAll(sortedCustomers);
            }
        }
    }
}

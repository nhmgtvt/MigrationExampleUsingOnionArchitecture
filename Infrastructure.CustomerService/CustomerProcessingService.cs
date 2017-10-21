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
    public class CustomerProcessingService : IProcessingService
    {
        private readonly IMappingService<BasicCustomer, ExternalCustomer> _customerMap;
        private readonly IGetExternalSourcesService<ExternalCustomer> _getExternalCustomerFromFileService;
        private readonly ISortingService<BasicCustomer> _sortingServices;
        private readonly ICustomerRepositorySave _repository;
        public CustomerProcessingService(IGetExternalSourcesService<ExternalCustomer> getExternalCustomerFromFileService , IMappingService<BasicCustomer, ExternalCustomer> customerMap 
                                            , ISortingService<BasicCustomer> sortingService, ICustomerRepositorySave repository)
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

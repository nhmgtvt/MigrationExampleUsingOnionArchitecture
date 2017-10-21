using Infrastructure.FileIO;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.CustomerService
{
    public class GetExternalCustomerFromFileService : IGetExternalSourcesService<ExternalCustomer>
    {
        private readonly IFileRead _file;
        public GetExternalCustomerFromFileService(IFileRead file)
        {
            _file = file;
        }
        public IEnumerable<ExternalCustomer> GetExternalSources()
        {
            var contents = _file.GetFileContents();
            if (contents != null)
            {
                var result = from string s in contents
                             select new ExternalCustomer { FullName = s };
                return result;
            }
            else
                return null;
        }
    }
}

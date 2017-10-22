using Domain.Entities;
using Infrastructure.CustomerService;
using Infrastructure.FileIO;
using Repository.CustomerRepository;
using Service.Interfaces.Domain_Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolvedByOnionArchitecture
{
    class Program
    {
        static void Main(string[] args)
        {
            //create process object

            string filePath;
            if (args.Length > 0)
            {
                filePath = String.Format("{0}/{1}", Environment.CurrentDirectory, args[0]);
                Console.WriteLine();
                Console.WriteLine(filePath);
            }
            else
                filePath = String.Format("{0}/{1}", Environment.CurrentDirectory, "unsorted-names-list.txt");
            var fileRead = new FileRead(filePath);
            var getExternalService = new GetExternalPersonFromFileService(fileRead);

            var mappingService = new PersonMappingService();

            var sortingService = new PersonSortingService();

            var fileWrite = new FileWrite(String.Format("{0}/{1}", Environment.CurrentDirectory, "sorted-names-list.txt"));
            var repository = new CustomerFileRepository(fileWrite);

            var process = new PersonProcessingService(getExternalService, mappingService, sortingService,repository);
            process.Process();

            //end process

            //display result onscreen
            foreach (var fullname in fileWrite.Contents)
                Console.WriteLine(fullname);

            Console.ReadLine();
        }
    }
}

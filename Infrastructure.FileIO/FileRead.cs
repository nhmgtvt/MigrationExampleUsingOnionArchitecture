using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.FileIO
{
    public class FileRead : IFileRead
    {
        private readonly string _filePath;
        public FileRead(string filePath)
        {
            _filePath = filePath;
        }
        public IEnumerable<string> GetFileContents()
        {
            IEnumerable<string> result = null;
            try
            {
                result = File.ReadLines(_filePath);
            }
            catch (Exception ex)
            {
            };
            return result;
        }
    }
}

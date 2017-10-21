using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.FileIO
{
    public class FileWrite : IFileWrite
    {
        private readonly string _filePath;
        public IEnumerable<string> Contents{ get; set; }
        public FileWrite(string filePath)
        {
            _filePath = filePath;
        }
        public bool SaveFileContents()
        {
            var susccess = false;
            try
            {
                File.WriteAllLines(_filePath, Contents);
                susccess = true;
            }
            catch (Exception ex)
            {
            };
            return susccess;
        }
    }
}

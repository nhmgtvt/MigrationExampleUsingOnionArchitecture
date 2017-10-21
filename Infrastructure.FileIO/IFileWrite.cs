using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.FileIO
{
    public interface IFileWrite
    {
        IEnumerable<string> Contents { get; set; }
        bool SaveFileContents();
    }
}

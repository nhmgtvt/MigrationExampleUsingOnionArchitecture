using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.FileIO
{
    public interface IFileRead
    {
        IEnumerable<string> GetFileContents();
    }
}

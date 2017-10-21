using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ReporitoryInterfaces
{
    public interface IBaseRepositorySave<Entity>
    {
        bool SaveAll(IEnumerable<Entity> entities);
    }
}

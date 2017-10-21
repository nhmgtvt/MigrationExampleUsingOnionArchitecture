using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IMappingService<InternalEntity,ExternalEntity>
    {
        InternalEntity Map(ExternalEntity externalEntity);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(dynamic idResource):base($"La ressource {idResource} n'a pas été trouvée")
        {

        }
    }
}

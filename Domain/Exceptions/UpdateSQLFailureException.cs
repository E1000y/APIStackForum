using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class UpdateSQLFailureException : Exception
    {
        public UpdateSQLFailureException(Entity entity) : base($"L'update de l'entité {entity} à échouée")
        {

        }
    }
}

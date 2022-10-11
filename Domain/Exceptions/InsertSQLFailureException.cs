using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class InsertSQLFailureException : Exception 
    {
        public InsertSQLFailureException(Entity entity) : base($"L'insertion de l'entité {entity} n'a pas fonctionné.")
        {
                
        }
    }
}

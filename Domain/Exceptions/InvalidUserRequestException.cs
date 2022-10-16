using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
   public class InvalidUserRequestException : Exception
    {
        public InvalidUserRequestException() : base("Cet utilisateur n'a pas le droit de modifier cette entrée.")
        {

        }
    }
}

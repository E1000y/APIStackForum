using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
   public class AuthenticationFailException : Exception
    {

        public AuthenticationFailException(): base("L'authentification a échoué")
        {

        }
    }
}
